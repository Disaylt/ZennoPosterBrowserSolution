﻿using System;
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
    internal delegate IBrowserAction GetBrowserActionExecutor();
    internal delegate BrowserProjectActions GetBrowserAction();
    internal class BrowserActionsManager
    {
        private readonly Dictionary<BrowserProjectActions, GetBrowserActionExecutor> _actionsExecutor;
        private readonly Dictionary<BrowserProjectActions, GetBrowserAction> _actions;
        private readonly Instance _instance;
        private readonly IZennoPosterProjectModel _project;

        public BrowserActionsManager(Instance instance, IZennoPosterProjectModel project)
        {
            _actionsExecutor = new Dictionary<BrowserProjectActions, GetBrowserActionExecutor>();
            _actions = new Dictionary<BrowserProjectActions, GetBrowserAction>();
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

        private BrowserProjectActions ExecuteCurrentActionAndReturnNextAction(BrowserProjectActions currentAction)
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
            _actionsExecutor.Add(BrowserProjectActions.SelectionSession, () => new AccountSelectionFormBrowserAction());
            _actionsExecutor.Add(BrowserProjectActions.OpenMenu, () => new MenuFormBrowserAction());
        }

        private void FillActions()
        {
            var sessionManager = new SessionManager(_project);
            _actions.Add(BrowserProjectActions.LoadingSession, sessionManager.LoadAccount);

            var zennposterActionManager = new ZennoPosterBrowserManager(_instance);
            _actions.Add(BrowserProjectActions.BrowserWaitUserAction, zennposterActionManager.WaitUserAction);
        }
    }
}
