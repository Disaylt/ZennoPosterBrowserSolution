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
    internal class ProjectNamesStorageDbLoader : IProjectNamesStorage
    {
        public ProjectNamesStorageDbLoader()
        {
            AllProjectNames = LoadMarketNames();
        }

        public IEnumerable<string> AllProjectNames { get; }

        private static IEnumerable<string> LoadMarketNames()
        {
            IMongoCollectionConnector<ProjectNameModel> markets = new ProjectsCollection();
            IMongoCollection<ProjectNameModel> coll = markets.Collection;
            return coll.Find(new BsonDocument())
                .ToList()
                .Select(x => x.ProjectName);
        }
    }
}
