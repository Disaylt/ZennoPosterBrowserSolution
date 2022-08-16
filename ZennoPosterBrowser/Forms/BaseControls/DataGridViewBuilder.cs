﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZennoPosterBrowser.Forms.BaseControls
{
    internal abstract class DataGridViewBuilder
    {
        public abstract DataGridView Create();

        public static void AddAccountColumn(DataGridView dataGridView, IEnumerable<DataGridViewTextBoxColumn> columns)
        {
            foreach(DataGridViewTextBoxColumn column in columns)
            {
                dataGridView.Columns.Add(column);
            }
        }
    }
}