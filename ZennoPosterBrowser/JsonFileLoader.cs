using Global.ZennoLab.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZennoPosterBrowser
{
    internal static class JsonFileLoader
    {
        public static T Load<T>(string path)
        {
            string content = File.ReadAllText(path);
            T result = JToken.Parse(content).ToObject<T>();
            return result;
        }
    }
}
