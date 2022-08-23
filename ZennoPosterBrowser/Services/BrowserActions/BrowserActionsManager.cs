using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoLab.CommandCenter;
using ZennoLab.InterfacesLibrary.ProjectModel;
using ZennoPosterBrowser.Configs;
using ZennoPosterBrowser.Forms.AccountSelection;
using ZennoPosterBrowser.Forms.MainMenu;
using ZennoPosterBrowser.Services.Accounts;
using ZennoPosterBrowser.Services.ZennoPosterBrowser;

namespace ZennoPosterBrowser.Services.BrowserActions
{
    internal delegate IBrowserAction GetObjectActionExecutor();
    internal delegate BrowserProjectActions GetActionExecutor();
    internal class BrowserActionsManager
    {
        private readonly Dictionary<BrowserProjectActions, GetObjectActionExecutor> _objectsActionExecutor;
        private readonly Dictionary<BrowserProjectActions, GetActionExecutor> _executors;
        private readonly Instance _instance;
        private readonly IZennoPosterProjectModel _project;

        public BrowserActionsManager(Instance instance, IZennoPosterProjectModel project)
        {
            _objectsActionExecutor = new Dictionary<BrowserProjectActions, GetObjectActionExecutor>();
            _executors = new Dictionary<BrowserProjectActions, GetActionExecutor>();
            _instance = instance;
            _project = project;
            FillActionsExcecutor();
            FillActions();
        }

        public void ExecuteActions()
        {
            var nextAction = BrowserProjectActions.SelectionSession;
            do
            {
                nextAction = ExecuteCurrentActionAndReturnNextAction(nextAction);
            }
            while (nextAction != BrowserProjectActions.CloseBrowser);
        }

        public void AddService(BrowserProjectActions action, GetActionExecutor executor)
        {
            _executors.Add(action, executor);
        }

        public void AddService(BrowserProjectActions action, GetObjectActionExecutor objectExecutor)
        {
            _objectsActionExecutor.Add(action, objectExecutor);
        }

        private BrowserProjectActions ExecuteCurrentActionAndReturnNextAction(BrowserProjectActions currentAction)
        {
            if(_executors.ContainsKey(currentAction))
            {
                var nextAction = _executors[currentAction].Invoke();
                return nextAction;
            }
            if(_objectsActionExecutor.ContainsKey(currentAction))
            {
                var browserActionHandler = _objectsActionExecutor[currentAction].Invoke();
                var nextAction = browserActionHandler.Run();
                return nextAction;
            }
            throw new Exception($"Action {currentAction} not exists!");
        }

        private void FillActionsExcecutor()
        {
            _objectsActionExecutor.Add(BrowserProjectActions.SelectionSession, () => new AccountSelectionFormBrowserAction());
            _objectsActionExecutor.Add(BrowserProjectActions.OpenMenu, () => new MenuFormBrowserAction());
        }

        private void FillActions()
        {
            var sessionManager = new SessionManager(_project);
            _executors.Add(BrowserProjectActions.LoadingSession, sessionManager.LoadAccount);

            var zennposterActionManager = new ZennoPosterBrowserManager(_instance);
            _executors.Add(BrowserProjectActions.BrowserWaitUserAction, zennposterActionManager.WaitUserAction);
        }
    }
}
