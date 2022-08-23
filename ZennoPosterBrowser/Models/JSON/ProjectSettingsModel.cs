using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZennoPosterBrowser.Models.JSON
{
    internal class ProjectSettingsModel
    {
        public string MongoConnectionString { get; set; }
        public bool IsEnableVPN { get; set; }
    }
}
