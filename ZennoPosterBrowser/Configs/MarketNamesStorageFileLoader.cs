using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZennoPosterBrowser.Configs
{
    internal class MarketNamesStorageFileLoader : IMarketNamesStorage
    {
        private const string _fileName = "MarketsName.json";

        public MarketNamesStorageFileLoader(string projectPath)
        {
            AllMarketNames = JsonFile.Load<List<string>>($"{projectPath}{_fileName}");
        }

        public IEnumerable<string> AllMarketNames { get; }
    }
}
