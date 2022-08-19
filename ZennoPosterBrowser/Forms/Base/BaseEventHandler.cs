using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZennoPosterBrowser.Models.JSON.FormSettings;

namespace ZennoPosterBrowser.Forms.Base
{
    internal class BaseEventHandler : IFormEventHandler
    {
        private BaseForm _baseForm;
        private BaseFormSettings _baseFormSettings;
        public BaseEventHandler(BaseForm baseForm)
        {
            _baseForm = baseForm;
            _baseFormSettings = new BaseFormSettings();
        }

        public void AddControlsEvent()
        {
            _baseForm.Form.Load += SetLastLocation;
            _baseForm.Form.FormClosed += SaveSettings;
        }

        protected virtual void SetLastLocation(object sender, EventArgs e)
        {
            var locationSettings = _baseFormSettings.Load();
            _baseForm.Form.Location = new Point(locationSettings.LocationX, locationSettings.LocationY);
        }

        protected virtual void SaveSettings(object sender, FormClosedEventArgs e)
        {
            FromSettingLocationModel settings = new FromSettingLocationModel
            {
                LocationX = _baseForm.Form.Location.X,
                LocationY = _baseForm.Form.Location.Y
            };
            _baseFormSettings.Save(settings);
        }
    }
}
