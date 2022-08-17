using MongoDB.Driver;

namespace ZennoPosterBrowser.Mongo
{
    internal class MongoConnector
    {
        private static MongoClient _client;

        public MongoConnector()
        {
            if (_client == null)
            {
                _client = CreateClient();
            }
        }

        public IMongoDatabase GetDatabase(string name)
        {
            IMongoDatabase database = _client.GetDatabase(name);
            return database;
        }

        private MongoClient CreateClient()
        {
            MongoSettings settings = new MongoSettings();
            string connectString = settings.GetSettings().ConnectionString;
            MongoClient client = new MongoClient(connectString);
            return client;
        }
    }
}
