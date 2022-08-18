using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZennoPosterBrowser.Forms.Base;

namespace ZennoPosterBrowser.Forms.AccountSelection
{
    internal class FormEventHandler : IFormEventHandler
    {
        private FormControls _formControls;
        private Form _form;
        public FormEventHandler(BaseForm baseForm)
        {
            var formHandler = baseForm as AccountSelectionForm;
            _form = formHandler.Form;
            _formControls = formHandler.FormControls;
        }

        public void AddControlsEvent()
        {
            _formControls.TextBox.TextChanged += LoadAccounts;
        }

        protected virtual void LoadAccounts(object sender, EventArgs e)
        {
            _form.Close();
        }
    }
}
