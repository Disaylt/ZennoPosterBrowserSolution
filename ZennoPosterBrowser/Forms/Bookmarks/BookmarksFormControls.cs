using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZennoPosterBrowser.Forms.Base;
using ZennoPosterBrowser.Forms.Bookmarks.Controls;

namespace ZennoPosterBrowser.Forms.Bookmarks
{
    internal class BookmarksFormControls : IFormControls
    {
        private readonly List<Control> _controls;
        private readonly IBookmarksStorage _bookmarksStorage;

        public BookmarksFormControls(IBookmarksStorage bookmarksStorage)
        {
            _bookmarksStorage = bookmarksStorage;
            _controls = new List<Control>();
            _controls.Add(AdditionBookmark);
            _controls.Add(BookmarkName);
            _controls.Add(BookmarkNewUrl);
            _controls.Add(BookmarkComboBox);
            _controls.Add(BookmarkCurrentUrl);
            _controls.Add(UpdationBookmark);
            _controls.Add(DeletionBookmark);
        }

        public List<Control> GetFormControls()
        {
            return _controls;
        }

        private Button _additionBookmark;
        public virtual Button AdditionBookmark
        {
            get
            {
                if (_additionBookmark == null)
                {
                    BookmarkAdditionButtonBuilder addBookmarkButton = new BookmarkAdditionButtonBuilder();
                    _additionBookmark = addBookmarkButton.Create();
                }
                return _additionBookmark;
            }
        }

        private Button _deletionBookmark;
        public virtual Button DeletionBookmark
        {
            get
            {
                if (_deletionBookmark == null)
                {
                    BookmarkDeletionButtonBuilder addBookmarkButton = new BookmarkDeletionButtonBuilder();
                    _deletionBookmark = addBookmarkButton.Create();
                }
                return _deletionBookmark;
            }
        }

        private Button _updationBookmark;
        public virtual Button UpdationBookmark
        {
            get
            {
                if (_updationBookmark == null)
                {
                    BookmarkUpdationButtonBuilder addBookmarkButton = new BookmarkUpdationButtonBuilder();
                    _updationBookmark = addBookmarkButton.Create();
                }
                return _updationBookmark;
            }
        }

        private TextBox _bookmarkName;
        public virtual TextBox BookmarkName
        {
            get
            {
                if(_bookmarkName == null)
                {
                    BookmarkNameTextBox bookmarkNameTextBox = new BookmarkNameTextBox();
                    _bookmarkName = bookmarkNameTextBox.Create();
                }
                return _bookmarkName;
            }
        }

        private TextBox _bookmarkNewUrl;
        public virtual TextBox BookmarkNewUrl
        {
            get
            {
                if (_bookmarkNewUrl == null)
                {
                    BookmarkNewUrlTextBox bookmarkNameTextBox = new BookmarkNewUrlTextBox();
                    _bookmarkNewUrl = bookmarkNameTextBox.Create();
                }
                return _bookmarkNewUrl;
            }
        }

        private TextBox _bookmarkCurrentUrl;
        public virtual TextBox BookmarkCurrentUrl
        {
            get
            {
                if (_bookmarkCurrentUrl == null)
                {
                    BookmarkCurrentUrlTextBox bookmarkNameTextBox = new BookmarkCurrentUrlTextBox();
                    _bookmarkCurrentUrl = bookmarkNameTextBox.Create();
                }
                return _bookmarkCurrentUrl;
            }
        }

        private ComboBox _bookmarkComboBox;
        public virtual ComboBox BookmarkComboBox
        {
            get
            {
                if (_bookmarkComboBox == null)
                {
                    BookmarkNameComboBox bookmarkNameTextBox = new BookmarkNameComboBox(_bookmarksStorage.Bookmarks);
                    _bookmarkComboBox = bookmarkNameTextBox.Create();
                }
                return _bookmarkComboBox;
            }
        }
    }
}
