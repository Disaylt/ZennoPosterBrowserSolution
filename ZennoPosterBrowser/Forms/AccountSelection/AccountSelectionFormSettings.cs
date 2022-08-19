using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterBrowser.Forms.Base;
using ZennoPosterBrowser.Models.JSON.FormSettings;

namespace ZennoPosterBrowser.Forms.AccountSelection
{
    internal class AccountSelectionFormSettings : FormSettingsFileLoader<AccountSelectinFormSettings, AccountSelectinFormSettings, AccountSelectionForm>
    {
        private static AccountSelectinFormSettings DefaultSettings
        {
            get
            {
                AccountSelectinFormSettings accountSelectinFormSettings = new AccountSelectinFormSettings
                {
                    LastChooseMarket = string.Empty,
                    LastChooseProject = string.Empty
                };
                return accountSelectinFormSettings;
            }
        }

        public AccountSelectionFormSettings() : base(DefaultSettings) { }
        public AccountSelectionFormSettings(AccountSelectinFormSettings defaultSettings) : base(defaultSettings) { }
    }
}
