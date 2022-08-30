using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZennoPosterBrowser.Logger
{
    internal class FileInfoMessageBuilder : InfoMessage
    {
        public FileInfoMessageBuilder(string message) : base(message)
        {

        }

        public override string GetMessage()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("INFO");
            stringBuilder.AppendLine($"Date: {DateTime.Now}");
            stringBuilder.AppendLine($"Guid: {Program.CurrentGuid}");
            stringBuilder.AppendLine($"Message: {Message}");
            stringBuilder.AppendLine("----------------------------");
            return stringBuilder.ToString();
        }
    }
}
