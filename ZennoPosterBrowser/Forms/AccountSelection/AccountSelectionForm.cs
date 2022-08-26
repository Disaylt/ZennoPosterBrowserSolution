using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZennoPosterBrowser.Configs;
using ZennoPosterBrowser.Forms.Base;
using ZennoPosterBrowser.Models.JSON.FormSettings;
using ZennoPosterBrowser.Services.FormSettings;

namespace ZennoPosterBrowser.Forms.AccountSelection
{
    internal class AccountSelectionForm : BaseForm
    {
        private const string _nameForm = "Выбор аккаунтов";
        private readonly AccountSelectionFormEventHandler _formEventHandler;
        public AccountSelectionForm() : base()
        {
            FormSettings = new AccountSelectionFormSettings();
            FormControls = new AccountSelectionFormControls();
            _formEventHandler = new AccountSelectionFormEventHandler(this);
            Form.Size = new Size(400, 500);
            Form.Name = _nameForm;
            AddControls(FormControls);
            AddEvents(_formEventHandler);
            NextAction = BrowserProjectActions.CloseBrowser;
        }
        public BrowserProjectActions NextAction { get; set; }
        public AccountSelectionFormControls FormControls { get; }
        public IFormSettings<AccountSelectinFormSettings, AccountSelectinFormSettings> FormSettings { get; }
    }
}
