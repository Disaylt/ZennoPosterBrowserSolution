using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterBrowser.Models.JSON;

namespace ZennoPosterBrowser.Configs
{
    internal class ProjectSettingsFileLoader : IProjectSettingsLoader
    {
        private const string _fileName = "ProjectsSettings.json";

        public ProjectSettingsFileLoader(string projectPath)
        {
            ProjectSettings = JsonFile.Load<ProjectSettingsModel>($"{projectPath}{_fileName}");
        }

        public ProjectSettingsModel ProjectSettings { get; }
    }
}
