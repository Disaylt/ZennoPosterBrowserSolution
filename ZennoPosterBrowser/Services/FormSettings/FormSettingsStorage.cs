using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterBrowser.Forms.Base;
using ZennoPosterBrowser.Models.JSON.FormSettings;

namespace ZennoPosterBrowser.Services.FormSettings
{
    internal delegate IFormSettings<FromSettingLocationModel> GetFormSetting(); 
    internal class FormSettingsStorage
    {
        private static FormSettingsStorage _instance;
        private Dictionary<Type, GetFormSetting> _storage;

        private FormSettingsStorage()
        {
            _storage = new Dictionary<Type, GetFormSetting>();
        }

        public static FormSettingsStorage Instance
        {
            get
            {
                if( _instance == null )
                {
                    _instance = new FormSettingsStorage();
                }
                return _instance;
            }
        }

        public IFormSettings<FromSettingLocationModel> GetFormSettings(Type type)
        {
            if(_storage != null && _storage.ContainsKey(type))
            {
                return _storage[type].Invoke();
            }
            else
            {
                throw new Exception($"Settings for {type.FullName} not exists");
            }
        }

        private void AddSettings()
        {

        }


    }
}
