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

        private readonly Dictionary<BrowserProjectActions, GetObjectActionExecutor> _firstObjectsActionExecutor;
        private readonly Dictionary<BrowserProjectActions, GetActionExecutor> _firstExecutors;

        private readonly Dictionary<BrowserProjectActions, GetObjectActionExecutor> _lastObjectsActionExecutor;
        private readonly Dictionary<BrowserProjectActions, GetActionExecutor> _lastExecutors;

        public BrowserActionsManager()
        {
            _objectsActionExecutor = new Dictionary<BrowserProjectActions, GetObjectActionExecutor>();
            _executors = new Dictionary<BrowserProjectActions, GetActionExecutor>();

            _firstObjectsActionExecutor = new Dictionary<BrowserProjectActions, GetObjectActionExecutor>();
            _firstExecutors = new Dictionary<BrowserProjectActions, GetActionExecutor>();

            _lastObjectsActionExecutor = new Dictionary<BrowserProjectActions, GetObjectActionExecutor>();
            _lastExecutors = new Dictionary<BrowserProjectActions, GetActionExecutor>();
        }

        public void ExecuteActions(BrowserProjectActions firstAction)
        {
            try
            {
                ExecuteFirstActions();
                var nextAction = firstAction;
                do
                {
                    nextAction = ExecuteCurrentActionAndReturnNextAction(nextAction);
                }
                while (nextAction != BrowserProjectActions.CloseBrowser);
            }
            catch (Exception)
            {

            }
            finally
            {
                ExecuteLastActions();
            }
        }

        public void AddLastServices(BrowserProjectActions action, GetActionExecutor executor)
        {
            _lastExecutors.Add(action, executor);
        }

        public void AddLastServices(BrowserProjectActions action, GetObjectActionExecutor objectExecutor)
        {
            _lastObjectsActionExecutor.Add(action, objectExecutor);
        }

        public void AddFirstServices(BrowserProjectActions action, GetActionExecutor executor)
        {
            _firstExecutors.Add(action, executor);
        }

        public void AddFirstServices(BrowserProjectActions action, GetObjectActionExecutor objectExecutor)
        {
            _firstObjectsActionExecutor.Add(action, objectExecutor);
        }

        public void AddService(BrowserProjectActions action, GetActionExecutor executor)
        {
            _executors.Add(action, executor);
        }

        public void AddService(BrowserProjectActions action, GetObjectActionExecutor objectExecutor)
        {
            _objectsActionExecutor.Add(action, objectExecutor);
        }

        private void ExecuteFirstActions()
        {
            foreach (var action in _firstObjectsActionExecutor)
            {
                try
                {
                    var obj = action.Value.Invoke();
                    obj.Run();
                }
                catch (Exception)
                {

                }
            }
            foreach (var action in _lastExecutors)
            {
                try
                {
                    action.Value.Invoke();
                }
                catch
                {

                }
            }
        }

        private void ExecuteLastActions()
        {
            foreach (var action in _lastObjectsActionExecutor)
            {
                var obj = action.Value.Invoke();
                obj.Run();
            }
            foreach (var action in _firstExecutors)
            {
                action.Value.Invoke();
            }
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
    }
}
