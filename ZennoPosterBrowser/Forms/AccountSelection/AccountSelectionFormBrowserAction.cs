using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterBrowser.Configs;
using ZennoPosterBrowser.Logger;
using ZennoPosterBrowser.Services.BrowserActions;

namespace ZennoPosterBrowser.Forms.AccountSelection
{
    internal class AccountSelectionFormBrowserAction : IBrowserAction
    {
        private readonly AccountSelectionForm _accountSelectionForm;
        private readonly ILogger<InfoMessage, ErrorMessage> _logger;
        public AccountSelectionFormBrowserAction()
        {
            _accountSelectionForm = new AccountSelectionForm();
            _logger = BaseConfig.Instance.Logger;
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
                _logger.WriteError(errorMessage);
                return BrowserProjectActions.CloseBrowser;
            }
        }
    }
}
