using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterBrowser.Configs;
using ZennoPosterBrowser.Services.BrowserActions;

namespace ZennoPosterBrowser.Forms.MainMenu
{
    internal class MainMenuFormBrowserAction : IBrowserAction
    {
        private readonly MainMenuForm _menuForm;
        public MainMenuFormBrowserAction()
        {
            _menuForm = new MainMenuForm();
        }

        public BrowserProjectActions Run()
        {
            try
            {
                _menuForm.Form.ShowDialog();
                return _menuForm.NextAction;
            }
            catch (Exception)
            {
                return BrowserProjectActions.CloseBrowser;
            }
        }
    }
}
