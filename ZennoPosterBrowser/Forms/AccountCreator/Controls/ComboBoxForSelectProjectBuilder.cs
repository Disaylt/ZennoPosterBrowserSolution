using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZennoPosterBrowser.Forms.BaseControls;

namespace ZennoPosterBrowser.Forms.AccountCreator.Controls
{
    internal class ComboBoxForSelectProjectBuilder : ComboBoxBuilder
    {
        private readonly IEnumerable<string> _projectNames;

        public ComboBoxForSelectProjectBuilder(IEnumerable<string> projectNames)
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
            comboBox.Location = new System.Drawing.Point(15, 65);
            comboBox.Size = new System.Drawing.Size(230, 20);
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
