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
        public BookmarkComboBoxBuilder(IEnumerable<BookmarkModel> bookmarkNames, Point location)
        {
            SetSettings(location);
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

        private void SetSettings(Point location)
        {
            Control.FormattingEnabled = true;
            Control.Location = location;
            Control.Size = new Size(230, 20);
            Control.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
