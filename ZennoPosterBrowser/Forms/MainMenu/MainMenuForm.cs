using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterBrowser.Configs;
using ZennoPosterBrowser.Forms.Base;

namespace ZennoPosterBrowser.Forms.MainMenu
{
    internal class MainMenuForm : BaseForm
    {
        private const string _nameForm = "Главное меню";
        private readonly IFormEventHandler _formEventHandler;
        public MainMenuForm()
        {
            FormControls = new MainMenuFormControls();
            _formEventHandler = new MainMenuFormEventHandler(this);
            NextAction = BrowserProjectActions.CloseBrowser;
            Form.Size = new Size(400, 500);
            Form.Name = _nameForm;
            AddControls(FormControls);
            AddEvents(_formEventHandler);
        }
        public IFormControls FormControls { get; }
        public BrowserProjectActions NextAction { get; set; }
    }
}
