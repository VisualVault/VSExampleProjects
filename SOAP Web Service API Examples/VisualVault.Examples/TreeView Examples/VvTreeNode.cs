using System;
using System.Windows.Forms;

namespace VisualVault.ExamplesCs.TreeView_Examples
{
    class VvTreeNode : TreeNode
    {
        public VvTreeNode(Guid id, string text)
        {
            NodeID = id;
            Text = text;
        }

        public Guid NodeID { get; set; }
    }
}
