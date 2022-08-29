using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZennoPosterBrowser.Logger
{
    internal abstract class InfoMessage
    {
        protected string Message { get; }
        public InfoMessage(string message)
        {
            Message = message;
        }
        public abstract string GetMessage();
    }
}
