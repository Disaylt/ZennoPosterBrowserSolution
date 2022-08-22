using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoLab.CommandCenter;

namespace ZennoPosterBrowser.Services.ZennoPosterBrowser
{
    internal class ZennoPosterBrowserManager
    {
        private readonly Instance _instance;
        public ZennoPosterBrowserManager(Instance instance)
        {
            _instance = instance;
        }

        public Configs.BrowserActions WaitUserAction()
        {
            _instance.WaitForUserAction(3600, "Нажмите продолжить для дальнейших действий!");
            return Configs.BrowserActions.OpenMenu;
        }
    }
}
