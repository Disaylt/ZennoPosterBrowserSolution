using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterBrowser.Configs;
using ZennoPosterBrowser.Forms.Base;

namespace ZennoPosterBrowser.Forms.MainMenu
{
    internal class FormEventHandler : IFormEventHandler
    {
        private MenuForm _menuForm;
        public FormEventHandler(MenuForm menuForm)
        {
            _menuForm = menuForm;
        }

        public void AddControlsEvent()
        {
            FormControls formControls = _menuForm.FormControls as FormControls;
            formControls.WaitUserAction.Click += WaitUserAction;
            formControls.UpdateProxy.Click += UpdateProxy;
        }

        protected virtual void WaitUserAction(object sender, EventArgs e)
        {
            _menuForm.NextAction = BrowserProjectActions.BrowserWaitUserAction;
            _menuForm.Form.Close();
        }

        protected virtual void UpdateProxy(object sender, EventArgs e)
        {
            _menuForm.NextAction = BrowserProjectActions.UpdateProxy;
            _menuForm.Form.Close();
        }
    }
}
