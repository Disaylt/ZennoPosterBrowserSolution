using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZennoPosterBrowser.Configs;
using ZennoPosterBrowser.Forms.Base;
using ZennoPosterBrowser.Models.JSON.BookmarksForm;
using ZennoPosterBrowser.Models.JSON.MainMenu;

namespace ZennoPosterBrowser.Forms.MainMenu
{
    internal class MainMenuFormEventHandler : IFormEventHandler
    {
        private readonly MainMenuForm _menuForm;
        private readonly MainMenuFormControls _controls;
        public MainMenuFormEventHandler(MainMenuForm menuForm)
        {
            _menuForm = menuForm;
            _controls = _menuForm.FormControls as MainMenuFormControls;
        }

        public void AddControlsEvent()
        {
            _controls.WaitUserAction.Click += WaitUserAction;
            _controls.UpdateProxy.Click += UpdateProxy;
            _controls.Bookmarks.Click += OpenBookmarksForm;
            _controls.BookmarksGoToPage1.Click += GoToPage1;
            _controls.BookmarksGoToPage2.Click += GoToPage2;
            _controls.BookmarksGoToPage3.Click += GoToPage3;
            _controls.BookmarksGoToPage4.Click += GoToPage4;
            _menuForm.Form.Load += LoadSettings;
            _menuForm.Form.FormClosed += SaveSettings;
        }

        protected virtual void WaitUserAction(object sender, EventArgs e)
        {
            _menuForm.NextAction = BrowserProjectActions.BrowserWaitUserAction;
            _menuForm.Form.Close();
        }

        protected virtual void GoToPage1(object sender, EventArgs e)
        {
            GoToPage(_controls.BookmarksNames1);
        }

        protected virtual void GoToPage2(object sender, EventArgs e)
        {
            GoToPage(_controls.BookmarksNames2);
        }

        protected virtual void GoToPage3(object sender, EventArgs e)
        {
            GoToPage(_controls.BookmarksNames3);
        }

        protected virtual void GoToPage4(object sender, EventArgs e)
        {
            GoToPage(_controls.BookmarksNames4);
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
            MainMenuSettingsModel settings = _menuForm.FormSettings.Load();
            _controls.BookmarksNames1.SelectedItem = settings.BookmarkName1 ?? string.Empty;
            _controls.BookmarksNames2.SelectedItem = settings.BookmarkName2 ?? string.Empty;
            _controls.BookmarksNames3.SelectedItem = settings.BookmarkName3 ?? string.Empty;
            _controls.BookmarksNames4.SelectedItem = settings.BookmarkName4 ?? string.Empty;
        }

        protected virtual void SaveSettings(object sender, FormClosedEventArgs e)
        {
            MainMenuSettingsModel settings = new MainMenuSettingsModel
            {
                BookmarkName1 = (string)_controls.BookmarksNames1.SelectedItem ?? string.Empty,
                BookmarkName2 = (string)_controls.BookmarksNames2.SelectedItem ?? string.Empty,
                BookmarkName3 = (string)_controls.BookmarksNames3.SelectedItem ?? string.Empty,
                BookmarkName4 = (string)_controls.BookmarksNames4.SelectedItem ?? string.Empty
            };
            _menuForm.FormSettings.Save(settings);
        }

        private void GoToPage(ComboBox bookmarks)
        {
            if (!string.IsNullOrEmpty(bookmarks.SelectedItem as string))
            {
                string url = _menuForm.BookmarksJsonStorage.Bookmarks.FirstOrDefault(x => x.Name == bookmarks.SelectedItem as string).Url;
                if (!string.IsNullOrEmpty(url))
                {
                    _menuForm.Instance.ActiveTab.Navigate(url);
                }
            }
        }
    }
}
