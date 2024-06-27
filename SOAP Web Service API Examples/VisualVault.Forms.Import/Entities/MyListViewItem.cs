using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualVault.Forms.Import.Entities
{
    public class MyListViewItem : System.Windows.Forms.ListViewItem
    {
        public Guid ListViewItemId;

        public MyListViewItem(Guid id, string text)
        {
            ListViewItemId = id;
            this.Text = text;
        }
    }
}
