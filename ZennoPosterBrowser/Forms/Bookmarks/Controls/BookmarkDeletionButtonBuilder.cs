using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZennoPosterBrowser.Forms.BaseControls;

namespace ZennoPosterBrowser.Forms.Bookmarks.Controls
{
    internal class BookmarkDeletionButtonBuilder : ButtonBuilder
    {
        public override Button Create()
        {
            Button button = new Button();
            button.Text = "Удалить";
            button.Font = new Font(button.Font.Name, 9f, button.Font.Unit);
            button.Location = new Point(280, 190);
            button.Size = new Size(95, 40);
            return button;
        }
    }
}
