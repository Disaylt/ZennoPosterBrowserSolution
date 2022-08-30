using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartProxyV2_ZennoLabVersion;
using SmartProxyV2_ZennoLabVersion.Models;
using SmartProxyV2_ZennoLabVersion.MongoModels;
using ZennoLab.CommandCenter;
using ZennoPosterBrowser.Logger;
using ZennoPosterBrowser.Services.Logger;

namespace ZennoPosterBrowser.Services.VPN
{
    internal class SmartProxyV2Handler : IVPN, IProxyActions
    {
        protected readonly Instance Instance;
        protected ProxyModel Proxy { get; set; }

        public SmartProxyV2Handler(Instance instance)
        {
            Instance = instance;
        }

        public virtual void TurnOffProxy()
        {
            SmartProxyHandler.OpenPort(Proxy.PortData);
        }

        public virtual void TurnOnProxy()
        {
            if(Proxy == null)
            {
                Proxy = SmartProxyHandler.GetMoscowProxy();
            }
            UpdateInstanceProxy();
        }

        public virtual void UpdateBroswerProxy()
        {
            TurnOffProxy();
            Proxy = SmartProxyHandler.GetMoscowProxy();
            UpdateInstanceProxy();
        }

        private void UpdateInstanceProxy()
        {
            string proxyString = $"{Proxy.User}:{Proxy.Password}@{Proxy.Ip}:{Proxy.PortData.PortNum}";
            Instance.SetProxy(proxyString);
            LoggerStorage.Logger.WriteInfo(new FileInfoMessageBuilder($"Set proxy - {proxyString}"));
        }
    }
}
