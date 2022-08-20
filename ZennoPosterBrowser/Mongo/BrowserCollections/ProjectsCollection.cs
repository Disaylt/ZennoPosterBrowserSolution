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
    internal class ProjectsCollection : BrowserDatabaseConnector, IMongoCollectionConnector<ProjectNameModel>, IProjectNamesStorage
    {
        private const string _collectionName = "Projects";

        public ProjectsCollection()
        {
            Collection = DataBase.GetCollection<ProjectNameModel>(_collectionName);
            AllProjectNames = LoadAllProjects();
        }

        public IEnumerable<string> AllProjectNames { get; }
        public IMongoCollection<ProjectNameModel> Collection { get; }

        private IEnumerable<string> LoadAllProjects()
        {
            IEnumerable<string> accountsSettings = Collection
                .Find(new BsonDocument())
                .ToList()
                .Select(x => x.ProjectName);
            return accountsSettings;
        }
    }
}
