using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterBrowser.Models.JSON;

namespace ZennoPosterBrowser.Configs
{
    internal interface IProjectSettingsLoader
    {
        ProjectSettingsModel ProjectSettings { get; }
    }
}
