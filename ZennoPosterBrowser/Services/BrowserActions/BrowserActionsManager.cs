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
            AddActionsExcecutor();
        }

        public void ExecuteActions()
        {
            try
            {
                var nextAction = Configs.BrowserActions.SelectionSession;
                do
                {
                    nextAction = ExecuteCurrentActionAndReturnNextAction(nextAction);
                }
                while (nextAction != Configs.BrowserActions.CloseBrowser);
            }
            catch(Exception)
            {

            }
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

        private void AddActionsExcecutor()
        {
            _actionsExecutor.Add(Configs.BrowserActions.SelectionSession, () => new AccountSelectionFormBrowserAction());
            _actionsExecutor.Add(Configs.BrowserActions.LoadingSession, () => new SessionLoader(_project));
        }
    }
}
