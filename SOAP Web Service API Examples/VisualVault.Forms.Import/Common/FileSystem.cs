using System;

namespace VisualVault.Forms.Import.Common
{
    internal static class FileSystem
    {
        internal static bool IsFileInUse(string filename)
        {

            var isInUse = true;

            try
            {
                var fs = new System.IO.FileStream(filename, System.IO.FileMode.Open, System.IO.FileAccess.ReadWrite, System.IO.FileShare.None);

                if (fs.CanRead)
                {
                    isInUse = false;
                    fs.Close();
                    System.Threading.Thread.Sleep(5 * 1000);//5 second delay
                }
                else
                {
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                var exMessage = ex.Message;
            }

            return isInUse;
        }
    }
}
