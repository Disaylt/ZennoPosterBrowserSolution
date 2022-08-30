using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZennoPosterBrowser.Forms.BaseControls;
using ZennoPosterBrowser.Models.JSON.BookmarksForm;

namespace ZennoPosterBrowser.Forms.MainMenu.Controls
{
    internal class BookmarkComboBoxBuilder : ComboBoxBuilder
    {
        private readonly IEnumerable<string> _bookmarkNames;
        private readonly Point _location;

        public BookmarkComboBoxBuilder(IEnumerable<BookmarkModel> bookmarkNames, Point location)
        {
            _bookmarkNames = bookmarkNames
                .Select(x => x.Name);
            _location = location;
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
            comboBox.Location = _location;
            comboBox.Size = new Size(230, 20);
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
