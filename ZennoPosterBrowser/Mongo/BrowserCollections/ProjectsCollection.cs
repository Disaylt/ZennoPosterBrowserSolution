using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterBrowser.Models.BSON;

namespace ZennoPosterBrowser.Mongo.BrowserCollections
{
    internal class ProjectsCollection : BrowserDatabaseConnector, IMongoCollectionConnector<ProjectNameModel>
    {
        private const string _collectionName = "Projects";

        public ProjectsCollection()
        {
            Collection = DataBase.GetCollection<ProjectNameModel>(_collectionName);
        }

        public IMongoCollection<ProjectNameModel> Collection { get; }
    }
}
