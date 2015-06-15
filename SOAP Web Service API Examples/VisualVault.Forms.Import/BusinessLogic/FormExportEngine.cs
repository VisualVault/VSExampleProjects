using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using VVRuntime.VisualVault;
using VVRuntime.VisualVault.Forms;
using VisualVault.Forms.Import.Entities;
using VVRuntime.VisualVault.Library.Documents;


namespace VisualVault.Forms.Import.BusinessLogic
{
    internal class FormExportEngine
    {
        #region Fields

        internal delegate void ProgressChanged(object sender, ProgressChangedArgs args);

        internal event ProgressChanged OnProgressChanged;

        private readonly FormDashboard _sourceFormDashboard;

        private readonly Vault _vault;

        private readonly string _csvFilePath;

        private readonly bool _exportRelatedDocs;

        private int _rowCount;

        #endregion

        internal FormExportEngine(string filePath, FormDashboard dashboard, Vault vaultApiObject, bool exportRelatedDocs)
        {
            _csvFilePath = filePath;

            _sourceFormDashboard = dashboard;

            _vault = vaultApiObject;

            _exportRelatedDocs = exportRelatedDocs;
        }

        #region Form Export Methods

        internal void ExportFormData()
        {
            try
            {

                _rowCount = 0;

                if (_sourceFormDashboard != null)
                {
                    var formInstancesDataTable = _sourceFormDashboard.GetExportDataAsDataTable();

                    _rowCount = formInstancesDataTable.Rows.Count;

                    var statusMessage = string.Format("Starting export of {0} forms...", _rowCount);

                    InvokeOnProgressChanged(new ProgressChangedArgs
                    {
                        TotalItems = _rowCount,
                        ProgressMessage = statusMessage,
                        ErrorMessage = "",
                        ImportStatus = ProgressStatus.Starting
                    });

                    //write data table contents to CSV file
                    using (TextWriter textWriter = new StreamWriter(_csvFilePath, false))
                    {
                        WriteToStream(textWriter, formInstancesDataTable, true, false);

                        textWriter.Flush();
                        textWriter.Close();
                    }

                    if (_exportRelatedDocs)
                    {
                        ExportRelatedFormDocuments(formInstancesDataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                const string statusMessage = "Unexpected error";
                InvokeOnProgressChanged(new ProgressChangedArgs { TotalItems = 0, ProgressMessage = statusMessage, ErrorMessage = ex.Message, ImportStatus = ProgressStatus.Processing });
            }
        }

        public void WriteToStream(TextWriter textWriter, DataTable table, bool header, bool quoteall)
        {
            var rowsProcessed = 1;

            string statusMessage;

            if (header)
            {
                for (var i = 0; i < table.Columns.Count; i++)
                {
                    WriteItem(textWriter, table.Columns[i].Caption, quoteall);
                    textWriter.Write(i < table.Columns.Count - 1 ? ',' : '\n');
                }
            }
            foreach (DataRow row in table.Rows)
            {
                statusMessage = string.Format("Exporting form {0} of {1}", rowsProcessed, _rowCount);

                InvokeOnProgressChanged(new ProgressChangedArgs
                {
                    TotalItems = _rowCount,
                    ProgressMessage = statusMessage,
                    ErrorMessage = "",
                    ImportStatus = ProgressStatus.Processing
                });

                for (var i = 0; i < table.Columns.Count; i++)
                {
                    WriteItem(textWriter, row[i], quoteall);
                    textWriter.Write(i < table.Columns.Count - 1 ? ',' : '\n');
                }

                rowsProcessed++;
            }

            statusMessage = string.Format("Exported {0} of {1} forms", rowsProcessed - 1, _rowCount);

            InvokeOnProgressChanged(new ProgressChangedArgs
            {
                TotalItems = _rowCount,
                ProgressMessage = statusMessage,
                ErrorMessage = "",
                ImportStatus = ProgressStatus.Completed
            });
        }

        private static void WriteItem(TextWriter stream, object item, bool quoteall)
        {
            if (item == null)
                return;
            var s = item.ToString();
            if (quoteall || s.IndexOfAny("\",\x0A\x0D".ToCharArray()) > -1)
                stream.Write("\"" + s.Replace("\"", "\"\"") + "\"");
            else
                stream.Write(s);
        }

        internal void InvokeOnProgressChanged(ProgressChangedArgs args)
        {
            var handler = OnProgressChanged;
            if (handler != null) handler(this, args);
        }

        #endregion

        #region File Export

        private void ExportRelatedFormDocuments(DataTable dt)
        {
            //iterate data table and export documents associated with each form
            int rowsProcessed = 1;

            foreach (DataRow dr in dt.Rows)
            {
                string statusMessage = string.Format("Exporting documents related to form {0} of {1}",
                    rowsProcessed, _rowCount);

                InvokeOnProgressChanged(new ProgressChangedArgs
                {
                    TotalItems = _rowCount,
                    ProgressMessage = statusMessage,
                    ErrorMessage = "",
                    ImportStatus = ProgressStatus.Processing
                });

                if (dt.Columns.Contains("Form ID"))
                {
                    string formId = (string)dr["Form ID"];

                    //get related documents
                    VVRuntime.VisualVault.Forms.Form formDataInstance =
                        _vault.Forms.GetFormDataInstance(formId);

                    if (formDataInstance != null)
                    {
                        DocumentCollection documentCollection = formDataInstance.GetFormDocuments();

                        foreach (DocumentBase documentBase in documentCollection)
                        {
                            //document base is a light weight DTO, need to instantiate Document object
                            Document document = _vault.DefaultStore.Library.GetDocument(documentBase.DocID,
                                DocumentLatestState.Latest);

                            //save document files to the path where the CSV file was saved

                            //get the csv file folder path
                            string filePath = Path.GetDirectoryName(_csvFilePath);

                            SaveDocumentFile(document, filePath, formId);
                        }
                    }

                }

                rowsProcessed++;
            }
        }

        private void SaveDocumentFile(Document documentRevision, string saveToPath, string formId)
        {
            try
            {
                //if folderpath does not exist then create it
                CreateFolderPath(saveToPath);

                //prefix file name with the related Form ID
                string fileName = String.Format("{0}_{1}.{2}", formId, documentRevision.Filename, documentRevision.Extension);

                string filePath = Path.Combine(saveToPath, fileName);

                //if file name exists, append with integer
                var i = 0;
                while (File.Exists(filePath))
                {
                    i++;
                    fileName = String.Format("{0}_{1}({2}).{3}", formId, documentRevision.Filename, i, documentRevision.Extension);
                    filePath = Path.Combine(saveToPath, fileName);
                }

                using (var sourceStream = documentRevision.GetStream())
                {
                    CreateFileFromStream(sourceStream, 1, filePath);
                }

            }
            catch (Exception ex)
            {
                var message = "Exception in SaveDocumentFile: " + ex.Message + " Source Document: " + documentRevision.FolderPath + @"\" + documentRevision.DocID;
            }
        }

        private static void CreateFolderPath(string folderPath)
        {
            //if path does not exist create

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }

        private FileInfo CreateFileFromStream(Stream sourceFileStream, int maxRetryCount, string targetFileFullPath)
        {
            int retryCount = 0;
            while (retryCount <= maxRetryCount)
            {
                retryCount++;
                bool isError = true;

                try
                {
                    for (int i = 1; i <= maxRetryCount; i++)
                    {
                        try
                        {
                            if (File.Exists(targetFileFullPath))
                            {
                                File.Delete(targetFileFullPath);
                            }
                        }
                        catch (Exception ex)
                        {
                            //do something
                        }

                        if (!File.Exists(targetFileFullPath))
                        {
                            break;
                        }
                        else
                        {
                            const int sleepTime = 2;
                            Thread.Sleep(sleepTime * 1000);
                        }
                    }

                    if (!File.Exists(targetFileFullPath))
                    {
                        if (sourceFileStream != null)
                        {
                            using (var targetFileStream = new FileStream(targetFileFullPath, FileMode.OpenOrCreate, FileAccess.Write))
                            {
                                using (BinaryWriter targetWriter = new BinaryWriter(targetFileStream))
                                {
                                    byte[] buffer = new byte[4096];
                                    int bytesRead;
                                    while ((bytesRead = sourceFileStream.Read(buffer, 0, buffer.Length)) > 0)
                                    {
                                        targetWriter.Write(buffer, 0, bytesRead);
                                    }

                                    isError = false;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    isError = true;
                }

                if (isError == false)
                {
                    break;
                }
                else
                {
                    const int sleepTime = 2;
                    Thread.Sleep(sleepTime * 1000);
                }
            }

            return new FileInfo(targetFileFullPath);
        }

        #endregion
    }
}
