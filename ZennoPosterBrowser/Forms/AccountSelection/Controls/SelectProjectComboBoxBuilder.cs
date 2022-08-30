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
        private readonly IEnumerable<string> _projectNames;

        public SelectProjectComboBoxBuilder(IEnumerable<string> projectNames)
        {
            _projectNames = projectNames;
        }

        public override ComboBox GetComboBox()
        {
            ComboBox comboBox = new ComboBox();
            SetSettings(comboBox);
            comboBox.Items.AddRange(_projectNames.ToArray());
            return comboBox;
        }

        private void SetSettings(ComboBox comboBox)
        {
            comboBox.FormattingEnabled = true;
            comboBox.Location = new System.Drawing.Point(275, 15);
            comboBox.Name = "comboBoxSelectMarket";
            comboBox.Size = new System.Drawing.Size(90, 20);
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
