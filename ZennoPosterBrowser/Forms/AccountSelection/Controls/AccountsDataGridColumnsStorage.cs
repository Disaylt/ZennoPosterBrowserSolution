using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZennoPosterBrowser.Forms.AccountSelection.Controls
{
    internal class AccountsDataGridColumnsStorage
    {
        public IEnumerable<DataGridViewTextBoxColumn> Columns { get; }

        public AccountsDataGridColumnsStorage()
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
