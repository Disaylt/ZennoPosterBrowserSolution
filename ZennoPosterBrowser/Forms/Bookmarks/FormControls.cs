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
    internal class FormControls : IFormControls
    {
        private readonly List<Control> _controls;

        public FormControls()
        {
            _controls = new List<Control>();
            _controls.Add(_addBookmark);
            _controls.Add(BookmarkName);
            _controls.Add(BookmarkNewUrl);
        }

        public List<Control> GetFormControls()
        {
            throw new NotImplementedException();
        }

        private Button _addBookmark;
        protected virtual Button AddBookmark
        {
            get
            {
                if (_addBookmark == null)
                {
                    BookmarkAddingButtonBuilder addBookmarkButton = new BookmarkAddingButtonBuilder();
                    _addBookmark = addBookmarkButton.Create();
                }
                return _addBookmark;
            }
        }

        private TextBox _bookmarkName;
        protected virtual TextBox BookmarkName
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
        protected virtual TextBox BookmarkNewUrl
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
    }
}
