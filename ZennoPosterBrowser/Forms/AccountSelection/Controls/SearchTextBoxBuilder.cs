using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZennoPosterBrowser.Forms.BaseControls;

namespace ZennoPosterBrowser.Forms.AccountSelection.Controls
{
    internal class SearchTextBoxBuilder : TextBoxBuilder
    {
        public SearchTextBoxBuilder()
        {
            SetSettings();
        }

        public override TextBox GetTextBox()
        {
            return Control;
        }

        private void SetSettings()
        {
            Control.Location = new System.Drawing.Point(15, 15);
            Control.Name = "textBoxSearch";
            Control.Size = new System.Drawing.Size(130, 20);
        }
    }
}
