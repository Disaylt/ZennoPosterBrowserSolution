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
            AddAccountsSellectionControls();
        }

        protected virtual ComboBox SelectMarket
        {
            get
            {
                IEnumerable<string> marketsName = BaseConfig.Instance.MarketConfig.MarketsName;
                ComboBoxBuilder comboBoxBuilder = new SelectMarketComboBoxBuilder(marketsName);
                return comboBoxBuilder.Create();
            }
        }

        protected virtual DataGridView Grid
        {
            get
            {
                DataGridBuilder accountSelectionDataGrid = new DataGridBuilder();
                return accountSelectionDataGrid.DataGridView;
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

        private void AddAccountsSellectionControls()
        {
            Controls.Add(Grid);
            Controls.Add(TextBox);
            Controls.Add(SelectMarket);
        }

        public List<Control> GetFormControls()
        {
            return Controls;
        }
    }
}
