using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterBrowser.Forms.Base;

namespace ZennoPosterBrowser.Forms.AccountCreator
{
    internal class AccountCreatorForm : BaseForm
    {
        private const string _nameForm = "Добавление аккаунта";

        public AccountCreatorForm()
        {
            Form.Size = new Size(400, 500);
            Form.Name = _nameForm;
        }
    }
}