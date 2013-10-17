using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using VVRuntime.VisualVault;
using VVRuntime.VisualVault.Forms;
using VisualVault.Forms.Import.Entities;
using VisualVault.Forms.Import.Entities.Profiles;

namespace VisualVault.Forms.Import.BusinessLogic
{
    class FormImportEngine
    {
        #region Fields

        internal delegate void ProgressChanged(object sender, ProgressChangedArgs args);

        internal event ProgressChanged OnProgressChanged;

        private readonly FormTemplate _targetFormTemplate;

        private readonly string _csvFilePath;

        private readonly Vault _vault;

        private int _createCount;

        private int _updateCount;

        private int _skippedCount;

        private readonly Profile _profile;

        #endregion

        /// <summary>
        /// Read CSV file and import forms.  For this simple example assume the column names
        /// in the CSV file match the user properties.
        /// </summary>
        public FormImportEngine(string filePath, Vault vault, FormTemplate template, Profile profile)
        {
            _profile = profile;

            _csvFilePath = filePath;

            _vault = vault;

            _targetFormTemplate = template;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Form> ImportFormDataFromCsvFile()
        {
            //Read the csv file and populates a VisualVault form for each row in the CSV file
            //If the column name in the CSV file matches a form field name in the target form template
            //then the field value will be updated if updateExisting == true

            var formList = new List<Form>();

            var lineCount = CountLinesInCsv(_csvFilePath);

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

                    if (foundFields)
                    {
                        using (var sr = File.OpenText(_csvFilePath))
                        {
                            var fileRow = sr.ReadLine();

                            if (linesProcessed == 0)
                            {
                                //skip first row which has column names
                                fileRow = sr.ReadLine();

                                var statusMessage = string.Format("Starting import of {0} forms...", lineCount);

                                InvokeOnProgressChanged(new ProgressChangedArgs
                                {
                                    TotalItems = lineCount,
                                    ProgressMessage = statusMessage,
                                    ErrorMessage = "",
                                    ImportStatus = ProgressStatus.Starting
                                });
                            }

                            while (fileRow != null)
                            {
                                //pattern to find a delimiter and ignore other occurences of the delimiter character which occur within quotes
                                const string pattern = "," + "(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))";
                                var regex = new Regex(pattern);

                                var delimStr = _profile.CsvDelimeterCharacter;
                                var delimiter = delimStr.ToCharArray();

                                var values = _profile.CsvLineItemsQuoted ? regex.Split(fileRow) : fileRow.Split(delimiter);

                                Form existingFormInstance = null;

                                var updateExisting = _profile.AllowUpdate;

                                try
                                {
                                    if (updateExisting)
                                    {
                                        var formId = values[0];

                                        existingFormInstance = _vault.Forms.GetFormDataInstance(formId);
                                    }
                                }
                                catch (Exception)
                                {
                                    updateExisting = false;
                                }

                                var statusMessage = string.Format("Processing form {0} of {1}", linesProcessed, lineCount);

                                InvokeOnProgressChanged(new ProgressChangedArgs
                                                            {
                                                                TotalItems = lineCount,
                                                                ProgressMessage = statusMessage,
                                                                ErrorMessage = "",
                                                                ImportStatus = ProgressStatus.Processing
                                                            });

                                Form newFormInstance = existingFormInstance != null ? UpdateFormInstance(existingFormInstance, columnNames, values) : CreateFormInstance(columnNames, values);

                                if (newFormInstance != null)
                                {
                                    formList.Add(newFormInstance);

                                    linesProcessed++;
                                }

                                //read next line in CSV file
                                fileRow = sr.ReadLine();

                                //stop importing if an empty lines is found
                                if (fileRow != null)
                                {
                                    if (fileRow.Length == 0)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
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

        private bool ValidateFormFieldsExist(string[] columnNames)
        {
            if (columnNames != null)
            {
                for (var i = 0; i < columnNames.Length; i += 1)
                {
                    foreach (FormField templateField in _targetFormTemplate.FormFields)
                    {
                        if (columnNames[i].Trim().ToLower() == templateField.FieldName.ToLower())
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private Form CreateFormInstance(string[] columnNames, string[] values)
        {
            var fieldCount = columnNames.Length;

            Form vvForm = null;

            if (fieldCount > 0)
            {
                vvForm = _targetFormTemplate.GetNewFormDataInstance();

                //populate form data instance with values

                for (var i = 0; i < fieldCount; i += 1)
                {
                    foreach (FormField field in vvForm.FormFields)
                    {
                        if (columnNames[i].Trim().ToLower() == field.FieldName.Trim().ToLower())
                        {
                            string fieldValue;

                            switch (field.FormFieldType)
                            {
                                case FormFieldTypes.SumField:
                                case FormFieldTypes.CellField:
                                    fieldValue = values[i].Trim();
                                    double doubleVal;
                                    if (double.TryParse(fieldValue, out doubleVal))
                                    {
                                        field.FieldValue = doubleVal.ToString(CultureInfo.InvariantCulture);
                                    }
                                    break;
                                case FormFieldTypes.Calendar:
                                    fieldValue = values[i].Trim();

                                    //validate dates to ensure they match one of the supplied formats
                                    if (!string.IsNullOrEmpty(fieldValue))
                                    {
                                        DateTime dateVal;

                                        string[] dateFormats = _profile.DateTimeFormat.Split(',');

                                        if (DateTime.TryParseExact(fieldValue, dateFormats, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out dateVal))
                                        {
                                            //store date value in string using ISO 8601 date format
                                            //iso 8601 is 
                                            field.FieldValue = dateVal.ToString("O");
                                        }
                                        else
                                        {
                                            throw new InvalidDataException(string.Format("DateTime Value {0} does not match Date Time Format String {1}", fieldValue, _profile.DateTimeFormat));
                                        }
                                    }
                                    else
                                    {
                                        field.FieldValue = "";
                                    }

                                    break;
                                default:
                                    fieldValue = Regex.Replace(values[i].Trim(), _vault.VaultConfiguration.RegularExpressionRules.FolderNameReplaceRegEx, "");
                                    field.FieldValue = fieldValue.Trim();
                                    break;
                            }

                            break;
                        }
                    }
                }

                //save the form intance
                vvForm.SaveForm();

                _createCount++;
            }

            return vvForm;
        }

        private Form UpdateFormInstance(Form existingFormInstance, string[] columnNames, string[] values)
        {
            var fieldCount = columnNames.Length;

            var vvForm = existingFormInstance;

            if (fieldCount > 0 && existingFormInstance != null)
            {
                var changesDetected = false;

                //determine if any field values have changed

                for (var i = 0; i < fieldCount; i += 1)
                {
                    foreach (FormField field in vvForm.FormFields)
                    {
                        if (columnNames[i].Trim().ToLower() == field.FieldName.ToLower())
                        {
                            if (field.FieldValue != values[i])
                            {
                                changesDetected = true;
                            }
                            break;
                        }
                    }

                    if (changesDetected) break;
                }

                if (changesDetected)
                {
                    vvForm = existingFormInstance.GetNewDataInstanceRevision();

                    //populate new revision of the form data instance with values

                    for (var i = 0; i < fieldCount; i += 1)
                    {
                        foreach (FormField field in vvForm.FormFields)
                        {
                            if (columnNames[i].Trim().ToLower() == field.FieldName.Trim().ToLower())
                            {
                                string fieldValue;

                                switch (field.FormFieldType)
                                {
                                    case FormFieldTypes.SumField:
                                    case FormFieldTypes.CellField:
                                        fieldValue = values[i].Trim();
                                        double doubleVal;
                                        if (double.TryParse(fieldValue, out doubleVal))
                                        {
                                            field.FieldValue = doubleVal.ToString(CultureInfo.InvariantCulture);
                                        }
                                        break;
                                    case FormFieldTypes.Calendar:
                                        fieldValue = values[i].Trim();
                                        DateTime dateVal;

                                        string[] dateFormats = _profile.DateTimeFormat.Split(',');

                                        if (DateTime.TryParseExact(fieldValue, dateFormats, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out dateVal))
                                        {
                                            //store date value in string using ISO 8601 date format
                                            field.FieldValue = dateVal.ToString("O");
                                        }
                                        else
                                        {
                                            throw new Exception("Invalid DateTime");
                                        }

                                        break;
                                    default:
                                        fieldValue = Regex.Replace(values[i].Trim(), _vault.VaultConfiguration.RegularExpressionRules.FolderNameReplaceRegEx, "");
                                        field.FieldValue = fieldValue.Trim();
                                        break;
                                }

                                break;
                            }
                        }
                    }

                    //save the form intance
                    vvForm.SaveForm();

                    _updateCount++;
                }
                else
                {
                    _skippedCount++;
                }
            }

            return vvForm;
        }

        private Form CreateFormInstanceRevision(Form existingFormInstance)
        {
            var vvForm = existingFormInstance.GetNewDataInstanceRevision();

            vvForm.SaveForm();

            _updateCount++;

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
