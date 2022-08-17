using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZennoPosterBrowser.Configs
{
    internal class ProjectsConfigFromFile : IProjectConfig
    {
        private const string _fileName = "ProjectsName.json";

        public ProjectsConfigFromFile(string projectPath)
        {
            ProjectNames = JsonFileLoader.Load<List<string>>($"{projectPath}{_fileName}");
        }

        public IEnumerable<string> ProjectNames { get; }
    }
}
