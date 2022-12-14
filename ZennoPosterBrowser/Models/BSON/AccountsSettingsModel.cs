using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZennoPosterBrowser.Models.BSON
{
    internal class AccountsSettingsModel : BsonIdModel
    {
        public string MarketName { get; set; }
        public string ProjectName { get; set; }
        public string DataBase { get; set; }
        public string Collection { get; set; }
        public string FolderPath { get; set; }
        public string ColumnName { get; set; }
        public bool IsEnableCreate { get; set; }
    }
}
