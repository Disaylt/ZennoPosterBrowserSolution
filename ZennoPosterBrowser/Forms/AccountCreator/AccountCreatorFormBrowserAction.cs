using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoLab.InterfacesLibrary.ProjectModel;
using ZennoPosterBrowser.Configs;
using ZennoPosterBrowser.Logger;
using ZennoPosterBrowser.Services.BrowserActions;

namespace ZennoPosterBrowser.Forms.AccountCreator
{
    internal class AccountCreatorFormBrowserAction : IBrowserAction
    {
        private AccountCreatorForm _accountCreatorForm;
        private ILogger<InfoMessage, ErrorMessage> _logger;
        public AccountCreatorFormBrowserAction(IZennoPosterProjectModel project)
        {
            _accountCreatorForm = new AccountCreatorForm(project);
            _logger = BaseConfig.Instance.Logger;
        }

        public BrowserProjectActions Run()
        {
            try
            {
                _accountCreatorForm.Form.ShowDialog();
                return _accountCreatorForm.NextAction;
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
