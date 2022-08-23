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
    internal delegate IBrowserAction GetObjectActionExecutor();
    internal delegate BrowserProjectActions GetActionExecutor();
    internal class BrowserActionsManager
    {
        private readonly Dictionary<BrowserProjectActions, GetObjectActionExecutor> _objectsActionExecutor;
        private readonly Dictionary<BrowserProjectActions, GetActionExecutor> _executors;
        private readonly BrowserProjectActions _firsstAction;

        public BrowserActionsManager(BrowserProjectActions firstAction)
        {
            _objectsActionExecutor = new Dictionary<BrowserProjectActions, GetObjectActionExecutor>();
            _executors = new Dictionary<BrowserProjectActions, GetActionExecutor>();
            _firsstAction = firstAction;
        }

        public void ExecuteActions()
        {
            var nextAction = _firsstAction;
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
    }
}
