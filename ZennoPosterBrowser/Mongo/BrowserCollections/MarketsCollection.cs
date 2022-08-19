using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterBrowser.Configs;
using ZennoPosterBrowser.Models.BSON;

namespace ZennoPosterBrowser.Mongo.BrowserCollections
{
    internal class MarketsCollection : BrowserDatabaseConnector, IMongoCollectionConnector<MarketNameModel>, IMarketNamesStorage
    {
        private const string _collectionName = "Markets";

        public MarketsCollection()
        {
            Collection = DataBase.GetCollection<MarketNameModel>(_collectionName);
            AllMarketNames = LoadAllMarkets();
        }

        public IEnumerable<string> AllMarketNames { get; }
        public IMongoCollection<MarketNameModel> Collection { get; }

        private IEnumerable<string> LoadAllMarkets()
        {
            IEnumerable<string> accountsSettings = Collection
                .Find(new BsonDocument())
                .ToList()
                .Select(x => x.MarketName);
            return accountsSettings;
        }
    }
}