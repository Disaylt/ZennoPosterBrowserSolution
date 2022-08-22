﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterBrowser.Configs;

namespace ZennoPosterBrowser.Services.BrowserActions
{
    internal delegate IBrowserAction GetBrowserAction();
    internal class BrowserActionsStorage
    {
        private readonly Dictionary<Configs.BrowserActions, GetBrowserAction> _actions;

        public BrowserActionsStorage()
        {
            _actions = new Dictionary<Configs.BrowserActions, GetBrowserAction>();
        }

        public void ExecuteActions()
        {
            try
            {
                BrowserConfig browserConfig = BrowserConfig.Instance;
                while (browserConfig.NextAction != Configs.BrowserActions.CloseBrowser)
                {

                }
            }
            catch(Exception)
            {

            }
        }

        private void AddActions()
        {

        }
    }
}