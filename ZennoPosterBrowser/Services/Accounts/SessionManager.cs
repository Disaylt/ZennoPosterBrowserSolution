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
        public SessionManager(IZennoPosterProjectModel project)
        {
            _project = project;
        }

        public Configs.BrowserActions LoadAccount()
        {
            BrowserConfig browserConfig = BrowserConfig.Instance;
            if(browserConfig.IsAccountLoad == false 
                && !string.IsNullOrEmpty(browserConfig.CurrentSession)
                && !string.IsNullOrEmpty(browserConfig.PathToSession))
            {
                _project.Profile.Load(browserConfig.PathToSession);
                return Configs.BrowserActions.BrowserWaitUserAction;
            }
            else
            {
                return Configs.BrowserActions.CloseBrowser;
            }
        }
    }
}
