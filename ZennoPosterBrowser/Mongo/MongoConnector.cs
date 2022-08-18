using MongoDB.Driver;
using ZennoPosterBrowser.Configs;

namespace ZennoPosterBrowser.Mongo
{
    internal class MongoConnector
    {
        private static object _locker = new object(); 
        private static MongoClient _client;

        public MongoConnector()
        {
            lock(_locker)
            {
                if (_client == null)
                {
                    _client = CreateClient();
                }
            }
        }

        public IMongoDatabase GetDatabase(string name)
        {
            IMongoDatabase database = _client.GetDatabase(name);
            return database;
        }

        private MongoClient CreateClient()
        {
            var settings = BrowserConfig.Instance.ProjectSettingsLoader;
            string connectString = settings.ProjectSettings.MongoConnectionString;
            MongoClient client = new MongoClient(connectString);
            return client;
        }
    }
}
