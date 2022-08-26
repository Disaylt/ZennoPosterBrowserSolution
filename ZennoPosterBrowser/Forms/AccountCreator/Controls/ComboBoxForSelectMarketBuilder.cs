using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZennoPosterBrowser.Forms.BaseControls;

namespace ZennoPosterBrowser.Forms.AccountCreator.Controls
{
    internal class ComboBoxForSelectMarketBuilder : ComboBoxBuilder
    {
        private readonly IEnumerable<string> _marketNames;

        public ComboBoxForSelectMarketBuilder(IEnumerable<string> marketNames)
        {
            _marketNames = marketNames;
        }

        public override ComboBox Create()
        {
            ComboBox comboBox = new ComboBox();
            SetSettings(comboBox);
            comboBox.Items.AddRange(_marketNames.ToArray());
            return comboBox;
        }

        private void SetSettings(ComboBox comboBox)
        {
            comboBox.FormattingEnabled = true;
            comboBox.Location = new System.Drawing.Point(15, 40);
            comboBox.Size = new System.Drawing.Size(230, 20);
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
