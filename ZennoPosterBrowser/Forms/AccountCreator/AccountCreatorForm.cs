using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterBrowser.Configs;
using ZennoPosterBrowser.Forms.Base;

namespace ZennoPosterBrowser.Forms.AccountCreator
{
    internal class AccountCreatorForm : BaseForm
    {
        private const string _nameForm = "Добавление аккаунта";

        public AccountCreatorForm()
        {
            NextAction = BrowserProjectActions.CloseBrowser;
            Form.Size = new Size(400, 500);
            Form.Name = _nameForm;
            FormControls = new AccountCreatorFormControls();
            AddControls(FormControls);
        }
        public BrowserProjectActions NextAction { get; set; }
        public AccountCreatorFormControls FormControls { get; }
    }
}