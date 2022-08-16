using System;
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
        public AccountSelectionForm() : base(new FormControls())
        {
            Form.Size = new Size(400, 500);
            Form.Name = _nameForm;
        }
    }
}
