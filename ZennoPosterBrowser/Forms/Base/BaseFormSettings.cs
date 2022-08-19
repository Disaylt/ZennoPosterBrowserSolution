using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterBrowser.Models.JSON.FormSettings;

namespace ZennoPosterBrowser.Forms.Base
{
    internal class BaseFormSettings : FormSettingsFileLoader<FromSettingLocationModel, FromSettingLocationModel>
    {
        private static FromSettingLocationModel _fromSettingLocation = new FromSettingLocationModel
        {
            LocationX = 0,
            LocationY = 0
        };
        private const string _name = "locationSettings.json";
        public BaseFormSettings() : base(_name, _fromSettingLocation)
        {
        }
    }
}
