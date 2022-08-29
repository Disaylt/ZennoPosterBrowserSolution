using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZennoPosterBrowser.Forms.BaseControls;

namespace ZennoPosterBrowser.Forms.MainMenu.Controls
{
    internal class BookmarksButtonBuilder : ButtonBuilder
    {
        public override Button Create()
        {
            Button button = new Button();
            button.Text = "Закладки";
            button.Name = "Bookmarks";
            button.Font = new Font(button.Font.Name, 9f, button.Font.Unit);
            button.Location = new Point(255, 15);
            button.Size = new Size(110, 40);
            return button;
        }
    }
}
