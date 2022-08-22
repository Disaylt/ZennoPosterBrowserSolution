using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterBrowser.Mongo.BrowserCollections;

namespace ZennoPosterBrowser.Configs
{
    internal class BrowserConfig
    {
        private static BrowserConfig _instance;

        private BrowserConfig()
        {
            MarketNamesStorage = new MarketsCollection();
            ProjectNamesStorage = new ProjectsCollection();
            CurrentSession = string.Empty;
        }

        public IMarketNamesStorage MarketNamesStorage { get; }
        public IProjectNamesStorage ProjectNamesStorage { get; }
        public BrowserActions NextAction { get; set; }
        public string CurrentSession { get; set; }

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
