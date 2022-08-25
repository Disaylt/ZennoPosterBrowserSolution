using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterBrowser.Configs;
using ZennoPosterBrowser.Forms.Base;

namespace ZennoPosterBrowser.Forms.MainMenu
{
    internal class MainMenuFormEventHandler : IFormEventHandler
    {
        private MainMenuForm _menuForm;
        public MainMenuFormEventHandler(MainMenuForm menuForm)
        {
            _menuForm = menuForm;
        }

        public void AddControlsEvent()
        {
            MainMenuFormControls formControls = _menuForm.FormControls as MainMenuFormControls;
            formControls.WaitUserAction.Click += WaitUserAction;
            formControls.UpdateProxy.Click += UpdateProxy;
            formControls.Bookmarks.Click += OpenBookmarksForm;
            _menuForm.Form.Load += LoadSettings;
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

        protected virtual void OpenBookmarksForm(object sender, EventArgs e)
        {
            _menuForm.NextAction = BrowserProjectActions.OpenBookmarkMenu;
            _menuForm.Form.Close();
        }

        protected virtual void LoadSettings(object sender, EventArgs e)
        {
            if(_menuForm.FormControls is MainMenuFormControls controls)
            {
                
            }
            //_accountSelectionForm.FormControls.SelectMarket.SelectedItem = _accountSelectinFormSettings.LastChooseMarket;
        }
    }
}
