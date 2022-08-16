using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoLab.InterfacesLibrary.ProjectModel;

namespace ZennoPosterBrowser
{
    internal class BaseConfig
    {
        private static BaseConfig _instance;
        private string _projectPath;
        private IEnumerable<string> _markets;

        private BaseConfig(IZennoPosterProjectModel project)
        {
            _projectPath = project.Path;
        }

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

        public string ProjectPath => _projectPath;

        public static void InitialConfig(IZennoPosterProjectModel project)
        {
            if (_instance == null)
            {
                _instance = new BaseConfig(project);
            }
        }
    }
}
