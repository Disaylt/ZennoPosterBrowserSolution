using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoLab.InterfacesLibrary.ProjectModel;
using ZennoPosterBrowser.Configs;
using ZennoPosterBrowser.Forms.Base;

namespace ZennoPosterBrowser.Forms.AccountCreator
{
    internal class AccountCreatorForm : BaseForm
    {
        private const string _nameForm = "Добавление аккаунта";
        private readonly AccountCreatorFormEventHandler _accountCreatorFormEvent;
        public AccountCreatorForm(IZennoPosterProjectModel project)
        {
            NextAction = BrowserProjectActions.CloseBrowser;
            _accountCreatorFormEvent = new AccountCreatorFormEventHandler(project, this);
            Form.Size = new Size(400, 250);
            Form.Name = _nameForm;
            FormControls = new AccountCreatorFormControls();
            AddControls(FormControls);
            AddEvents(_accountCreatorFormEvent);
        }

        public BrowserProjectActions NextAction { get; set; }
        public AccountCreatorFormControls FormControls { get; }
    }
}