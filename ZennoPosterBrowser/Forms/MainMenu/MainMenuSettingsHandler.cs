using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterBrowser.Forms.Base;
using ZennoPosterBrowser.Models.JSON.MainMenu;

namespace ZennoPosterBrowser.Forms.MainMenu
{
    internal class MainMenuSettingsHandler : FormSettingsFileLoader<MainMenuSettingsModel, MainMenuSettingsModel, MainMenuForm>
    {
        private static MainMenuSettingsModel _defaultSetting = new MainMenuSettingsModel
        {
            BookmarkName1 = string.Empty, 
            BookmarkName2 = string.Empty,
            BookmarkName3 = string.Empty,
            BookmarkName4 = string.Empty
        };

        public MainMenuSettingsHandler() : base(_defaultSetting)
        {
        }
    }
}
