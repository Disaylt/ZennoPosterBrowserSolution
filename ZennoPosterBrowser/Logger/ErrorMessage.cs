using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZennoPosterBrowser.Logger
{
    internal abstract class ErrorMessage
    {
        protected Exception Exception { get; }
        public ErrorMessage(Exception exception)
        {
            Exception = exception;
        }

        public abstract string GetMessage();
    }
}
