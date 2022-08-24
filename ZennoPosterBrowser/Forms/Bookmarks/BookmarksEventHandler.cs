using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterBrowser.Forms.Base;
using ZennoPosterBrowser.Models.JSON.BookmarksForm;

namespace ZennoPosterBrowser.Forms.Bookmarks
{
    internal class BookmarksEventHandler : IFormEventHandler
    {
        private readonly BookmarksFormControls _bookmarksFormControls;
        private readonly BookmarksForm _bookmarksForm;
        public BookmarksEventHandler(BookmarksForm form)
        {
            _bookmarksForm = form;
            if (form.FormControls is BookmarksFormControls formControls)
            {
                _bookmarksFormControls = formControls;
            }
        }

        public void AddControlsEvent()
        {
            _bookmarksFormControls.AdditionBookmark.Click += AddBookmark;
            _bookmarksFormControls.DeletionBookmark.Click += DeleteBookmark;
            _bookmarksFormControls.UpdationBookmark.Click += UpdateBookmark;
            _bookmarksFormControls.BookmarketComboBox.SelectedIndexChanged += ChangeBookmarkName;
        }

        protected virtual void AddBookmark(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(_bookmarksFormControls.BookmarkName.Text)
                && !string.IsNullOrEmpty(_bookmarksFormControls.BookmarkNewUrl.Text)
                && !_bookmarksForm.BookmarksStorage.Bookmarks
                .Any(x=> x.Name == _bookmarksFormControls.BookmarkName.Text))
            {
                BookmarkModel bookmark = new BookmarkModel
                {
                    Name = _bookmarksFormControls.BookmarkName.Text,
                    Url = _bookmarksFormControls.BookmarkNewUrl.Text
                };
                _bookmarksForm.BookmarksStorage.AddBookmark(bookmark);
                _bookmarksFormControls.BookmarketComboBox.Items.Add(_bookmarksFormControls.BookmarkName.Text);
                _bookmarksFormControls.BookmarkName.Text = string.Empty;
                _bookmarksFormControls.BookmarkNewUrl.Text = string.Empty;
            }
        }

        protected virtual void DeleteBookmark(object sender, EventArgs e)
        {
            if (_bookmarksFormControls.BookmarketComboBox.SelectedItem is string bookmark
                && !string.IsNullOrEmpty(bookmark))
            {
                _bookmarksForm.BookmarksStorage.DeleteBookmark(bookmark);
                _bookmarksFormControls.BookmarketComboBox.Items.Remove(_bookmarksFormControls.BookmarketComboBox.SelectedItem);
                _bookmarksFormControls.BookmarkCurrentUrl.Text = string.Empty;
            }
        }

        protected virtual void ChangeBookmarkName(object sender, EventArgs e)
        {
            if (_bookmarksFormControls.BookmarketComboBox.SelectedItem is string bookmark
                && !string.IsNullOrEmpty(bookmark))
            {
                string url = _bookmarksForm
                    .BookmarksStorage
                    .Bookmarks
                    .FirstOrDefault(x=> x.Name == bookmark)
                    .Url ?? string.Empty;
                _bookmarksFormControls.BookmarkCurrentUrl.Text = url;
            }
        }

        protected virtual void UpdateBookmark(object sender, EventArgs e)
        {
            if (_bookmarksFormControls.BookmarketComboBox.SelectedItem is string bookmarkName
                && !string.IsNullOrEmpty(bookmarkName)
                && _bookmarksForm.BookmarksStorage.Bookmarks.Any(x=> x.Name == bookmarkName))
            {
                BookmarkModel bookmark = new BookmarkModel
                {
                    Name = bookmarkName,
                    Url = _bookmarksFormControls.BookmarkCurrentUrl.Text
                };
                _bookmarksForm.BookmarksStorage.UpdateBookmark(bookmark);
            }
        }
    }
}