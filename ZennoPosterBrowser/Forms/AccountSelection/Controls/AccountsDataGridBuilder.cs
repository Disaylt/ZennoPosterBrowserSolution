using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZennoPosterBrowser.Forms.BaseControls;

namespace ZennoPosterBrowser.Forms.AccountSelection.Controls
{
    internal class AccountsDataGridBuilder : DataGridViewBuilder
    {
        public AccountsDataGridBuilder()
        {
            SetDataGridSettings();
            AccountsDataGridColumnsStorage columnStorage = new AccountsDataGridColumnsStorage();
            AddColumns(Control, columnStorage.Columns);
        }

        public override DataGridView GetDataGrid()
        {
            return Control;
        }

        private void SetDataGridSettings()
        {
            ((System.ComponentModel.ISupportInitialize)(Control)).BeginInit();
            Control.SuspendLayout();
            Control.BackgroundColor = System.Drawing.Color.White;
            Control.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Control.Location = new System.Drawing.Point(15, 45);
            Control.Name = "dataGridAccounts";
            Control.Size = new System.Drawing.Size(350, 300);
        }
    }
}
