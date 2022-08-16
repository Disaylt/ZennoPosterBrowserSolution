using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZennoPosterBrowser.Forms.BaseControls;

namespace ZennoPosterBrowser.Forms.AccountSelection
{
    internal class SelectMarketComboBoxBuilder : ComboBoxBuilder
    {
        private readonly IEnumerable<string> _marketNames;

        public SelectMarketComboBoxBuilder(IEnumerable<string> marketNames)
        {
            _marketNames = marketNames;
        }

        public override ComboBox Create()
        {
            ComboBox comboBox = new ComboBox();
            SetSettings(comboBox);
            SetItems(comboBox);
            return comboBox;
        }

        private void SetSettings(ComboBox comboBox)
        {
            comboBox.FormattingEnabled = true;
            comboBox.Location = new System.Drawing.Point(170, 15);
            comboBox.Name = "comboBoxSelectMarket";
            comboBox.Size = new System.Drawing.Size(80, 20);
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void SetItems(ComboBox comboBox)
        {
            comboBox.Items.AddRange(_marketNames.ToArray());
        }
    }
}
