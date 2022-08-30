using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZennoPosterBrowser.Forms.BaseControls;

namespace ZennoPosterBrowser.Forms.AccountCreator.Controls
{
    internal class ButtonForCreateAccountsBuilder : ButtonBuilder
    {
        public ButtonForCreateAccountsBuilder()
        {
            SetSettings();
        }

        public override Button GetButton()
        {
            return Control;
        }

        private void SetSettings()
        {
            Control.Text = "Создать";
            Control.Font = new Font(Control.Font.Name, 9f, Control.Font.Unit);
            Control.Location = new Point(255, 15);
            Control.Size = new Size(110, 70);
        }
    }
}
