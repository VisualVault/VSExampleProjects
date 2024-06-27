using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using VisualVault.Forms.Import.Entities;
using VisualVault.Forms.Import.Entities.Profiles;
using VVRestApi.Common;
using VVRestApi.Vault;
using VVRestApi.Vault.Forms;

namespace VisualVault.Forms.Import.BusinessLogic
{
    class FormImportEngine
    {
        #region Fields

        internal delegate void ProgressChanged(object sender, ProgressChangedArgs args);

        internal event ProgressChanged OnProgressChanged;

        private readonly FormTemplate _targetFormTemplate;

        private readonly string _csvFilePath;

        private readonly VaultApi _vault;

        private int _createCount;

        private int _updateCount;

        private int _skippedCount;

        private readonly Profile _profile;

        private int _deletedCount;

        private int _userCreateCount;

        #endregion

        /// <summary>
        /// Read CSV file and import forms.  For this simple example assume the column names
        /// in the CSV file match the user properties.
        /// </summary>
        public FormImportEngine(string filePath, VaultApi vault, FormTemplate template, Profile profile)
        {
            _profile = profile;

            _csvFilePath = filePath;

            _vault = vault;
           
            _targetFormTemplate =template;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<VVRestApi.Vault.Forms.FormInstance> ImportFormDataFromCsvFile()
        {
            //Read the csv file and populates a VisualVault form for each row in the CSV file
            //If the column name in the CSV file matches a form field name in the target form template
            //then the field value will be updated if updateExisting == true

            var formList = new List<VVRestApi.Vault.Forms.FormInstance>();

            var cleanedCsvFileName = RemoveLineFeedsCreateNewFile(_csvFilePath);

            var lineCount = CountLinesInCsv(cleanedCsvFileName);

            var linesProcessed = 0;

            _createCount = 0;

            _updateCount = 0;

            _skippedCount = 0;

            try
            {
                var columnNames = GetCsvColumnNames();

                lineCount -= 1; //do not count header row

                if (lineCount > 0)
                {
                    var foundFields = ValidateFormFieldsExist(columnNames);

                    //if first column in CSV contains FormId to be updated, force update even if no other matching fields found
                    //sometimes its necessary to create a new data instance revision to propogate changes made to a form template
                    bool forceUpdate = columnNames.Length > 0 && _profile.AllowUpdate;

                    if (!foundFields && forceUpdate)
                    {
                        foundFields = true;
                    }

                    if (foundFields)
                    {
                        var fileLines = new List<string>();

                        using (var sr = File.OpenText(cleanedCsvFileName))
                        {
                            var fileRow = sr.ReadLine();

                            int linesRead = 0;

                            while (fileRow != null)
                            {
                                if (linesRead == 0)
                                {
                                    var statusMessage = string.Format("Reading {0} file lines...", lineCount);

                                    InvokeOnProgressChanged(new ProgressChangedArgs
                                    {
                                        TotalItems = lineCount,
                                        ProgressMessage = statusMessage,
                                        ErrorMessage = "",
                                        ImportStatus = ProgressStatus.Starting
                                    });
                                }
                                else
                                {
                                    fileLines.Add(fileRow);
                                }

                                fileRow = sr.ReadLine();
                                linesRead++;
                            }
                        }

                        Parallel.ForEach(fileLines,
                            new ParallelOptions { MaxDegreeOfParallelism = 1 },
                            (line, loop) =>
                            {
                                FormInstance existingFormInstance = null;

                                try
                                {
                                    //pattern to find a delimiter and ignore other occurences of the delimiter character which occur within quotes
                                    const string pattern = "," + "(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))";
                                    var regex = new Regex(pattern);

                                    var delimStr = _profile.CsvDelimeterCharacter;
                                    var delimiter = delimStr.ToCharArray();

                                    var values = _profile.CsvLineItemsQuoted ? regex.Split(line) : line.Split(delimiter);

                                    var updateExisting = _profile.AllowUpdate;

                                    //if signature of CEO field has a value need to impersonate that user
                                    var ceoUserName = "";
                                    for (int i = 0; i < columnNames.Length; i++)
                                    {
                                        if(columnNames[i] == "Signature of CEO")
                                        {
                                            ceoUserName = values[i];

                                            string datePattern = @"\d{2}/\d{2}/\d{2} \d{2}:\d{2}(AM|PM)";
                                            string replacement = "";
                                            Regex rgx = new Regex(datePattern);
                                            ceoUserName = rgx.Replace(ceoUserName, replacement);
                                        }
                                    }

                                    if (updateExisting)
                                    {
                                        var formDhDocId = values[0];

                                        RequestOptions requestOptions = new RequestOptions
                                        {
                                            Query = "instanceName eq '" + formDhDocId + "'"
                                        };

                                        //requestOptions.Fields = string.Join(",", columnNames);

                                        try
                                        {
                                            var formdata =_vault.FormTemplates.GetFormInstanceData(_targetFormTemplate.RevisionId,requestOptions);

                                            if (formdata.Count > 0)
                                            {
                                                existingFormInstance = formdata[0];
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            //const string logfile = @"c:\!data\problemforms.txt";

                                            //File.AppendAllText(logfile,formDhDocId);
                                        }
                                    }

                                    var statusMessage = string.Format("Processing form {0} of {1}", linesProcessed, lineCount);

                                    InvokeOnProgressChanged(new ProgressChangedArgs
                                    {
                                        TotalItems = lineCount,
                                        ProgressMessage = statusMessage,
                                        ErrorMessage = "",
                                        ImportStatus = ProgressStatus.Processing
                                    });

                                    FormInstance newFormInstance = existingFormInstance != null ? UpdateFormInstance(existingFormInstance, columnNames, values, forceUpdate) : CreateFormInstance(columnNames, values);

                                    if (newFormInstance != null || existingFormInstance != null)
                                    {
                                        formList.Add(newFormInstance);

                                        Interlocked.Increment(ref linesProcessed);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    var errMsg = string.Format("Error on form {0} of {1}: {2} Data: {3}", linesProcessed, lineCount, ex.Message, line);


                                    //const string logfile = @"c:\!data\problemforms.txt";
                                    //File.AppendAllText(logfile,errMsg + line);

                                    InvokeOnProgressChanged(new ProgressChangedArgs
                                    {
                                        TotalItems = lineCount,
                                        ProgressMessage = errMsg,
                                        ErrorMessage = errMsg,
                                        ImportStatus = ProgressStatus.Processing
                                    });
                                }

                            });
                    }
                    else
                    {
                        //no fields found
                        const string statusMessage = "No matching form field names found";
                        InvokeOnProgressChanged(new ProgressChangedArgs { TotalItems = 0, ProgressMessage = statusMessage });

                    }
                }
                else
                {
                    //no rows found
                    const string statusMessage = "No data rows found in CSV file";
                    InvokeOnProgressChanged(new ProgressChangedArgs { TotalItems = 0, ProgressMessage = statusMessage });

                }
            }
            catch (InvalidDataException ex)
            {
                const string statusMessage = "Invalid Data";
                InvokeOnProgressChanged(new ProgressChangedArgs { TotalItems = 0, ProgressMessage = statusMessage, ErrorMessage = string.Format("{0}", ex.Message), ImportStatus = ProgressStatus.Processing });
            }
            catch (Exception ex)
            {
                const string statusMessage = "Unexpected error";
                InvokeOnProgressChanged(new ProgressChangedArgs { TotalItems = 0, ProgressMessage = statusMessage, ErrorMessage = string.Format("{0} {1}", ex.Message, ex.StackTrace), ImportStatus = ProgressStatus.Processing });
            }

            var completedStatusMessage = string.Format("Processed {0} Forms.  Created:{1} - Updated:{2} - Skipped:{3}", linesProcessed, _createCount, _updateCount, _skippedCount);

            InvokeOnProgressChanged(new ProgressChangedArgs
            {
                TotalItems = lineCount,
                ProgressMessage = completedStatusMessage,
                ErrorMessage = "",
                ImportStatus = ProgressStatus.Completed
            });

            return formList;
        }

        public void DeleteFormInstances(FormTemplate formTemplate, CancellationToken cancellationToken)
        {
            RequestOptions requestOptions = new RequestOptions
            {
                //Query = "[Submission Date] ge '06/12/2017' and ([License State] eq 'Waiting Submission' or [License State] eq 'Waiting Approval')",
                Take = 1000
            };

            List<FormInstance> formInstances = _vault.FormTemplates.GetFormInstanceData(formTemplate.Id, requestOptions);

            while (formInstances.Count > 0)
            {
                try
                {
                    var statusMessage = string.Format("Start Delete of {0} forms...", formInstances.Count);

                    InvokeOnProgressChanged(new ProgressChangedArgs
                    {
                        TotalItems = formInstances.Count,
                        ProgressMessage = statusMessage,
                        ErrorMessage = "",
                        ImportStatus = ProgressStatus.Starting
                    });

                    var options = new ParallelOptions
                    {
                        MaxDegreeOfParallelism = 1,
                        CancellationToken = cancellationToken
                    };

                    int totalCount = formInstances.Count;

                    Parallel.ForEach(formInstances.AsEnumerable(), options, formInstance =>
                    {
                        if (options.CancellationToken.IsCancellationRequested)
                        {
                            //status update
                            return;
                        }

                        try
                        {
                            _vault.FormInstances.DeleteFormInstance(formInstance.RevisionId);
                            _deletedCount++;

                            statusMessage = string.Format("Deleting form {0} of {1} forms...", _deletedCount,
                                totalCount);

                            InvokeOnProgressChanged(new ProgressChangedArgs
                            {
                                TotalItems = totalCount,
                                ProgressMessage = statusMessage,
                                ErrorMessage = "",
                                ImportStatus = ProgressStatus.Starting
                            });

                        }
                        catch (Exception ex)
                        {
                            statusMessage = string.Format("Error Deleting form {0} of {1}: {2}", _deletedCount,
                                totalCount, ex.Message);

                            InvokeOnProgressChanged(new ProgressChangedArgs
                            {
                                TotalItems = totalCount,
                                ProgressMessage = statusMessage,
                                ErrorMessage = "",
                                ImportStatus = ProgressStatus.Processing
                            });
                        }

                        Interlocked.Increment(ref _deletedCount);

                    });

                    //fetch next batch of form instances
                    formInstances = _vault.FormTemplates.GetFormInstanceData(formTemplate.Id, requestOptions);
                }
                catch (Exception ex)
                {
                    var statusMessage = string.Format("Error fetching form instances for deletion {0}", ex.Message);

                    InvokeOnProgressChanged(new ProgressChangedArgs
                    {
                        TotalItems = 0,
                        ProgressMessage = statusMessage,
                        ErrorMessage = "",
                        ImportStatus = ProgressStatus.Processing
                    });

                    formInstances = _vault.FormTemplates.GetFormInstanceData(formTemplate.Id, requestOptions);
                }
            }

            var completionMsg = string.Format("Deleted {0} of {1} forms...", _deletedCount, formInstances.Count);

            InvokeOnProgressChanged(new ProgressChangedArgs
            {
                TotalItems = formInstances.Count,
                ProgressMessage = completionMsg,
                ErrorMessage = "",
                ImportStatus = ProgressStatus.Starting
            });

        }

        public void CreateUserAccountsUsingFormInstances(FormTemplate formTemplate, string userIdFormField, string emailAddressFormField, string siteNameFormField, string formInstanceFilter, CancellationToken cancellationToken)
        {
            formInstanceFilter = "[CEO] eq 'true' and [Email Address] like '%@%'";

            userIdFormField = "email address";
            emailAddressFormField = userIdFormField;
            siteNameFormField = "provider id";
            
            RequestOptions requestOptions = new RequestOptions
            {
                //Query = "[Submission Date] ge '06/12/2017' and ([License State] eq 'Waiting Submission' or [License State] eq 'Waiting Approval')",
                Query = formInstanceFilter,
                Fields = "Email Address,Provider ID,First Name,Last Name,CEO",
                Take = 2000
            };

            List<FormInstance> formInstances = _vault.FormTemplates.GetFormInstanceData(formTemplate.Id, requestOptions);

            //while (formInstances.Count > 0)
            //{
                try
                {
                    var statusMessage = string.Format("Start create {0} user accounts...", formInstances.Count);

                    InvokeOnProgressChanged(new ProgressChangedArgs
                    {
                        TotalItems = formInstances.Count,
                        ProgressMessage = statusMessage,
                        ErrorMessage = "",
                        ImportStatus = ProgressStatus.Starting
                    });

                    var options = new ParallelOptions
                    {
                        MaxDegreeOfParallelism = 1,
                        CancellationToken = cancellationToken
                    };

                    int totalCount = formInstances.Count;

                    Parallel.ForEach(formInstances.AsEnumerable(), options, formInstance =>
                    {
                        bool createdUser = false;

                        if (options.CancellationToken.IsCancellationRequested)
                        {
                            //status update
                            return;
                        }

                        try
                        {

                            var siteName = "";
                            var userId = "";
                            var emailAddress = "";
                            var firstName = "";
                            var lastName = "";

                            foreach (KeyValuePair<string, string> field in formInstance.Fields)
                            {
                                if (field.Key.ToLower() == siteNameFormField.ToLower())
                                {
                                    siteName = field.Value;
                                }

                                if (field.Key.ToLower() == userIdFormField.ToLower())
                                {
                                    userId = field.Value;
                                }

                                if (field.Key.ToLower() == emailAddressFormField.ToLower())
                                {
                                    emailAddress = field.Value;
                                }

                                if (field.Key.ToLower() == "first name")
                                {
                                    firstName = field.Value;
                                    if (firstName.Contains(" "))
                                    {
                                        firstName = firstName.Split(' ')[0];
                                    }
                                }

                                if (field.Key.ToLower() == "last name")
                                {
                                    lastName = field.Value;
                                   
                                    if (lastName.Contains(" "))
                                    {
                                        lastName = lastName.Split(' ')[0];
                                    }
                                }
                            }

                            string errorMsg = "";

                            if (!string.IsNullOrEmpty(siteName))
                            {
                                if (!string.IsNullOrEmpty(userId))
                                {
                                    if (!string.IsNullOrEmpty(emailAddress))
                                    {
                                        //get site
                                        var site = _vault.Sites.GetSite(siteName) ??
                                                   _vault.Sites.CreateSite(siteName, siteName);

                                        if (site != null)
                                        {
                                            //check if user exists
                                            requestOptions = new RequestOptions
                                            {
                                                //Query = "[Submission Date] ge '06/12/2017' and ([License State] eq 'Waiting Submission' or [License State] eq 'Waiting Approval')",
                                                Query = string.Format("[UserId] eq '{0}'",userId),
                                                Take = 1000
                                            };

                                            var users = _vault.Users.GetUsers(requestOptions);

                                            if (users.Items.Count==0)
                                            {
                                                //userId = "todtest1";
                                                //firstName = "Tod";
                                                //lastName = "Olsen";
                                                //emailAddress = "tsolsen7@gmail.com";

                                                var password = ShortGuid.NewGuid().ToString().Replace("-","");

                                                if (password.Length > 8)
                                                {
                                                    password = password.Substring(0, 7);
                                                }

                                                var user = _vault.Users.CreateUser(site.Id, userId, firstName, "", lastName, emailAddress, password, true, true,DateTime.Now.AddDays(90),false);

                                                createdUser = true;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        errorMsg = "emailAddress value not found";
                                    }
                                }
                                else
                                {
                                    errorMsg = "userId value not found";
                                }
                            }
                            else
                            {
                                errorMsg = "siteName value not found";
                            }


                            //_userCreateCount++;
                            Interlocked.Increment(ref _userCreateCount);

                            if (string.IsNullOrEmpty(errorMsg))
                            {
                                if (createdUser)
                                {
                                    statusMessage = string.Format("Creating user {0} of {1}", _userCreateCount,totalCount);
                                }
                                else
                                {
                                    statusMessage = string.Format("Skipping user {0} of {1}", _userCreateCount, totalCount);
                                }
                            }
                            else
                            {
                                statusMessage = string.Format("Failed to creating user {0} of {1}: {2}", _userCreateCount, totalCount, errorMsg);
                                errorMsg = statusMessage;
                            }

                            InvokeOnProgressChanged(new ProgressChangedArgs
                            {
                                TotalItems = totalCount,
                                ProgressMessage = statusMessage,
                                ErrorMessage = errorMsg,
                                ImportStatus = ProgressStatus.Starting
                            });

                        }
                        catch (Exception ex)
                        {
                            statusMessage = string.Format("Error creating user {0} of {1}: {2}", _userCreateCount,
                                totalCount, ex.Message);

                            InvokeOnProgressChanged(new ProgressChangedArgs
                            {
                                TotalItems = totalCount,
                                ProgressMessage = statusMessage,
                                ErrorMessage = statusMessage,
                                ImportStatus = ProgressStatus.Processing
                            });
                        }

                        //Interlocked.Increment(ref _userCreateCount);

                    });

                    //fetch next batch of form instances
                    //formInstances = _vault.FormTemplates.GetFormInstanceData(formTemplate.Id, requestOptions);
                }
                catch (Exception ex)
                {
                    var statusMessage = string.Format("Error fetching form instances for user create {0}", ex.Message);

                    InvokeOnProgressChanged(new ProgressChangedArgs
                    {
                        TotalItems = 0,
                        ProgressMessage = statusMessage,
                        ErrorMessage = "",
                        ImportStatus = ProgressStatus.Processing
                    });

                    //formInstances = _vault.FormTemplates.GetFormInstanceData(formTemplate.Id, requestOptions);
                }
            //}

            var completionMsg = string.Format("Created {0} of {1} users...", _userCreateCount, formInstances.Count);

            InvokeOnProgressChanged(new ProgressChangedArgs
            {
                TotalItems = formInstances.Count,
                ProgressMessage = completionMsg,
                ErrorMessage = "",
                ImportStatus = ProgressStatus.Starting
            });

        }

        #region Methods

        private string[] GetCsvColumnNames()
        {
            //Read the csv file and populates an array of the column names
            //Column names must be located in the first row

            string[] columnNames = null;

            using (var sr = File.OpenText(_csvFilePath))
            {
                var fileRow = sr.ReadLine();

                if (fileRow != null)
                {
                    //pattern to find a delimiter and ignore other occurences of the delimiter character which occur within quotes
                    const string pattern = "," + "(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))";
                    var r = new Regex(pattern);

                    var delimStr = _profile.CsvDelimeterCharacter;
                    var delimiter = delimStr.ToCharArray();

                    columnNames = _profile.CsvHeadersQuoted ? r.Split(fileRow) : fileRow.Split(delimiter);
                }
            }

            return columnNames;
        }

        private static int CountLinesInCsv(string fileName)
        {
            var count = 0;

            using (var r = new StreamReader(fileName))
            {
                while (r.ReadLine() != null)
                {
                    count++;
                }
            }
            return count;
        }

        private static string RemoveLineFeedsCreateNewFile(string csvFileFullPath)
        {
            string newFileName = "";

            try
            {
                //replace carriage return / line feeds that are located with quotes

                FileInfo sourceFile = new FileInfo(csvFileFullPath);

                newFileName = csvFileFullPath.Replace(sourceFile.Name, sourceFile.Name.Replace(sourceFile.Extension, "") + "_cleaned.csv");

                if (File.Exists(newFileName))
                {
                    File.Delete(newFileName);
                }

                using (var sr = new StreamReader(csvFileFullPath))
                {
                    string fileLine = sr.ReadLine();

                    while (fileLine != null)
                    {
                        int n = 0;
                        int quoteCount = 0;

                        while ((n = fileLine.IndexOf('"', n)) != -1)
                        {
                            n++;
                            quoteCount++;
                        }

                        //if file line does not contain an even number of quotes then keep appending
                        int remainder = 0;
                        Math.DivRem(quoteCount, 2, out remainder);
                        if (remainder != 0)
                        {
                            //not even number of quotes, read next line from source file and append
                            //replace new line with html break
                            fileLine += "</br>";
                            fileLine += sr.ReadLine();
                        }
                        else
                        {
                            //even number of quotes so write to new csv file
                            //replace any new line characters found between quotes
                            var regEx = new Regex("(?!(([^\"]*\"){2})*[^\"]*$)\\n+");
                            fileLine = regEx.Replace(fileLine, "");

                            //replace non printable characters
                            var regEx2 = new Regex("([^!-~^\\s])+");
                            fileLine = regEx2.Replace(fileLine, "");

                            File.AppendAllLines(newFileName, new List<string> { fileLine });

                            //read next line from source file
                            fileLine = sr.ReadLine();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                if (File.Exists(csvFileFullPath))
                {
                    FileInfo sourceFile = new FileInfo(csvFileFullPath);
                    string errorLogFilePath = csvFileFullPath.Replace(sourceFile.Name.Replace(sourceFile.Extension, ""), "ErrorLog.txt");
                    File.AppendAllLines(errorLogFilePath, new List<string> { ex.ToString() });
                }
            }

            return newFileName;
        }

        private bool ValidateFormFieldsExist(string[] columnNames)
        {
            if (columnNames != null)
            {
                var formFields2 = _targetFormTemplate.GetFormFields();

                var formFields = _targetFormTemplate.GetFormFields().Fields;

                for (var i = 0; i < columnNames.Length; i += 1)
                {

                    foreach (var templateField in formFields)
                    {
                        if (columnNames[i].Trim().ToLower() == templateField.Key.ToLower())
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private FormInstance CreateFormInstance(string[] columnNames, string[] values)
        {
            var fieldCount = columnNames.Length;

            FormInstance vvForm = null;

            if (fieldCount > 0)
            {
                //Create new form instance dynamic DTO
                var fi = new ExpandoObject() as IDictionary<string, Object>;

                for (var i = 0; i < fieldCount; i++)
                {
                    var fieldValue = values[i];

                    var colName = columnNames[i];

                    //replace leading and trailing quotes (used to wrap field in csv)
                    fieldValue = fieldValue.TrimStart('"');
                    fieldValue = fieldValue.TrimEnd('"');

                    //validate dates to ensure they match one of the supplied formats
                    if (!string.IsNullOrEmpty(fieldValue))
                    {
                        if (columnNames[i].ToLower().Contains("date"))
                        {
                            DateTime dateVal;

                            //if colname contains data type then remove
                            colName = colName.Replace("[date]", "");

                            string[] dateFormats = _profile.DateTimeFormat.Split(',');

                            if (DateTime.TryParseExact(fieldValue, dateFormats, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out dateVal))
                            {
                                //store date value in string using ISO 8601 date format
                                //iso 8601 is 
                                fieldValue = dateVal.ToString("O");
                            }
                        }
                    }
                    else
                    {
                        fieldValue = "";
                    }

                    //Add form fields using CSV column names and populate their values
                    fi.Add(colName, fieldValue);
                }

                vvForm = _targetFormTemplate.CreateNewFormInstance((ExpandoObject)fi);

                _createCount++;
            }

            return vvForm;
        }

        private FormInstance UpdateFormInstance(FormInstance existingFormInstance, string[] columnNames, string[] values, bool forceUpdate)
        {
            var fieldCount = columnNames.Length;

            var vvForm = existingFormInstance;

            if (fieldCount > 0 && existingFormInstance != null)
            {
                var changesDetected = false;

                //determine if any field values have changed
                if (forceUpdate)
                {
                    changesDetected = true;
                }
                else
                {
                    for (var i = 0; i < fieldCount; i++)
                    {
                        foreach (var field in vvForm.Fields)
                        {
                            if (columnNames[i].Trim().ToLower() == field.Key.ToLower())
                            {
                                if (field.Value != values[i])
                                {
                                    changesDetected = true;
                                }
                                break;
                            }
                        }

                        if (changesDetected) break;
                    }
                }

                if (changesDetected)
                {
                    //Create new form instance dynamic DTO
                    var fi = new ExpandoObject() as IDictionary<string, Object>;

                    for (var i = 0; i < fieldCount; i++)
                    {
                        var fieldValue = values[i];

                        var colName = columnNames[i];

                        //replace leading and trailing quotes (used to wrap field in csv)
                        fieldValue = fieldValue.TrimStart('"');
                        fieldValue = fieldValue.TrimEnd('"');

                        //validate dates to ensure they match one of the supplied formats
                        if (!string.IsNullOrEmpty(fieldValue))
                        {
                            if (colName.ToLower().Contains("date"))
                            {
                                DateTime dateVal;

                                //if colname contains data type then remove
                                colName = colName.Replace("[date]", "");

                                string[] dateFormats = _profile.DateTimeFormat.Split(',');

                                if (DateTime.TryParseExact(fieldValue, dateFormats, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out dateVal))
                                {
                                    //store date value in string using ISO 8601 date format
                                    //iso 8601 is 
                                    fieldValue = dateVal.ToString("O");
                                }
                            }
                        }
                        else
                        {
                            fieldValue = "";
                        }

                        //Add form fields using CSV column names and populate their values
                        fi.Add(colName, fieldValue);
                    }

                    vvForm = existingFormInstance.CreateNewRevision((ExpandoObject)fi);

                    if (vvForm != null)
                    {
                        _updateCount++;
                    }
                }
                else
                {
                    _skippedCount++;
                }
            }

            return vvForm;
        }

        internal void InvokeOnProgressChanged(ProgressChangedArgs args)
        {
            var handler = OnProgressChanged;
            if (handler != null) handler(this, args);
        }

        #endregion
    }

}
