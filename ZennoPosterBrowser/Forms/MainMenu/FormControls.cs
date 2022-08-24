﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZennoPosterBrowser.Forms.Base;
using ZennoPosterBrowser.Forms.MainMenu.Controls;

namespace ZennoPosterBrowser.Forms.MainMenu
{
    internal class FormControls : IFormControls
    {
        private List<Control> _controls;

        public FormControls()
        {
            _controls = new List<Control>();
            _controls.Add(WaitUserAction);
            _controls.Add(UpdateProxy);
        }

        public List<Control> GetFormControls()
        {
            return _controls;
        }

        private Button _waitUserAction;
        public virtual Button WaitUserAction
        {
            get
            {
                if (_waitUserAction == null)
                {
                    UserWaitActionButton findAccountButton = new UserWaitActionButton();
                    _waitUserAction = findAccountButton.Create();
                }
                return _waitUserAction;
            }
        }

        private Button _updateProxy;
        public virtual Button UpdateProxy
        {
            get
            {
                if (_updateProxy == null)
                {
                    UpdateProxyButton findAccountButton = new UpdateProxyButton();
                    _updateProxy = findAccountButton.Create();
                }
                return _updateProxy;
            }
        }
    }
}