using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterBrowser.Forms.Base;

namespace ZennoPosterBrowser.Forms.Bookmarks
{
    internal class BookmarksForm : BaseForm
    {
        public BookmarksForm()
        {
            BookmarksStorage = new BookmarksJsonStorage();
        }

        public IBookmarksStorage BookmarksStorage { get; }
    }
}
