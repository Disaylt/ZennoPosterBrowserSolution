using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoLab.InterfacesLibrary.ProjectModel;
using ZennoPosterBrowser.Forms.Base;
using ZennoPosterBrowser.Models.BSON;
using ZennoPosterBrowser.Mongo.AccountsCreator;
using ZennoPosterBrowser.Mongo.AccountSelection;
using ZennoPosterBrowser.Mongo.BrowserCollections;
using ZennoPosterBrowser.Services.Accounts;

namespace ZennoPosterBrowser.Forms.AccountCreator
{
    internal class AccountCreatorFormEventHandler : IFormEventHandler
    {
        private readonly AccountCreatorForm _form;
        private readonly IZennoPosterProjectModel _project;
        private readonly AccountsSearchEngine _accountsSearchEngine;
        public AccountCreatorFormEventHandler(IZennoPosterProjectModel project, AccountCreatorForm accountCreatorForm)
        {
            _form = accountCreatorForm;
            _project = project;
            _accountsSearchEngine = new AccountsSearchEngine();
        }

        public void AddControlsEvent()
        {
            _form.FormControls.ButtonForCreateAccounts.Click += SaveAccount;
        }

        protected virtual void SaveAccount(object sender, EventArgs e)
        {
            string accountName = _form.FormControls.TextBoxForWriteAccountName.Text;
            string projectName = _form.FormControls.ComboBoxForSelectProject.SelectedItem as string;
            string marketName = _form.FormControls.ComboBoxForSelectMarket.SelectedItem as string;

            if(string.IsNullOrEmpty(accountName)
                || string.IsNullOrEmpty(projectName)
                || string.IsNullOrEmpty(marketName))
            {
                return;
            }

            AccountsSettingsCollection accountsSettings = new AccountsSettingsCollection();
            AccountsSettingsModel settings = accountsSettings.FindSettings(marketName, projectName);

            if(settings == null)
            {
                return;
            }

            if(!_accountsSearchEngine.IsAccountExists(marketName,projectName, accountName)
                && settings.IsEnableCreate)
            {
                MongoAccountCreator mongoAccountCreator = new MongoAccountCreator(settings);
                mongoAccountCreator.AddSession(accountName);
                SessionManager.SaveAccount(settings.FolderPath, accountName, _project);
                _form.FormControls.TextBoxForWriteAccountName.Text = string.Empty;
            }
        }
    }
}
