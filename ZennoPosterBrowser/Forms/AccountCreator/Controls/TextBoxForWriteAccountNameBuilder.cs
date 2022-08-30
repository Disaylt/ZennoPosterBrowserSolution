using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZennoPosterBrowser.Forms.BaseControls;

namespace ZennoPosterBrowser.Forms.AccountCreator.Controls
{
    internal class TextBoxForWriteAccountNameBuilder : TextBoxBuilder
    {
        public TextBoxForWriteAccountNameBuilder()
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
            Control.Size = new System.Drawing.Size(230, 20);
        }
    }
}
