using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZennoPosterBrowser.Forms.BaseControls;

namespace ZennoPosterBrowser.Forms.Bookmarks.Controls
{
    internal class BookmarkNameTextBox : TextBoxBuilder
    {
        public override TextBox GetTextBox()
        {
            TextBox textBox = new TextBox();
            textBox.Location = new System.Drawing.Point(15, 15);
            textBox.Name = "bookmarkName";
            textBox.Size = new System.Drawing.Size(260, 20);
            return textBox;
        }

    }
}
