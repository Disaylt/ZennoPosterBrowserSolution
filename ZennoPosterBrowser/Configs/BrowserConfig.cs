using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZennoPosterBrowser.Configs
{
    internal class BrowserConfig
    {
        private static BrowserConfig _instance;

        private BrowserConfig()
        {
            BaseConfig config = BaseConfig.Instance;
            MarketNamesStorage = new MarketNamesStorageDbLoader();
            ProjectNamesStorage = new ProjectNamesStorageDbLoader();
            ProjectSettingsLoader = new ProjectSettingsFileLoader(config.ProjectPath);
        }

        public IMarketNamesStorage MarketNamesStorage { get; }
        public IProjectNamesStorage ProjectNamesStorage { get; }
        public IProjectSettingsLoader ProjectSettingsLoader { get; }

        public static BrowserConfig Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BrowserConfig();
                }
                return _instance;
            }
        }
    }
}
