using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterBrowser.Configs;
using ZennoPosterBrowser.Logger;
using ZennoPosterBrowser.Services.BrowserActions;
using ZennoPosterBrowser.Services.Logger;

namespace ZennoPosterBrowser.Forms.AccountSelection
{
    internal class AccountSelectionFormBrowserAction : IBrowserAction
    {
        private readonly AccountSelectionForm _accountSelectionForm;
        public AccountSelectionFormBrowserAction()
        {
            _accountSelectionForm = new AccountSelectionForm();
        }

        public BrowserProjectActions Run()
        {
            try
            {
                _accountSelectionForm.Form.ShowDialog();
                return _accountSelectionForm.NextAction;
            }
            catch (Exception ex)
            {
                ErrorMessage errorMessage = new FileErrorMessageBuilder(ex);
                LoggerStorage.Logger.WriteError(errorMessage);
                return BrowserProjectActions.CloseBrowser;
            }
        }
    }
}
