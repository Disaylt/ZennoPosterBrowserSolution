using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZennoPosterBrowser.Mongo
{
    internal class BrowserDatabaseConnector : MongoConnector
    {
        private const string _databaseName = "ZennoposterBrowser";
        private static IMongoDatabase _mongoDatabase;

        public BrowserDatabaseConnector()
        {
            if(_mongoDatabase == null)
            {
                _mongoDatabase = GetDatabase(_databaseName);
            }
        }

        public IMongoDatabase DataBase => _mongoDatabase;
    }
}
