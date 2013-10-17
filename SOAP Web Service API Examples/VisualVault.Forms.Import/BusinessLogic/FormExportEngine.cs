using System;
using System.Data;
using System.IO;
using VVRuntime.VisualVault.Forms;
using VisualVault.Forms.Import.Entities;


namespace VisualVault.Forms.Import.BusinessLogic
{
    internal class FormExportEngine
    {
        #region Fields

        internal delegate void ProgressChanged(object sender, ProgressChangedArgs args);

        internal event ProgressChanged OnProgressChanged;

        private readonly FormDashboard _sourceFormDashboard;

        private readonly string _csvFilePath;
        
        private int _rowCount;

        #endregion

        internal FormExportEngine(string filePath, FormDashboard dashboard)
        {
            _csvFilePath = filePath;

            _sourceFormDashboard = dashboard;
        }

        #region Methods

        internal void ExportFormData()
        {
            try
            {

                _rowCount = 0;

                if (_sourceFormDashboard != null)
                {
                    var dt = _sourceFormDashboard.GetExportDataAsDataTable();

                    _rowCount = dt.Rows.Count;

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
                        WriteToStream(textWriter, dt, true, false);

                        textWriter.Flush();
                        textWriter.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                const string statusMessage = "Unexpected error";
                InvokeOnProgressChanged(new ProgressChangedArgs { TotalItems = 0, ProgressMessage = statusMessage, ErrorMessage = ex.Message, ImportStatus = ProgressStatus.Processing});
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

            statusMessage = string.Format("Exported {0} of {1} forms", rowsProcessed-1, _rowCount);

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
    }
}
