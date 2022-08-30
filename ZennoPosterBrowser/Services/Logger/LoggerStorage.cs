using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterBrowser.Logger;

namespace ZennoPosterBrowser.Services.Logger
{
    internal static class LoggerStorage
    {
        public static ILogger<InfoMessage, ErrorMessage> Logger { get; } = FileLogger.Instance;
    }
}
