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
        private readonly IFormEventHandler _formEventHandler;
        public BookmarksForm()
        {
            BookmarksStorage = new BookmarksJsonStorage();
            FormControls = new BookmarksFormControls(BookmarksStorage);
            _formEventHandler = new BookmarksEventHandler(this);
            AddControls(FormControls);
            AddEvents(_formEventHandler);
            NextAction = BrowserProjectActions.OpenMenu;
            Form.Size = new Size(400, 300);
            Form.Name = _nameForm;
        }
        public BrowserProjectActions NextAction { get; set; }
        public IBookmarksStorage BookmarksStorage { get; }
        public IFormControls FormControls { get; }
    }
}
