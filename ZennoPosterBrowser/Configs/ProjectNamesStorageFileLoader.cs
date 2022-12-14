using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZennoPosterBrowser.Configs
{
    internal class ProjectNamesStorageFileLoader : IProjectNamesStorage
    {
        private const string _fileName = "ProjectsName.json";

        public ProjectNamesStorageFileLoader(string projectPath)
        {
            AllProjectNames = JsonFile.Load<List<string>>($"{projectPath}{_fileName}");
        }

        public IEnumerable<string> AllProjectNames { get; }
    }
}
