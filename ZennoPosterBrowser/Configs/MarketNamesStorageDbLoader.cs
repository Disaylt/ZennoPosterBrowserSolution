using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterBrowser.Models.BSON;
using ZennoPosterBrowser.Mongo;
using ZennoPosterBrowser.Mongo.BrowserCollections;

namespace ZennoPosterBrowser.Configs
{
    internal class MarketNamesStorageDbLoader : IMarketNamesStorage
    {
        public MarketNamesStorageDbLoader()
        {
            AllMarketNames = LoadMarketNames();
        }

        public IEnumerable<string> AllMarketNames { get; }

        private static IEnumerable<string> LoadMarketNames()
        {
            IMongoCollectionConnector<MarketNameModel> markets = new MarketsCollection();
            IMongoCollection<MarketNameModel> coll = markets.Collection;
            return coll.Find(new BsonDocument())
                .ToList()
                .Select(x => x.MarketName);
        }
    }
}
