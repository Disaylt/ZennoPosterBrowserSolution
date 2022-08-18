﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZennoPosterBrowser.Forms.Base;

namespace ZennoPosterBrowser.Forms.AccountSelection
{
    internal class AccountSelectionForm : BaseForm
    {
        private const string _nameForm = "Выбор аккаунтов";
        private readonly FormEventHandler _formEventHandler;
        public AccountSelectionForm() : base()
        {
            FormControls = new FormControls();
            _formEventHandler = new FormEventHandler(this);
            Form.Size = new Size(400, 500);
            Form.Name = _nameForm;
            AddControls(FormControls);
            AddEvents(_formEventHandler);
        }
        public FormControls FormControls { get; }
    }
}
