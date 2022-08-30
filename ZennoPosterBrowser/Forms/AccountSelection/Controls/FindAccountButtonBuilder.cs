using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZennoPosterBrowser.Forms.BaseControls;

namespace ZennoPosterBrowser.Forms.AccountSelection.Controls
{
    internal class FindAccountButtonBuilder : ButtonBuilder
    {
        public FindAccountButtonBuilder()
        {
            SetSettings();
        }

        public override Button GetButton()
        {
            return Control;
        }

        private void SetSettings()
        {
            Control.Text = "Поиск";
            Control.Name = "FindAccount";
            Control.Font = new Font(Control.Font.Name, 9f, Control.Font.Unit);
            Control.Location = new Point(150, 15);
            Control.Size = new Size(55, 20);
        }
    }
}
