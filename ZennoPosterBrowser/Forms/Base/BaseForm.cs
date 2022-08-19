using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZennoPosterBrowser.Models.JSON.FormSettings;
using ZennoPosterBrowser.Services.FormSettings;

namespace ZennoPosterBrowser.Forms.Base
{
    internal abstract class BaseForm
    {
        public BaseForm()
        {
            Form = new Form();
            IFormEventHandler formEventHandler = new BaseEventHandler(this);
            AddEvents(formEventHandler);
        }

        public Form Form { get; }

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
