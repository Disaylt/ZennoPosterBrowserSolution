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
            MarketsName = LoadMarketsName($"{projectPath}{_fileName}");
        }

        public IEnumerable<string> MarketsName { get; }


        private List<string> LoadMarketsName(string filePath)
        {
            List<string> result = JsonFileLoader.Load<List<string>>(filePath);
            return result;
        }
    }
}
