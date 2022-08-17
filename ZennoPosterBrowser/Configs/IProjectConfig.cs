using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZennoPosterBrowser.Configs
{
    internal interface IProjectConfig
    {
        IEnumerable<string> ProjectNames { get; }
    }
}
