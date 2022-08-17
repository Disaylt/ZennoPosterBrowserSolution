using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoLab.InterfacesLibrary.ProjectModel;

namespace ZennoPosterBrowser.Configs
{
    internal class BaseConfig
    {
        private static BaseConfig _instance;

        private BaseConfig(IZennoPosterProjectModel project)
        {
            ProjectPath = project.Path;
            MarketConfig = new MarketsConfigFromFile(ProjectPath);
            ProjectConfig = new ProjectsConfigFromFile(ProjectPath);
        }

        public string ProjectPath { get; }
        public IMarketConfig MarketConfig { get; }
        public IProjectConfig ProjectConfig { get; }

        public static BaseConfig Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new NullReferenceException("Config instance not initialized");
                }
                return _instance;
            }
        }

        public static void InitialConfig(IZennoPosterProjectModel project)
        {
            if (_instance == null)
            {
                _instance = new BaseConfig(project);
            }
        }
    }
}
