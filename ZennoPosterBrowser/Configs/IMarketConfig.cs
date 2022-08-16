using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZennoPosterBrowser.Configs
{
    internal interface IMarketConfig
    {
        IEnumerable<string> MarketsName { get; }
    }
}
