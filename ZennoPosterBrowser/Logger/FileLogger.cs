using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterBrowser.Configs;

namespace ZennoPosterBrowser.Logger
{
    internal class FileLogger : ILogger<InfoMessage, ErrorMessage>
    {
        private readonly string _loggerDirectory;
        private static FileLogger _instance;
        private readonly static object _lock = new object();

        private FileLogger()
        {
            _loggerDirectory = CreateLoggerDirectory();
        }

        public static FileLogger Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new FileLogger();
                    }
                    return _instance;
                }
            }
        }

        public void WriteError(ErrorMessage error)
        {
            lock (_lock)
            {
                string fileName = $"Error - {DateTime.Now.ToShortDateString()}.txt";
                File.AppendAllText($"{_loggerDirectory}{fileName}", error.GetMessage());
            }
        }

        public void WriteInfo(InfoMessage info)
        {
            lock(_lock)
            {
                string fileName = $"INFO - {DateTime.Now.ToShortDateString()}.txt";
                File.AppendAllText($"{_loggerDirectory}{fileName}", info.GetMessage());
            }
        }

        private string CreateLoggerDirectory()
        {
            BaseConfig baseConfig = BaseConfig.Instance;
            
            string loggerFolder = $@"{ baseConfig.ProjectPath}Loggs\";

            if(!Directory.Exists(loggerFolder))
            {
                Directory.CreateDirectory(loggerFolder);
            }
            return loggerFolder;
        }
    }
}
