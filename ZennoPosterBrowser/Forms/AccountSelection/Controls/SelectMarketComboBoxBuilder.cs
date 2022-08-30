using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZennoPosterBrowser.Forms.BaseControls;

namespace ZennoPosterBrowser.Forms.AccountSelection.Controls
{
    internal class SelectMarketComboBoxBuilder : ComboBoxBuilder
    {
        public SelectMarketComboBoxBuilder(IEnumerable<string> marketNames)
        {
            SetSettings();
            Control.Items.AddRange(marketNames.ToArray());
        }

        public override ComboBox GetComboBox()
        {
            return Control;
        }

        private void SetSettings()
        {
            Control.FormattingEnabled = true;
            Control.Location = new System.Drawing.Point(210, 15);
            Control.Name = "comboBoxSelectMarket";
            Control.Size = new System.Drawing.Size(60, 20);
            Control.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
