using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterBrowser.Configs;
using ZennoPosterBrowser.Models.JSON.FormSettings;

namespace ZennoPosterBrowser.Forms.Base
{
    internal class FormSettingsFileLoader : IFormSettings<FromSettingLocationModel, FromSettingLocationModel>
    {
        private readonly string _filePath;

        public FormSettingsFileLoader(string fileName, FromSettingLocationModel defaultSetting)
        {
            _filePath = $"{BaseConfig.Instance.ProjectPath}{fileName}";
            CheckExistsAndCreateDefaultSettings(defaultSetting);
        }

        public FromSettingLocationModel Load()
        {
            var result = JsonFile.Load<FromSettingLocationModel>(_filePath);
            return result;
        }

        public void Save(FromSettingLocationModel setting)
        {
            JsonFile.SaveAs(setting, _filePath);
        }

        private void CheckExistsAndCreateDefaultSettings(FromSettingLocationModel setting)
        {
            if(!File.Exists(_filePath))
            {
                Save(setting);
            }
        }
    }
}
