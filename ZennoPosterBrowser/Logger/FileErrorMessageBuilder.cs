using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZennoPosterBrowser.Logger
{
    internal class FileErrorMessageBuilder : ErrorMessage
    {
        private readonly string _descriptionError;
        public FileErrorMessageBuilder(Exception exception, string descriptionError = "") : base(exception)
        {
            _descriptionError = descriptionError;
        }

        public override string GetMessage()
        {
            StringBuilder stringBuilder = new StringBuilder();
            string firstAndLastLine = "----------------------------";
            stringBuilder.AppendLine(firstAndLastLine);
            stringBuilder.AppendLine("Error");
            stringBuilder.AppendLine($"Date: {DateTime.Now}");
            stringBuilder.AppendLine($"Message: {Exception.Message}");
            stringBuilder.AppendLine($"Description: {_descriptionError}");
            stringBuilder.AppendLine($"StackTrace: {Exception.StackTrace}");
            stringBuilder.AppendLine(firstAndLastLine);
            return stringBuilder.ToString();
        }
    }
}
