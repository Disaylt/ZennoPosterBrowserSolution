using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZennoPosterBrowser.Forms.BaseControls;
using ZennoPosterBrowser.Models.JSON.BookmarksForm;

namespace ZennoPosterBrowser.Forms.Bookmarks.Controls
{
    internal class BookmarkNameComboBox : ComboBoxBuilder
    {
        public BookmarkNameComboBox(IEnumerable<BookmarkModel> bookmarkNames)
        {
            SetSettings();
            AddItems(bookmarkNames);
        }

        public override ComboBox GetComboBox()
        {
            return Control;
        }

        private void AddItems(IEnumerable<BookmarkModel> bookmarkNames)
        {
            var names = bookmarkNames
                .Select(x => x.Name)
                .ToArray();
            Control.Items.AddRange(names);
        }

        private void SetSettings()
        {
            Control.FormattingEnabled = true;
            Control.Location = new System.Drawing.Point(15, 140);
            Control.Name = "comboBoxBookmarks";
            Control.Size = new System.Drawing.Size(260, 20);
            Control.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
