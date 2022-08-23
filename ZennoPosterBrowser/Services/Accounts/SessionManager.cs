using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoLab.InterfacesLibrary.ProjectModel;
using ZennoPosterBrowser.Configs;
using ZennoPosterBrowser.Services.BrowserActions;

namespace ZennoPosterBrowser.Services.Accounts
{
    internal class SessionManager
    {
        private readonly IZennoPosterProjectModel _project;
        private bool _isLoad;
        public SessionManager(IZennoPosterProjectModel project)
        {
            _project = project;
            _isLoad = false;
        }

        public BrowserProjectActions LoadAccount()
        {
            BrowserConfig browserConfig = BrowserConfig.Instance;
            if(!string.IsNullOrEmpty(browserConfig.CurrentSession)
                && !string.IsNullOrEmpty(browserConfig.PathToSession)
                && _isLoad == false)
            {
                _project.Profile.Load($"{browserConfig.PathToSession}{browserConfig.CurrentSession}");
                _isLoad = true;
                return BrowserProjectActions.OpenMenu;
            }
            else if(_isLoad)
            {
                return BrowserProjectActions.OpenMenu;
            }
            else
            {
                return BrowserProjectActions.CloseBrowser;
            }
        }

        public void SaveAccount()
        {
            if(_isLoad)
            {
                BrowserConfig browserConfig = BrowserConfig.Instance;
                _project.Profile.Save($"{browserConfig.PathToSession}{browserConfig.CurrentSession}",
                    false,
                    true,
                    true,
                    false,
                    false,
                    true,
                    true,
                    true,
                    true);
            }
        }
    }
}
