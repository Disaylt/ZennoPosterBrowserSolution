using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZennoPosterBrowser.Forms.Base;
using ZennoPosterBrowser.Models.JSON.FormSettings;
using ZennoPosterBrowser.Mongo.AccountSelection;

namespace ZennoPosterBrowser.Forms.AccountSelection
{
    internal class FormEventHandler : IFormEventHandler
    {
        private AccountSelectionForm _accountSelectionForm;
        private AccountSelectinFormSettings _accountSelectinFormSettings;
        private AccountsSearchEngine _accountsSearchEngine;
        public FormEventHandler(BaseForm baseForm)
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
            var accounts = _accountsSearchEngine.SearchAccounts(
                _accountSelectionForm.FormControls.SelectMarket.SelectedItem as string,
                _accountSelectionForm.FormControls.SelectProject.SelectedItem as string,
                _accountSelectionForm.FormControls.TextBox.Text
                );
            int i = 1;
        }
    }
}
