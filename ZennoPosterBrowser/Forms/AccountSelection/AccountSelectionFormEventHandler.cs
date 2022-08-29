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
using ZennoPosterBrowser.Mongo.AccountSelection;

namespace ZennoPosterBrowser.Forms.AccountSelection
{
    internal class AccountSelectionFormEventHandler : IFormEventHandler
    {
        private readonly AccountSelectionForm _accountSelectionForm;
        private readonly AccountSelectinFormSettings _accountSelectinFormSettings;
        private readonly AccountsSearchEngine _accountsSearchEngine;
        public AccountSelectionFormEventHandler(BaseForm baseForm)
        {
            _accountSelectionForm = baseForm as AccountSelectionForm;
            _accountSelectinFormSettings = _accountSelectionForm.FormSettings.Load();
            _accountsSearchEngine = new AccountsSearchEngine();
        }

        public void AddControlsEvent()
        {
            _accountSelectionForm.Form.Load += LoadSettings;
            _accountSelectionForm.Form.FormClosed += SaveSettings;
            _accountSelectionForm.FormControls.FindAccount.Click += FindAccounts;
            _accountSelectionForm.FormControls.Grid.MouseDoubleClick += ChooseAccount;
        }

        protected virtual void LoadAccounts(object sender, EventArgs e)
        {
            _accountSelectionForm.Form.Close();
        }

        protected virtual void LoadSettings(object sender, EventArgs e)
        {
            _accountSelectionForm.FormControls.SelectMarket.SelectedItem = _accountSelectinFormSettings.LastChooseMarket;
            _accountSelectionForm.FormControls.SelectProject.SelectedItem = _accountSelectinFormSettings.LastChooseProject;
        }

        protected virtual void SaveSettings(object sender, FormClosedEventArgs e)
        {
            _accountSelectinFormSettings.LastChooseMarket = _accountSelectionForm.FormControls.SelectMarket.SelectedItem as string ?? string.Empty;
            _accountSelectinFormSettings.LastChooseProject = _accountSelectionForm.FormControls.SelectProject.SelectedItem as string ?? string.Empty;
            _accountSelectionForm.FormSettings.Save(_accountSelectinFormSettings);
        }

        protected virtual void FindAccounts(object sender, EventArgs e)
        {
            IEnumerable<string> accounts = _accountsSearchEngine.FreeSearchAccounts(
                _accountSelectionForm.FormControls.SelectMarket.SelectedItem as string,
                _accountSelectionForm.FormControls.SelectProject.SelectedItem as string,
                _accountSelectionForm.FormControls.TextBox.Text
                );
            FillAccountToDataGrid(accounts);
        }

        protected virtual void ChooseAccount(object sender, MouseEventArgs e)
        {
            BrowserConfig browserConfig = BrowserConfig.Instance;
            browserConfig.CurrentSession = (string)_accountSelectionForm.FormControls.Grid.SelectedCells[0].Value;
            browserConfig.PathToSession = _accountsSearchEngine.LastAccountSetting.FolderPath;
            _accountSelectionForm.NextAction = BrowserProjectActions.LoadingSession;
            _accountSelectionForm.Form.Close();
        }

        private void FillAccountToDataGrid(IEnumerable<string> accounts)
        {
            _accountSelectionForm.FormControls.Grid.Rows.Clear();
            foreach (string account in accounts)
            {
                _accountSelectionForm.FormControls.Grid.Rows.Add(account);
            }
        }
    }
}
