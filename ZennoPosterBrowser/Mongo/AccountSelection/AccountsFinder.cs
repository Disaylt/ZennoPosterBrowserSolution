using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterBrowser.Models.BSON;
using ZennoPosterBrowser.Mongo.BrowserCollections;

namespace ZennoPosterBrowser.Mongo.AccountSelection
{
    internal class AccountsFinder
    {
        private readonly IEnumerable<AccountsSettingsModel> _accountsSettings;

        public AccountsFinder()
        {
            _accountsSettings = LoadAccountsSettings();
        }

        private IEnumerable<AccountsSettingsModel> LoadAccountsSettings()
        {
            AccountsSettingsCollection accountsSettingsCollection = new AccountsSettingsCollection();
            IMongoCollection<AccountsSettingsModel> collection = accountsSettingsCollection.Collection;
            IEnumerable<AccountsSettingsModel> accountsSettings = collection
                .Find(new BsonDocument())
                .ToList();
            return accountsSettings;
        }
    }
}
