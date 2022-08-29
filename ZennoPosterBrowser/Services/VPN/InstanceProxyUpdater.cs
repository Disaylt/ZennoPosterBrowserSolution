using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterBrowser.Configs;
using ZennoPosterBrowser.Services.BrowserActions;

namespace ZennoPosterBrowser.Services.VPN
{
    internal class InstanceProxyUpdater : IBrowserAction
    {
        private readonly IProxyActions _proxyActions;
        public InstanceProxyUpdater(IProxyActions proxyActions)
        {
            _proxyActions = proxyActions;
        }

        public BrowserProjectActions Run()
        {
            _proxyActions.UpdateBroswerProxy();
            return BrowserProjectActions.OpenMenu;
        }
    }
}
