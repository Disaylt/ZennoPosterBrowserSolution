using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterBrowser.Configs;

namespace ZennoPosterBrowser.Logger
{
    internal class FileLogger : ILogger<FileInfoMessageBuilder, FileErrorMessageBuilder>
    {
        private readonly string _loggerDirectory;
        private static FileLogger _instance;
        private readonly static object _lock = new object();

        private FileLogger()
        {
            _instance = new FileLogger();
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

        public void WriteError(FileErrorMessageBuilder error)
        {
            lock (_lock)
            {
                string fileName = $"Error - {DateTime.Now.Date}";
                File.WriteAllText($"{_loggerDirectory}{fileName}", error.GetMessage());
            }
        }

        public void WriteInfo(FileInfoMessageBuilder info)
        {
            lock(_lock)
            {
                string fileName = $"INFO - {DateTime.Now.Date}";
                File.WriteAllText($"{_loggerDirectory}{fileName}", info.GetMessage());
            }
        }

        private string CreateLoggerDirectory()
        {
            BaseConfig baseConfig = BaseConfig.Instance;
            
            string loggerFolder = $@"{ baseConfig.ProjectPath}Loggs\";

            if(Directory.Exists(loggerFolder))
            {
                Directory.CreateDirectory(loggerFolder);
            }
            return loggerFolder;
        }
    }
}
