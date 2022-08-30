using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterBrowser.Configs;
using ZennoPosterBrowser.Logger;
using ZennoPosterBrowser.Services.BrowserActions;
using ZennoPosterBrowser.Services.Logger;

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
            catch (Exception ex)
            {
                ErrorMessage errorMessage = new FileErrorMessageBuilder(ex);
                LoggerStorage.Logger.WriteError(errorMessage);
                return BrowserProjectActions.CloseBrowser;
            }
        }
    }
}