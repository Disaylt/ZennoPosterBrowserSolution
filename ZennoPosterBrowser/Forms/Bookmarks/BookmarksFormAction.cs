using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterBrowser.Configs;
using ZennoPosterBrowser.Services.BrowserActions;

namespace ZennoPosterBrowser.Forms.Bookmarks
{
    internal class BookmarksFormAction : IBrowserAction
    {
        private readonly BookmarksForm _bookmarksForm;
        public BookmarksFormAction()
        {
            _bookmarksForm = new BookmarksForm();
        }

        public BrowserProjectActions Run()
        {
            try
            {
                _bookmarksForm.Form.ShowDialog();
                return _bookmarksForm.NextAction;
            }
            catch (Exception)
            {
                return BrowserProjectActions.CloseBrowser;
            }
        }
    }
}