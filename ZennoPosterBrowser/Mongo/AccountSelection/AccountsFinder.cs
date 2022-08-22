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
    internal class AccountsSearchEngine
    {
        private readonly IEnumerable<AccountsSettingsModel> _accountsSettings;
        private MongoCollectionConnector<BsonDocument> _accountsCollectionConnector;

        public AccountsSearchEngine()
        {
            LastAccountSetting = new AccountsSettingsModel();
            _accountsSettings = new AccountsSettingsCollection().AccountsSettings;
        }

        public AccountsSettingsModel LastAccountSetting { get; private set; }

        public IEnumerable<string> SearchAccounts(string market, string project, string accountName)
        {
            if(!string.IsNullOrEmpty(market)
                && !string.IsNullOrEmpty(project)
                && !string.IsNullOrEmpty(accountName))
            {
                return RequestToDbForSearch(market, project, accountName);
            }
            else
            {
                return new List<string>();
            }
        }

        private IEnumerable<string> RequestToDbForSearch(string market, string project, string accountName)
        {

            if(_accountsCollectionConnector == null
                || LastAccountSetting == null
                || market != LastAccountSetting.MarketName
                || project != LastAccountSetting.ProjectName)
            {
                SetNewAccountSettings(market, project);
            }
            try
            {
                IMongoCollection<BsonDocument> collection = _accountsCollectionConnector.Collection;
                BsonDocument filter = new BsonDocument("session", new BsonDocument("$regex", accountName));
                return collection.Find(filter).ToList()
                    .Take(50)
                    .Select(x => x[LastAccountSetting.ColumnName].AsString);
            }
            catch (Exception)
            {
                return new List<string>();
            }
            
        }

        private void SetNewAccountSettings(string market, string project)
        {
            LastAccountSetting = _accountsSettings
                .Where(x => x.MarketName == market && x.ProjectName == project)
                .FirstOrDefault();
            if (LastAccountSetting != null)
            {
                _accountsCollectionConnector = new MongoCollectionConnector<BsonDocument>(LastAccountSetting.DataBase, LastAccountSetting.Collection);
            }
            else
            {
                _accountsCollectionConnector = null;
            }
        }
    }
}
