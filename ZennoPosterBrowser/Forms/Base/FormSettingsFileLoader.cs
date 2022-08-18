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
    internal class FormSettingsFileLoader<T> : IFormSettings<T> where T : FromSettingLocationModel
    {
        private readonly string _filePath;

        public FormSettingsFileLoader(string fileName, T defaultSetting)
        {
            _filePath = $"{BaseConfig.Instance.ProjectPath}{fileName}";
            CheckExistsAndCreateDefaultSettings(defaultSetting);
        }

        public T Load()
        {
            var result = JsonFile.Load<T>(_filePath);
            return result;
        }

        public void Save(T setting)
        {
            JsonFile.SaveAs(setting, _filePath);
        }

        private void CheckExistsAndCreateDefaultSettings(T setting)
        {
            if(!File.Exists(_filePath))
            {
                Save(setting);
            }
        }
    }
}
