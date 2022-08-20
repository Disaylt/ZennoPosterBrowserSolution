using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZennoPosterBrowser.Mongo
{
    internal class MongoCollectionConnector<T> : IMongoCollectionConnector<T>
    {
        public MongoCollectionConnector(string databaseName, string collectonName)
        {
            MongoConnector connector = new MongoConnector();
            var database = connector.GetDatabase(databaseName);
            Collection = database.GetCollection<T>(collectonName);
        }

        public IMongoCollection<T> Collection { get; }
    }
}
