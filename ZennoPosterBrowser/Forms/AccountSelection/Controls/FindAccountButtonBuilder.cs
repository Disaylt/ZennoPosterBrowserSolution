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
        public override Button Create()
        {
            Button button = new Button();
            button.Text = "Поиск";
            button.Name = "FindAccount";
            button.Font = new Font(button.Font.Name, 9f, button.Font.Unit);
            button.Location = new Point(150, 15);
            button.Size = new Size(55, 20);
            return button;
        }
    }
}
