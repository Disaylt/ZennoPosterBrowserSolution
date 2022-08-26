using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterBrowser.Configs;
using ZennoPosterBrowser.Services.BrowserActions;

namespace ZennoPosterBrowser.Forms.AccountCreator
{
    internal class AccountCreatorFormBrowserAction : IBrowserAction
    {
        private AccountCreatorForm _accountCreatorForm;
        public AccountCreatorFormBrowserAction()
        {
            _accountCreatorForm = new AccountCreatorForm();
        }

        public BrowserProjectActions Run()
        {
            try
            {
                _accountCreatorForm.Form.ShowDialog();
                return _accountCreatorForm.NextAction;
            }
            catch (Exception)
            {
                return BrowserProjectActions.CloseBrowser;
            }
        }
    }
}
