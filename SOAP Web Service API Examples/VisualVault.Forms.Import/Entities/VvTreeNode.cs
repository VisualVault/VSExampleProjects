using System;


namespace VisualVault.Forms.Import.Entities
{
    public class VvTreeNode : System.Windows.Forms.TreeNode
    {
        public Guid NodeId;

        public VvTreeNode(Guid id, string text)
        {
            NodeId = id;
            this.Text = text;
        }
    }
}
