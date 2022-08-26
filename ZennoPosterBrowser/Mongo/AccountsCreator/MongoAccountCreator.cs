using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterBrowser.Models.BSON;

namespace ZennoPosterBrowser.Mongo.AccountsCreator
{
    internal class MongoAccountCreator
    {
        private readonly MongoCollectionConnector<BsonDocument> _connector;
        private readonly AccountsSettingsModel _settings;

        public MongoAccountCreator(AccountsSettingsModel settings)
        {
            _settings = settings;
            _connector = new MongoCollectionConnector<BsonDocument>(settings.DataBase, settings.Collection);
        }

        public void AddSession(string session)
        {
            BsonDocument sessionElement = new BsonDocument(_settings.ColumnName, session);
            _connector.Collection.InsertOne(sessionElement);
        }
    }
}
