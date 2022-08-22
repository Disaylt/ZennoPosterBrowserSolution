using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterBrowser.Forms.Base;

namespace ZennoPosterBrowser.Forms.MainMenu
{
    internal class MenuForm : BaseForm
    {
        private const string _nameForm = "Главное меню";
        public MenuForm()
        {
            NextAction = Configs.BrowserProjectActions.CloseBrowser;
            Form.Size = new Size(400, 500);
            Form.Name = _nameForm;
        }
        public Configs.BrowserProjectActions NextAction { get; set; }
    }
}
