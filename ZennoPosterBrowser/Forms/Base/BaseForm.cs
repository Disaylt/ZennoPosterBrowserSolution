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
        public IFormControls FormControls { get; }

        public BaseForm(IFormControls formControls)
        {
            Form = new Form();
            FormControls = formControls;
            AddControls(formControls.GetFormControls());
        }

        private void AddControls(IEnumerable<Control> controls)
        {
            foreach(Control control in controls)
            {
                Form.Controls.Add(control);
            }
        }
    }
}
