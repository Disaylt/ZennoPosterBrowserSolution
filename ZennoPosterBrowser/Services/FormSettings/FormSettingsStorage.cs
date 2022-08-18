using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterBrowser.Forms.AccountSelection;
using ZennoPosterBrowser.Forms.Base;
using ZennoPosterBrowser.Models.JSON.FormSettings;

namespace ZennoPosterBrowser.Services.FormSettings
{
    internal class FormSettingsStorage
    {
        private static FormSettingsStorage _instance;
        private Dictionary<Type, IFormSettings<FromSettingLocationModel, FromSettingLocationModel>> _storage;

        private FormSettingsStorage()
        {
            _storage = new Dictionary<Type, IFormSettings<FromSettingLocationModel, FromSettingLocationModel>>();
            AddSettings();
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

        public IFormSettings<FromSettingLocationModel, FromSettingLocationModel> GetFormSettings(Type type)
        {
            if(_storage != null && _storage.ContainsKey(type))
            {
                return _storage[type];
            }
            else
            {
                throw new Exception($"Settings for {type.FullName} not exists");
            }
        }

        private void AddSettings()
        {
            _storage.Add(typeof(AccountSelectionForm), new AccountSelectionFormSettings());
        }
    }
}
