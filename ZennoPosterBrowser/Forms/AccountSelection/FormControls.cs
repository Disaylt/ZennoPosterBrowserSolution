using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZennoPosterBrowser.Configs;
using ZennoPosterBrowser.Forms.Base;
using ZennoPosterBrowser.Forms.BaseControls;

namespace ZennoPosterBrowser.Forms.AccountSelection
{
    internal class FormControls : IFormControls
    {
        public List<Control> Controls { get; }

        public FormControls()
        {
            Controls = new List<Control>();
            Controls.Add(Grid);
            Controls.Add(TextBox);
            Controls.Add(SelectMarket);
            Controls.Add(SelectProject);
        }

        protected virtual ComboBox SelectProject
        {
            get
            {
                IEnumerable<string> projectNames = BaseConfig.Instance.ProjectNamesStorage.ProjectNames;
                ComboBoxBuilder comboBoxBuilder = new SelectProjectComboBoxBuilder(projectNames);
                return comboBoxBuilder.Create();
            }
        }

        protected virtual ComboBox SelectMarket
        {
            get
            {
                IEnumerable<string> marketNames = BaseConfig.Instance.MarketNamesStorage.MarketNames;
                ComboBoxBuilder comboBoxBuilder = new SelectMarketComboBoxBuilder(marketNames);
                return comboBoxBuilder.Create();
            }
        }

        protected virtual DataGridView Grid
        {
            get
            {
                AccountSelectionDataGridBuilder accountSelectionDataGrid = new AccountSelectionDataGridBuilder();
                return accountSelectionDataGrid.Create();
            }
        }

        protected virtual TextBox TextBox
        {
            get
            {
                TextBox textBoxSearch = new TextBox();
                textBoxSearch.Location = new System.Drawing.Point(15, 15);
                textBoxSearch.Name = "textBoxSearch";
                textBoxSearch.Size = new System.Drawing.Size(150, 20);
                return textBoxSearch;
            }
        }

        public List<Control> GetFormControls()
        {
            return Controls;
        }
    }
}
