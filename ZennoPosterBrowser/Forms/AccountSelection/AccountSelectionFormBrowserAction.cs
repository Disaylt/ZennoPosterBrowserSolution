using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterBrowser.Services.BrowserActions;

namespace ZennoPosterBrowser.Forms.AccountSelection
{
    internal class AccountSelectionFormBrowserAction : IBrowserAction
    {
        private readonly AccountSelectionForm _accountSelectionForm;
        public AccountSelectionFormBrowserAction()
        {
            _accountSelectionForm = new AccountSelectionForm();
        }

        public Configs.BrowserActions Run()
        {
            try
            {
                _accountSelectionForm.Form.ShowDialog();
                return Configs.BrowserActions.LoadingSession;
            }
            catch (Exception)
            {
                return Configs.BrowserActions.CloseBrowser;
            }
        }
    }
}
