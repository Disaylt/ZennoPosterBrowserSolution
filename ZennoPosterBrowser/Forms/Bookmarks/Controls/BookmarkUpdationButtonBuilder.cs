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
    internal class BookmarkUpdationButtonBuilder : ButtonBuilder
    {
        public BookmarkUpdationButtonBuilder()
        {
            SetSettings();
        }

        public override Button GetButton()
        {
            return Control;
        }

        private void SetSettings()
        {
            Control.Text = "Обновить";
            Control.Name = "AddBookmark";
            Control.Font = new Font(Control.Font.Name, 9f, Control.Font.Unit);
            Control.Location = new Point(280, 140);
            Control.Size = new Size(95, 40);
        }
    }
}
