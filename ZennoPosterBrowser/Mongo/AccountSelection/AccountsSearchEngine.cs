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

        public IEnumerable<string> FreeSearchAccounts(string market, string project, string accountName)
        {
            if(!string.IsNullOrEmpty(market)
                && !string.IsNullOrEmpty(project)
                && !string.IsNullOrEmpty(accountName))
            {
                UpdateAccountSettings(market, project);
                BsonDocument filter = new BsonDocument(LastAccountSetting.ColumnName, new BsonDocument("$regex", accountName));
                return RequestToDbForSearch(filter);
            }
            else
            {
                return new List<string>();
            }
        }

        public IEnumerable<string> ExactSearchAccounts(string market, string project, string accountName)
        {
            if (!string.IsNullOrEmpty(market)
                && !string.IsNullOrEmpty(project)
                && !string.IsNullOrEmpty(accountName))
            {
                UpdateAccountSettings(market, project);
                BsonDocument filter = new BsonDocument(LastAccountSetting.ColumnName, accountName);
                return RequestToDbForSearch(filter);
            }
            else
            {
                return new List<string>();
            }
        }

        public bool IsAccountExists(string market, string project, string accountName)
        {
            IEnumerable<string> accounts = ExactSearchAccounts(market, project, accountName);
            bool isExists = accounts.Any(a => a.Contains(accountName));
            return isExists;
        }

        private IEnumerable<string> RequestToDbForSearch(BsonDocument accountSearchFilter)
        {

            try
            {
                IMongoCollection<BsonDocument> collection = _accountsCollectionConnector.Collection;
                return collection.Find(accountSearchFilter).ToList()
                    .Take(50)
                    .Select(x => x[LastAccountSetting.ColumnName].AsString);
            }
            catch
            {
                return new List<string>();
            }
            
        }

        private void UpdateAccountSettings(string market, string project)
        {
            if (_accountsCollectionConnector == null
                || LastAccountSetting == null
                || market != LastAccountSetting.MarketName
                || project != LastAccountSetting.ProjectName)
            {
                SetNewAccountSettings(market, project);
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
