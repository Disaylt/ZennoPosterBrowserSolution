using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterBrowser.Configs;
using ZennoPosterBrowser.Logger;
using ZennoPosterBrowser.Services.BrowserActions;

namespace ZennoPosterBrowser.Forms.Bookmarks
{
    internal class BookmarksFormAction : IBrowserAction
    {
        private readonly BookmarksForm _bookmarksForm;
        private readonly ILogger<InfoMessage, ErrorMessage> _logger;
        public BookmarksFormAction()
        {
            _bookmarksForm = new BookmarksForm();
            _logger = BaseConfig.Instance.Logger;
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
                _logger.WriteError(errorMessage);
                return BrowserProjectActions.CloseBrowser;
            }
        }
    }
}