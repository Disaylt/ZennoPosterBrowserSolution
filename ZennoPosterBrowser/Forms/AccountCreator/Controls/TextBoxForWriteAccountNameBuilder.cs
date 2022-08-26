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
        public override TextBox Create()
        {
            TextBox textBoxSearch = new TextBox();
            textBoxSearch.Location = new System.Drawing.Point(15, 15);
            textBoxSearch.Size = new System.Drawing.Size(230, 20);
            return textBoxSearch;
        }
    }
}
