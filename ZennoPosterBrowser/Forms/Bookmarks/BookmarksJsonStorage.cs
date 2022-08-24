using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterBrowser.Configs;
using ZennoPosterBrowser.Models.JSON.BookmarksForm;

namespace ZennoPosterBrowser.Forms.Bookmarks
{
    internal class BookmarksJsonStorage : IBookmarksStorage
    {
        private const string _fileName = "BookmarksStorage.json";
        private readonly string _filePath;
        private readonly List<BookmarkModel> _bookmarks;


        public BookmarksJsonStorage()
        {
            BaseConfig baseConfig = BaseConfig.Instance;
            _filePath = $"{baseConfig.ProjectPath}{_fileName}";
            _bookmarks = LoadBookmarks();
        }

        public IEnumerable<BookmarkModel> Bookmarks
        {
            get
            {
                return _bookmarks;
            }
        }

        public void AddBookmark(BookmarkModel bookmark)
        {
            if(!Bookmarks.Any(x=> x.Name == bookmark.Name))
            {
                _bookmarks.Add(bookmark);
                JsonFile.SaveAs(Bookmarks, _filePath);
            }
        }

        public void DeleteBookmark(string bookmarkName)
        {
            BookmarkModel bookmark = Bookmarks
                .Where(x=> x.Name == bookmarkName)
                .FirstOrDefault();
            if(bookmark != null)
            {
                _bookmarks.Remove(bookmark);
                JsonFile.SaveAs(Bookmarks, _filePath);
            }
        }

        public void UpdateBookmark(BookmarkModel newBookmark)
        {
            BookmarkModel oldBookmark = Bookmarks
                .FirstOrDefault(x => x.Name == newBookmark.Name);
            if(oldBookmark != null)
            {
                _bookmarks.Remove(oldBookmark);
                _bookmarks.Add(newBookmark);
                JsonFile.SaveAs(Bookmarks, _filePath);
            }
        }

        private List<BookmarkModel> LoadBookmarks()
        {
            List<BookmarkModel> bookmarks;
            try
            {
                bookmarks = JsonFile.Load<List<BookmarkModel>>(_filePath);
            }
            catch(Exception)
            {
                bookmarks = new List<BookmarkModel>();
            }
            return bookmarks;
        }
    }
}
