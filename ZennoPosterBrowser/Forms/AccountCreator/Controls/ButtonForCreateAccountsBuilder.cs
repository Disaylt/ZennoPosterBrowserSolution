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

        public override Button GetButton()
        {
            Button button = new Button();
            button.Text = "Создать";
            button.Font = new Font(button.Font.Name, 9f, button.Font.Unit);
            button.Location = new Point(255, 15);
            button.Size = new Size(110, 70);
            return button;
        }
    }
}
