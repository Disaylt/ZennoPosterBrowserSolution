using System;
using System.Collections.Generic;
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
        
        public BookmarksJsonStorage()
        {
            Bookmarks = LoadBookmarks();
        }

        public IEnumerable<BookmarkModel> Bookmarks { get; }

        public void AddBookmark(BookmarkModel bookmark)
        {
            throw new NotImplementedException();
        }

        private List<BookmarkModel> LoadBookmarks()
        {
            BaseConfig baseConfig = BaseConfig.Instance;
            string filePath = $"{baseConfig.ProjectPath}{_fileName}";
            List<BookmarkModel> bookmarks = JsonFile.Load<List<BookmarkModel>>(filePath);
            return bookmarks;
        }
    }
}
