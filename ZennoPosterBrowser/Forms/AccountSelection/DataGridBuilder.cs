using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZennoPosterBrowser.Forms.AccountSelection
{
    internal class DataGridBuilder
    {
        public DataGridView DataGridView { get; }

        public DataGridBuilder()
        {
            DataGridView = new DataGridView();
            SetDataGridSettings();
            AddAccountColumn();
        }

        private void SetDataGridSettings()
        {
            ((System.ComponentModel.ISupportInitialize)(DataGridView)).BeginInit();
            DataGridView.SuspendLayout();
            DataGridView.BackgroundColor = System.Drawing.Color.White;
            DataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridView.Location = new System.Drawing.Point(15, 45);
            DataGridView.Name = "dataGridAccounts";
            DataGridView.Size = new System.Drawing.Size(350, 300);
        }

        private void AddAccountColumn()
        {
            var columnAccounts = new DataGridViewTextBoxColumn();
            columnAccounts.HeaderText = "Аккаунты";
            columnAccounts.Name = "columnAccounts";
            columnAccounts.Width = 300;
            columnAccounts.ReadOnly = true;
            DataGridView.Columns.Add(columnAccounts);
        }
    }
}
