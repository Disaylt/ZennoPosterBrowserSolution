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
    internal class FormSettingsFileLoader<TSaveFile, TLoadFile, TFormType> : IFormSettings<TSaveFile, TLoadFile>
        where TFormType : BaseForm
    {
        private readonly string _filePath;

        public FormSettingsFileLoader(TSaveFile defaultSetting)
        {
            _filePath = $"{BaseConfig.Instance.ProjectPath}{typeof(TFormType).Name}.json";
            CheckExistsAndCreateDefaultSettings(defaultSetting);
        }

        public TLoadFile Load()
        {
            var result = JsonFile.Load<TLoadFile>(_filePath);
            return result;
        }

        public void Save(TSaveFile setting)
        {
            JsonFile.SaveAs(setting, _filePath);
        }

        private void CheckExistsAndCreateDefaultSettings(TSaveFile setting)
        {
            if(!File.Exists(_filePath))
            {
                Save(setting);
            }
        }
    }
}
