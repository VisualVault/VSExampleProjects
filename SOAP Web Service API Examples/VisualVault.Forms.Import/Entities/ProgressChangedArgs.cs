using System;

namespace VisualVault.Forms.Import.Entities
{
    public class ProgressChangedArgs : EventArgs
    {
        public ProgressStatus ImportStatus {get;set;}

        public int TotalItems { get; set; }

        public string ProgressMessage { get; set; }

        public string ErrorMessage { get; set; }
    }
}
