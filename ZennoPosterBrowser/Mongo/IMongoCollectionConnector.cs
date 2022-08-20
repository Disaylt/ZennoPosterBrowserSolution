using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZennoPosterBrowser.Mongo
{
    internal interface IMongoCollectionConnector<T>
    {
        IMongoCollection<T> Collection { get; }
    }
}
