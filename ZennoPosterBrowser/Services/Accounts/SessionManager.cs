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
            if (!string.IsNullOrEmpty(browserConfig.CurrentSession)
                && !string.IsNullOrEmpty(browserConfig.PathToSession)
                && _isLoad == false)
            {
                _project.Profile.Load($"{browserConfig.PathToSession}{browserConfig.CurrentSession}.zpprofile");
                _isLoad = true;
                LoggerStorage.Logger.WriteInfo(new FileInfoMessageBuilder($"Load account - {browserConfig.CurrentSession}"));
                return BrowserProjectActions.OpenMenu;
            }
            else if (_isLoad)
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
            if (_isLoad)
            {
                BrowserConfig browserConfig = BrowserConfig.Instance;
                SaveAccount(browserConfig.PathToSession, browserConfig.CurrentSession, _project);
            }
        }

        public static void SaveAccount(string directoryPath, string sessionName, IZennoPosterProjectModel project)
        {
            project.Profile.Save($"{directoryPath}{sessionName}.zpprofile",
                false,
                true,
                true,
                false,
                false,
                true,
                true,
                true,
                true);
            LoggerStorage.Logger.WriteInfo(new FileInfoMessageBuilder($"Save account - {sessionName}"));
        }
    }
}
