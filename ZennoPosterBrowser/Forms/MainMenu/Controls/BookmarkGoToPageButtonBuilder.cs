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
    internal class BookmarkGoToPageButtonBuilder : ButtonBuilder
    {
        private readonly Point _location;
        public BookmarkGoToPageButtonBuilder(Point location)
        {
            _location = location;
        }
        public override Button Create()
        {
            Button button = new Button();
            button.Text = "Перейти";
            button.Font = new Font(button.Font.Name, 9f, button.Font.Unit);
            button.Location = _location;
            button.Size = new Size(110, 20);
            return button;
        }
    }
}
