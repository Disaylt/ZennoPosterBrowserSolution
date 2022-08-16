using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoLab.InterfacesLibrary.ProjectModel;

namespace ZennoPosterBrowser
{
    internal class Config
    {
        private static Config _instance;
        private string _projectPath;

        private Config(IZennoPosterProjectModel project)
        {
            _projectPath = project.Path;
        }

        public static Config Instance
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

        public string ProjectPath => _projectPath;

        public static void InitialConfig(IZennoPosterProjectModel project)
        {
            if (_instance == null)
            {
                _instance = new Config(project);
            }
        }
    }
}
