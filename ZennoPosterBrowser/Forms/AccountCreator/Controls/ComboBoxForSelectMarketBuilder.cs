﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZennoPosterBrowser.Forms.BaseControls;

namespace ZennoPosterBrowser.Forms.AccountCreator.Controls
{
    internal class ComboBoxForSelectMarketBuilder : ComboBoxBuilder
    {

        public ComboBoxForSelectMarketBuilder(IEnumerable<string> marketNames)
        {
            SetSettings();
            Control.Items.AddRange(marketNames.ToArray());
        }

        public override ComboBox GetComboBox()
        {
            
            return Control;
        }

        private void SetSettings()
        {
            Control.FormattingEnabled = true;
            Control.Location = new System.Drawing.Point(15, 40);
            Control.Size = new System.Drawing.Size(230, 20);
            Control.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
