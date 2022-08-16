using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZennoPosterBrowser.Forms.Base;

namespace ZennoPosterBrowser.Forms.AccountSelection
{
    internal class AccountSellectionFormControls : IFormControls
    {
        public List<Control> Controls { get; }

        public AccountSellectionFormControls()
        {
            Controls = new List<Control>();
            AddAccountsSellectionControls();
        }

        protected virtual ComboBox SelectMarket
        {
            get
            {
                ComboBox comboBoxSelectMarket = new ComboBox();
                comboBoxSelectMarket.FormattingEnabled = true;
                comboBoxSelectMarket.Items.AddRange(new object[] {
                    "Ozon",
                    "WB",
                    "Другое"});
                comboBoxSelectMarket.Location = new System.Drawing.Point(170, 15);
                comboBoxSelectMarket.Name = "comboBoxSelectMarket";
                comboBoxSelectMarket.Size = new System.Drawing.Size(80, 20);
                comboBoxSelectMarket.DropDownStyle = ComboBoxStyle.DropDownList;
                return comboBoxSelectMarket;
            }
        }

        protected virtual DataGridView Grid
        {
            get
            {
                AccountSelectionDataGrid accountSelectionDataGrid = new AccountSelectionDataGrid();
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
        }

        public List<Control> GetFormControls()
        {
            return Controls;
        }
    }
}
