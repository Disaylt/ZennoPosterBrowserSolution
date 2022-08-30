using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZennoPosterBrowser.Forms.BaseControls;

namespace ZennoPosterBrowser.Forms.AccountSelection.Controls
{
    internal class SelectProjectComboBoxBuilder : ComboBoxBuilder
    {
        public SelectProjectComboBoxBuilder(IEnumerable<string> projectNames)
        {
            SetSettings();
            Control.Items.AddRange(projectNames.ToArray());
        }

        public override ComboBox GetComboBox()
        {
            return Control;
        }

        private void SetSettings()
        {
            Control.FormattingEnabled = true;
            Control.Location = new System.Drawing.Point(275, 15);
            Control.Name = "comboBoxSelectMarket";
            Control.Size = new System.Drawing.Size(90, 20);
            Control.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
