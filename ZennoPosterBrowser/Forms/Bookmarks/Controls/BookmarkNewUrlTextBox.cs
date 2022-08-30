using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZennoPosterBrowser.Forms.BaseControls;

namespace ZennoPosterBrowser.Forms.Bookmarks.Controls
{
    internal class BookmarkNewUrlTextBox : TextBoxBuilder
    {
        public BookmarkNewUrlTextBox()
        {
            SetSettings();
        }

        public override TextBox GetTextBox()
        {
            
            return Control;
        }

        private void SetSettings()
        {
            Control.Location = new System.Drawing.Point(15, 45);
            Control.Name = "bookmarkUrl";
            Control.Multiline = true;
            Control.Size = new System.Drawing.Size(260, 60);
        }
    }
}
