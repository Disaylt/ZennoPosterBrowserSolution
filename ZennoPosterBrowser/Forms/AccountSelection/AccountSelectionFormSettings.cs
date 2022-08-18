using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterBrowser.Forms.Base;
using ZennoPosterBrowser.Models.JSON.FormSettings;

namespace ZennoPosterBrowser.Forms.AccountSelection
{
    internal class AccountSelectionFormSettings : FormSettingsFileLoader<AccountSelectinFormSettings>
    {
        private const string _fileName = "AccountSelectionFormSettings.json";
        private static AccountSelectinFormSettings DefaultSettings
        {
            get
            {
                AccountSelectinFormSettings accountSelectinFormSettings = new AccountSelectinFormSettings
                {
                    LastChooseMarket = string.Empty,
                    LastChooseProject = string.Empty,
                    LocationX = 0,
                    LocationY = 0
                };
                return accountSelectinFormSettings;
            }
        }

        public AccountSelectionFormSettings() : base(_fileName, DefaultSettings) { }
        public AccountSelectionFormSettings(AccountSelectinFormSettings defaultSettings) : base(_fileName, defaultSettings) { }
    }
}
