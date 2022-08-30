using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoLab.CommandCenter;
using ZennoPosterBrowser.Configs;
using ZennoPosterBrowser.Logger;
using ZennoPosterBrowser.Services.BrowserActions;
using ZennoPosterBrowser.Services.Logger;

namespace ZennoPosterBrowser.Forms.MainMenu
{
    internal class MainMenuFormBrowserAction : IBrowserAction
    {
        private readonly MainMenuForm _menuForm;
        public MainMenuFormBrowserAction(Instance instance)
        {
            _menuForm = new MainMenuForm(instance);
        }

        public BrowserProjectActions Run()
        {
            try
            {
                _menuForm.Form.ShowDialog();
                return _menuForm.NextAction;
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
