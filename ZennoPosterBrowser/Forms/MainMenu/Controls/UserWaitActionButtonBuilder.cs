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
    internal class UserWaitActionButtonBuilder : ButtonBuilder
    {
        public UserWaitActionButtonBuilder()
        {
            SetSettings();
        }

        public override Button GetButton()
        {
            return Control;
        }

        private void SetSettings()
        {
            Control.Text = "Свободные\nдействия";
            Control.Name = "FreeAction";
            Control.Font = new Font(Control.Font.Name, 9f, Control.Font.Unit);
            Control.Location = new Point(15, 15);
            Control.Size = new Size(110, 40);
        }
    }
}
