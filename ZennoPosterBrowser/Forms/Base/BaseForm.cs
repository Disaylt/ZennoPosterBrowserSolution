using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZennoPosterBrowser.Services.FormSettings;

namespace ZennoPosterBrowser.Forms.Base
{
    internal abstract class BaseForm
    {
        public Form Form { get; }

        public BaseForm()
        {
            Form = new Form();
            Form.Load += SetSettings;
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

        private void SetSettings(object sender, EventArgs e)
        {
            FormSettingsStorage formSettingsStorage = FormSettingsStorage.Instance;
            var type = GetType();
            var settingsLoader = formSettingsStorage.GetFormSettings(type);
            var setting = settingsLoader.Load();
            Form.Location = new Point(setting.LocationX, setting.LocationY);
        }
    }
}
