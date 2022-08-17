using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZennoPosterBrowser.Configs
{
    internal class MarketsConfigFromFile : IMarketConfig
    {
        private const string _fileName = "MarketsName.json";

        public MarketsConfigFromFile(string projectPath)
        {
            MarketsName = JsonFileLoader.Load<List<string>>($"{projectPath}{_fileName}");
        }

        public IEnumerable<string> MarketsName { get; }
    }
}
