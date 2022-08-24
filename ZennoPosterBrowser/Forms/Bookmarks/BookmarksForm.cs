using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterBrowser.Configs;
using ZennoPosterBrowser.Forms.Base;

namespace ZennoPosterBrowser.Forms.Bookmarks
{
    internal class BookmarksForm : BaseForm
    {
        private const string _nameForm = "Закладки";
        public BookmarksForm()
        {
            BookmarksStorage = new BookmarksJsonStorage();
            FormControls = new FormControls(BookmarksStorage);
            AddControls(FormControls);
            NextAction = BrowserProjectActions.OpenMenu;
            Form.Size = new Size(400, 500);
            Form.Name = _nameForm;
        }
        public BrowserProjectActions NextAction { get; set; }
        public IBookmarksStorage BookmarksStorage { get; }
        public IFormControls FormControls { get; }
    }
}
