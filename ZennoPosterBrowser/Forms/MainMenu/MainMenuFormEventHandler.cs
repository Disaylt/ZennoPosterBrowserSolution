using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZennoPosterBrowser.Configs;
using ZennoPosterBrowser.Forms.Base;
using ZennoPosterBrowser.Models.JSON.MainMenu;

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
            _menuForm.Form.FormClosed += SaveSettings;
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
                MainMenuSettingsModel settings = _menuForm.FormSettings.Load();
                controls.BookmarksNames1.SelectedItem = settings.BookmarkName1 ?? string.Empty;
                controls.BookmarksNames2.SelectedItem = settings.BookmarkName2 ?? string.Empty;
                controls.BookmarksNames3.SelectedItem = settings.BookmarkName3 ?? string.Empty;
                controls.BookmarksNames4.SelectedItem = settings.BookmarkName4 ?? string.Empty;
            }
        }

        protected virtual void SaveSettings(object sender, FormClosedEventArgs e)
        {
            if (_menuForm.FormControls is MainMenuFormControls controls)
            {
                MainMenuSettingsModel settings = new MainMenuSettingsModel
                {
                    BookmarkName1 = (string)controls.BookmarksNames1.SelectedItem ?? string.Empty,
                    BookmarkName2 = (string)controls.BookmarksNames2.SelectedItem ?? string.Empty,
                    BookmarkName3 = (string)controls.BookmarksNames3.SelectedItem ?? string.Empty,
                    BookmarkName4 = (string)controls.BookmarksNames4.SelectedItem ?? string.Empty
                };
                _menuForm.FormSettings.Save(settings);
            }
        }
    }
}
