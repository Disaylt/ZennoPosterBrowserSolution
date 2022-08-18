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
        private static object _locker = new object();
        private static BaseConfig _instance;

        private BaseConfig(IZennoPosterProjectModel project)
        {
            ProjectPath = project.Path;
        }

        public string ProjectPath { get; }

        public static BaseConfig Instance
        {
            get
            {
                lock(_locker)
                {
                    if (_instance == null)
                    {
                        throw new NullReferenceException("Config instance not initialized");
                    }
                    return _instance;
                }
            }
        }

        public static void InitialConfig(IZennoPosterProjectModel project)
        {
            lock(_locker)
            {
                if (_instance == null)
                {
                    _instance = new BaseConfig(project);
                }
            }
        }
    }
}
