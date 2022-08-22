using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoLab.CommandCenter;
using ZennoLab.InterfacesLibrary.ProjectModel;
using ZennoPosterBrowser.Configs;
using ZennoPosterBrowser.Forms.AccountSelection;
using ZennoPosterBrowser.Services.Accounts;

namespace ZennoPosterBrowser.Services.BrowserActions
{
    internal delegate IBrowserAction GetBrowserAction();
    internal class BrowserActionsManager
    {
        private readonly Dictionary<Configs.BrowserActions, GetBrowserAction> _actions;
        private readonly Instance _instance;
        private readonly IZennoPosterProjectModel _project;

        public BrowserActionsManager(Instance instance, IZennoPosterProjectModel project)
        {
            _actions = new Dictionary<Configs.BrowserActions, GetBrowserAction>();
            _instance = instance;
            _project = project;
            AddActions();
        }

        public void ExecuteActions()
        {
            try
            {
                var currentAction = Configs.BrowserActions.SelectionSession;
                do
                {
                    IBrowserAction browserAction = _actions[currentAction].Invoke();
                    currentAction = browserAction.Run();
                }
                while (currentAction != Configs.BrowserActions.CloseBrowser);
            }
            catch(Exception)
            {

            }
        }

        private void AddActions()
        {
            _actions.Add(Configs.BrowserActions.SelectionSession, () => new AccountSelectionFormBrowserAction());
            _actions.Add(Configs.BrowserActions.LoadingSession, () => new SessionLoader(_project));
        }
    }
}
