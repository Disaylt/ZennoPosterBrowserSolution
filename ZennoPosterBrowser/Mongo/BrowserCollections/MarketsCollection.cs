using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterBrowser.Models.BSON;

namespace ZennoPosterBrowser.Mongo.BrowserCollections
{
    internal class MarketsCollection : BrowserDatabaseConnector, IMongoCollectionConnector<MarketNameModel>
    {
        private const string _collectionName = "Markets";

        public MarketsCollection()
        {
            Collection = DataBase.GetCollection<MarketNameModel>(_collectionName);
        }

        public IMongoCollection<MarketNameModel> Collection { get; }
    }
}