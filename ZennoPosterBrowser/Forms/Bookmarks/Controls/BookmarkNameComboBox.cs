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
        private readonly IEnumerable<string> _bookmarkNames;

        public BookmarkNameComboBox(IEnumerable<BookmarkModel> bookmarkNames)
        {
            _bookmarkNames = bookmarkNames
                .Select(x=> x.Name);
        }

        public override ComboBox GetComboBox()
        {
            ComboBox comboBox = new ComboBox();
            SetSettings(comboBox);
            comboBox.Items.AddRange(_bookmarkNames.ToArray());
            return comboBox;
        }

        private void SetSettings(ComboBox comboBox)
        {
            comboBox.FormattingEnabled = true;
            comboBox.Location = new System.Drawing.Point(15, 140);
            comboBox.Name = "comboBoxBookmarks";
            comboBox.Size = new System.Drawing.Size(260, 20);
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
