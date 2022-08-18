using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZennoPosterBrowser.Forms.Base
{
    internal abstract class BaseForm
    {
        public Form Form { get; }

        public BaseForm()
        {
            Form = new Form();
        }

        protected void AddControls(IFormControls formControls)
        {
            var controls = formControls.GetFormControls();
            foreach (Control control in controls)
            {
                Form.Controls.Add(control);
            }
        }

        protected void AddEvents(IFormEventHandler formEventHandler)
        {
            formEventHandler.AddControlsEvent();
        }
    }
}
