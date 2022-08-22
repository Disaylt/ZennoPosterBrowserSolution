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
        private AccountsSettingsModel _lastAccountSetting;
        private MongoCollectionConnector<BsonDocument> _accountsCollectionConnector;

        public AccountsSearchEngine()
        {
            _lastAccountSetting = new AccountsSettingsModel();
            _accountsSettings = new AccountsSettingsCollection().AccountsSettings;
        }

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
                || _lastAccountSetting == null
                || market != _lastAccountSetting.MarketName
                || project != _lastAccountSetting.ProjectName)
            {
                SetNewAccountSettings(market, project);
            }
            try
            {
                IMongoCollection<BsonDocument> collection = _accountsCollectionConnector.Collection;
                BsonDocument filter = new BsonDocument("session", new BsonDocument("$regex", accountName));
                return collection.Find(filter).ToList()
                    .Take(50)
                    .Select(x => x[_lastAccountSetting.ColumnName].AsString);
            }
            catch (Exception)
            {
                return new List<string>();
            }
            
        }

        private void SetNewAccountSettings(string market, string project)
        {
            _lastAccountSetting = _accountsSettings
                .Where(x => x.MarketName == market && x.ProjectName == project)
                .FirstOrDefault();
            if (_lastAccountSetting != null)
            {
                _accountsCollectionConnector = new MongoCollectionConnector<BsonDocument>(_lastAccountSetting.DataBase, _lastAccountSetting.Collection);
            }
            else
            {
                _accountsCollectionConnector = null;
            }
        }
    }
}
