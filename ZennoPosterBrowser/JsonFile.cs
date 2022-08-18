using Global.ZennoLab.Json.Linq;
using Global.ZennoLab.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZennoPosterBrowser
{
    internal static class JsonFile
    {
        public static T Load<T>(string path)
        {
            string content = File.ReadAllText(path);
            T result = JToken.Parse(content).ToObject<T>();
            return result;
        }

        public static void SaveAs<T>(T json, string path)
        {
            string content = JsonConvert.SerializeObject(json);
            File.WriteAllText(path, content);
        }
    }
}
