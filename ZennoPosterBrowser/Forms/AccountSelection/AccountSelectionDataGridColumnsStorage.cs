using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZennoPosterBrowser.Forms.AccountSelection
{
    internal class AccountSelectionDataGridColumnsStorage
    {
        public IEnumerable<DataGridViewTextBoxColumn> Columns { get; }

        public AccountSelectionDataGridColumnsStorage()
        {
            Columns = new List<DataGridViewTextBoxColumn>
            {
                CreateAccountColumn()
            };
        }

        protected virtual DataGridViewTextBoxColumn CreateAccountColumn()
        {
            var columnAccounts = new DataGridViewTextBoxColumn();
            columnAccounts.HeaderText = "Аккаунты";
            columnAccounts.Name = "columnAccounts";
            columnAccounts.Width = 300;
            columnAccounts.ReadOnly = true;
            return columnAccounts;
        }
    }
}
