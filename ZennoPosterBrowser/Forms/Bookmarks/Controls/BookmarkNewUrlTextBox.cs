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
        public override TextBox Create()
        {
            TextBox textBoxSearch = new TextBox();
            textBoxSearch.Location = new System.Drawing.Point(15, 45);
            textBoxSearch.Name = "bookmarkUrl";
            textBoxSearch.Multiline = true;
            textBoxSearch.Size = new System.Drawing.Size(260, 60);
            return textBoxSearch;
        }
    }
}
