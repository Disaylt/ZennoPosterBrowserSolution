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

        protected virtual DataGridView Grid
        {
            get
            {
                AccountSelectionDataGrid accountSelectionDataGrid = new AccountSelectionDataGrid();
                return accountSelectionDataGrid.DataGridView;
            }
        }

        private void AddAccountsSellectionControls()
        {
            Controls.Add(Grid);
        }

        public List<Control> GetFormControls()
        {
            return Controls;
        }
    }
}
