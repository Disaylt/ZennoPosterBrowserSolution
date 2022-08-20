using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZennoPosterBrowser.Models.BSON
{
    internal class BsonIdModel
    {
        [BsonId]
        public BsonObjectId Id { get; set; }
    }
}
