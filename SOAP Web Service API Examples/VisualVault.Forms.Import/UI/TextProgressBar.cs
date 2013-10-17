using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace VisualVault.Forms.Import.UI
{
    public class TextProgressBar : ProgressBar
    {
        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                // Turn on WS_EX_COMPOSITED    
                return cp;
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 0x000F)
            {
                using (var graphics = CreateGraphics())
                using (var brush = new SolidBrush(ForeColor))
                {
                    var font = new Font("Microsoft Sans Serif",10);
                   
                    SizeF textSize = graphics.MeasureString(Text, font);
                    graphics.DrawString(Text, font, brush, (Width - textSize.Width) / 2, (Height - textSize.Height) / 2);
                }
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                Refresh();
            }
        }
    }

}
