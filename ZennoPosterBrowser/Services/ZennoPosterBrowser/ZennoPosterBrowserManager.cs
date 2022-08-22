using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoLab.CommandCenter;
using ZennoPosterBrowser.Configs;

namespace ZennoPosterBrowser.Services.ZennoPosterBrowser
{
    internal class ZennoPosterBrowserManager
    {
        private readonly Instance _instance;
        public ZennoPosterBrowserManager(Instance instance)
        {
            _instance = instance;
        }

        public BrowserProjectActions WaitUserAction()
        {
            _instance.WaitForUserAction(3600, "Нажмите продолжить для дальнейших действий!");
            return BrowserProjectActions.OpenMenu;
        }
    }
}
