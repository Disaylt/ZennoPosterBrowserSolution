using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZennoPosterBrowser.Forms.Base;
using ZennoPosterBrowser.Forms.Bookmarks;
using ZennoPosterBrowser.Forms.MainMenu.Controls;

namespace ZennoPosterBrowser.Forms.MainMenu
{
    internal class MainMenuFormControls : IFormControls
    {
        private List<Control> _controls;
        private readonly IBookmarksStorage _bookmarksStorage;

        public MainMenuFormControls(IBookmarksStorage bookmarksStorage)
        {
            _bookmarksStorage = bookmarksStorage;
            _controls = new List<Control>();
            _controls.Add(WaitUserAction);
            _controls.Add(UpdateProxy);
            _controls.Add(Bookmarks);
            _controls.Add(BookmarksNames1);
            _controls.Add(BookmarksGoToPage1);
            _controls.Add(BookmarksNames2);
            _controls.Add(BookmarksGoToPage2);
            _controls.Add(BookmarksNames3);
            _controls.Add(BookmarksGoToPage3);
            _controls.Add(BookmarksNames4);
            _controls.Add(BookmarksGoToPage4);
        }

        public List<Control> GetFormControls()
        {
            return _controls;
        }

        private Button _waitUserAction;
        public virtual Button WaitUserAction
        {
            get
            {
                if (_waitUserAction == null)
                {
                    UserWaitActionButtonBuilder findAccountButton = new UserWaitActionButtonBuilder();
                    _waitUserAction = findAccountButton.GetButton();
                }
                return _waitUserAction;
            }
        }

        private Button _updateProxy;
        public virtual Button UpdateProxy
        {
            get
            {
                if (_updateProxy == null)
                {
                    UpdateProxyButtonBuilder findAccountButton = new UpdateProxyButtonBuilder();
                    _updateProxy = findAccountButton.GetButton();
                }
                return _updateProxy;
            }
        }

        private Button _bookmarks;
        public virtual Button Bookmarks
        {
            get
            {
                if(_bookmarks == null)
                {
                    BookmarksButtonBuilder bookmarksButton = new BookmarksButtonBuilder();
                    _bookmarks = bookmarksButton.GetButton();
                }
                return _bookmarks;
            }
        }

        private ComboBox _bookmarkNames1;
        public virtual ComboBox BookmarksNames1
        {
            get
            {
                if(_bookmarkNames1 == null)
                {
                    Point location = new Point(15, 70);
                    BookmarkComboBoxBuilder bookmarkComboBox = new BookmarkComboBoxBuilder(_bookmarksStorage.Bookmarks, location);
                    _bookmarkNames1 = bookmarkComboBox.GetComboBox();
                }
                return _bookmarkNames1;
            }
        }

        private Button _bookmarkGoToPage1;
        public virtual Button BookmarksGoToPage1
        {
            get
            {
                if(_bookmarkGoToPage1 == null)
                {
                    Point location = new Point(255,70);
                    BookmarkGoToPageButtonBuilder bookmarkGoToPageButtonBuilder = new BookmarkGoToPageButtonBuilder(location);
                    _bookmarkGoToPage1 = bookmarkGoToPageButtonBuilder.GetButton();
                }
                return _bookmarkGoToPage1;
            }
        }

        private ComboBox _bookmarkNames2;
        public virtual ComboBox BookmarksNames2
        {
            get
            {
                if (_bookmarkNames2 == null)
                {
                    Point location = new Point(15, 95);
                    BookmarkComboBoxBuilder bookmarkComboBox = new BookmarkComboBoxBuilder(_bookmarksStorage.Bookmarks, location);
                    _bookmarkNames2 = bookmarkComboBox.GetComboBox();
                }
                return _bookmarkNames2;
            }
        }

        private Button _bookmarkGoToPage2;
        public virtual Button BookmarksGoToPage2
        {
            get
            {
                if (_bookmarkGoToPage2 == null)
                {
                    Point location = new Point(255, 95);
                    BookmarkGoToPageButtonBuilder bookmarkGoToPageButtonBuilder = new BookmarkGoToPageButtonBuilder(location);
                    _bookmarkGoToPage2 = bookmarkGoToPageButtonBuilder.GetButton();
                }
                return _bookmarkGoToPage2;
            }
        }

        private ComboBox _bookmarkNames3;
        public virtual ComboBox BookmarksNames3
        {
            get
            {
                if (_bookmarkNames3 == null)
                {
                    Point location = new Point(15, 120);
                    BookmarkComboBoxBuilder bookmarkComboBox = new BookmarkComboBoxBuilder(_bookmarksStorage.Bookmarks, location);
                    _bookmarkNames3 = bookmarkComboBox.GetComboBox();
                }
                return _bookmarkNames3;
            }
        }

        private Button _bookmarkGoToPage3;
        public virtual Button BookmarksGoToPage3
        {
            get
            {
                if (_bookmarkGoToPage3 == null)
                {
                    Point location = new Point(255, 120);
                    BookmarkGoToPageButtonBuilder bookmarkGoToPageButtonBuilder = new BookmarkGoToPageButtonBuilder(location);
                    _bookmarkGoToPage3 = bookmarkGoToPageButtonBuilder.GetButton();
                }
                return _bookmarkGoToPage3;
            }
        }

        private ComboBox _bookmarkNames4;
        public virtual ComboBox BookmarksNames4
        {
            get
            {
                if (_bookmarkNames4 == null)
                {
                    Point location = new Point(15, 145);
                    BookmarkComboBoxBuilder bookmarkComboBox = new BookmarkComboBoxBuilder(_bookmarksStorage.Bookmarks, location);
                    _bookmarkNames4 = bookmarkComboBox.GetComboBox();
                }
                return _bookmarkNames4;
            }
        }

        private Button _bookmarkGoToPage4;
        public virtual Button BookmarksGoToPage4
        {
            get
            {
                if (_bookmarkGoToPage4 == null)
                {
                    Point location = new Point(255, 145);
                    BookmarkGoToPageButtonBuilder bookmarkGoToPageButtonBuilder = new BookmarkGoToPageButtonBuilder(location);
                    _bookmarkGoToPage4 = bookmarkGoToPageButtonBuilder.GetButton();
                }
                return _bookmarkGoToPage4;
            }
        }
    }
}
