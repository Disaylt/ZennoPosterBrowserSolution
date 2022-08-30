using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoLab.InterfacesLibrary.ProjectModel;
using ZennoPosterBrowser.Configs;
using ZennoPosterBrowser.Logger;
using ZennoPosterBrowser.Services.BrowserActions;
using ZennoPosterBrowser.Services.Logger;

namespace ZennoPosterBrowser.Forms.AccountCreator
{
    internal class AccountCreatorFormBrowserAction : IBrowserAction
    {
        private readonly AccountCreatorForm _accountCreatorForm;
        public AccountCreatorFormBrowserAction(IZennoPosterProjectModel project)
        {
            _accountCreatorForm = new AccountCreatorForm(project);
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
                LoggerStorage.Logger.WriteError(errorMessage);
                return BrowserProjectActions.CloseBrowser;
            }
        }
    }
}
