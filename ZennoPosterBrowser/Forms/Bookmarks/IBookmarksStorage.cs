using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterBrowser.Models.JSON.BookmarksForm;

namespace ZennoPosterBrowser.Forms.Bookmarks
{
    internal interface IBookmarksStorage
    {
        IEnumerable<BookmarkModel> Bookmarks { get; }
        void AddBookmark(BookmarkModel bookmark);
        void DeleteBookmark(string bookmarkName);
    }
}
