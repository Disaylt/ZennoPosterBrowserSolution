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
        public BookmarkGoToPageButtonBuilder(Point location)
        {
            SetSettings(location);
        }

        public override Button GetButton()
        {
            return Control;
        }

        private void SetSettings(Point location)
        {
            Control.Text = "Перейти";
            Control.Font = new Font(Control.Font.Name, 9f, Control.Font.Unit);
            Control.Location = location;
            Control.Size = new Size(110, 20);
        }
    }
}
