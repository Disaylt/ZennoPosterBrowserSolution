using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZennoPosterBrowser.Forms.AccountSelection
{
    internal class AccountSelectionConfig
    {
        private readonly BaseConfig _baseConfig;

        public AccountSelectionConfig()
        {
            _baseConfig = BaseConfig.Instance;
        }
    }
}
