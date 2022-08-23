using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZennoPosterBrowser.Services.VPN
{
    internal interface IVPN
    {
        void TurnOnProxy();
        void TurnOffProxy();
    }
}
