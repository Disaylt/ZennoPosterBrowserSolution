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
using ZennoPosterBrowser.Services.ZennoPosterBrowser;

namespace ZennoPosterBrowser.Services.BrowserActions
{
    internal delegate IBrowserAction GetBrowserActionExecutor();
    internal delegate Configs.BrowserActions GetBrowserAction();
    internal class BrowserActionsManager
    {
        private readonly Dictionary<Configs.BrowserActions, GetBrowserActionExecutor> _actionsExecutor;
        private readonly Dictionary<Configs.BrowserActions, GetBrowserAction> _actions;
        private readonly Instance _instance;
        private readonly IZennoPosterProjectModel _project;

        public BrowserActionsManager(Instance instance, IZennoPosterProjectModel project)
        {
            _actionsExecutor = new Dictionary<Configs.BrowserActions, GetBrowserActionExecutor>();
            _actions = new Dictionary<Configs.BrowserActions, GetBrowserAction>();
            _instance = instance;
            _project = project;
            FillActionsExcecutor();
            FillActions();
        }

        public void ExecuteActions()
        {
            var nextAction = Configs.BrowserActions.SelectionSession;
            do
            {
                nextAction = ExecuteCurrentActionAndReturnNextAction(nextAction);
            }
            while (nextAction != Configs.BrowserActions.CloseBrowser);
        }

        private Configs.BrowserActions ExecuteCurrentActionAndReturnNextAction(Configs.BrowserActions currentAction)
        {
            if(_actions.ContainsKey(currentAction))
            {
                var nextAction = _actions[currentAction].Invoke();
                return nextAction;
            }
            if(_actionsExecutor.ContainsKey(currentAction))
            {
                var browserActionHandler = _actionsExecutor[currentAction].Invoke();
                var nextAction = browserActionHandler.Run();
                return nextAction;
            }
            throw new Exception($"Action {currentAction} not exists!");
        }

        private void FillActionsExcecutor()
        {
            _actionsExecutor.Add(Configs.BrowserActions.SelectionSession, () => new AccountSelectionFormBrowserAction());
        }

        private void FillActions()
        {
            var sessionManager = new SessionManager(_project);
            _actions.Add(Configs.BrowserActions.LoadingSession, sessionManager.LoadAccount);

            var zennposterActionManager = new ZennoPosterBrowserManager(_instance);
            _actions.Add(Configs.BrowserActions.BrowserWaitUserAction, zennposterActionManager.WaitUserAction);
        }
    }
}
