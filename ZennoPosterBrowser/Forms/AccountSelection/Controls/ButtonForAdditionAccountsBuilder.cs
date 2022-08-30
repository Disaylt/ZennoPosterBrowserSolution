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
    internal class ButtonForAdditionAccountsBuilder : ButtonBuilder
    {
        public override Button GetButton()
        {
            Button button = new Button();
            button.Text = "Создать аккаунт";
            button.Font = new Font(button.Font.Name, 9f, button.Font.Unit);
            button.Location = new Point(15, 350);
            button.Size = new Size(350, 40);
            return button;
        }
    }
}
