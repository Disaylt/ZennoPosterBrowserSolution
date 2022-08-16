using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZennoPosterBrowser.Forms.BaseControls;

namespace ZennoPosterBrowser.Forms.AccountSelection
{
    internal class AccountSelectionDataGridBuilder : DataGridViewBuilder
    {
        public override DataGridView Create()
        {
            DataGridView dataGridView = new DataGridView();
            SetDataGridSettings(dataGridView);
            AccountSelectionDataGridColumnsStorage columnStorage = new AccountSelectionDataGridColumnsStorage();
            AddColumns(dataGridView, columnStorage.Columns);
            return dataGridView;
        }

        private void SetDataGridSettings(DataGridView dataGridView)
        {
            ((System.ComponentModel.ISupportInitialize)(dataGridView)).BeginInit();
            dataGridView.SuspendLayout();
            dataGridView.BackgroundColor = System.Drawing.Color.White;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new System.Drawing.Point(15, 45);
            dataGridView.Name = "dataGridAccounts";
            dataGridView.Size = new System.Drawing.Size(350, 300);
        }
    }
}
