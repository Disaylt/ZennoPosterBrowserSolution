using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoLab.CommandCenter;
using ZennoPosterBrowser.Configs;
using ZennoPosterBrowser.Forms.Base;
using ZennoPosterBrowser.Forms.Bookmarks;
using ZennoPosterBrowser.Models.JSON.MainMenu;

namespace ZennoPosterBrowser.Forms.MainMenu
{
    internal class MainMenuForm : BaseForm
    {
        private const string _nameForm = "Главное меню";
        private readonly IFormEventHandler _formEventHandler;
        public MainMenuForm(Instance instance)
        {
            Instance = instance;
            BookmarksJsonStorage = new BookmarksJsonStorage();
            FormSettings = new MainMenuSettingsHandler();
            FormControls = new MainMenuFormControls(BookmarksJsonStorage);
            _formEventHandler = new MainMenuFormEventHandler(this);
            NextAction = BrowserProjectActions.CloseBrowser;
            Form.Size = new Size(400, 500);
            Form.Name = _nameForm;
            AddControls(FormControls);
            AddEvents(_formEventHandler);
        }
        public IFormControls FormControls { get; }
        public BrowserProjectActions NextAction { get; set; }
        public IFormSettings<MainMenuSettingsModel, MainMenuSettingsModel> FormSettings { get;  }
        public IBookmarksStorage BookmarksJsonStorage { get; }
        public Instance Instance { get; }
    }
}
