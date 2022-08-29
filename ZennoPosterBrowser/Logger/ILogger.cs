using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZennoPosterBrowser.Logger
{
    internal interface ILogger<in TInfo, in TError>
    {
        void WriteError(TError error);

        void WriteInfo(TInfo info);
    }
}
