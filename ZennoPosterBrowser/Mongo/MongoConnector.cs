using MongoDB.Driver;
using ZennoPosterBrowser.Configs;

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
            var settings = BaseConfig.Instance.ProjectSettingsLoader;
            string connectString = settings.ProjectSettings.MongoConnectionString;
            MongoClient client = new MongoClient(connectString);
            return client;
        }
    }
}
