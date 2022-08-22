using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterBrowser.Services.BrowserActions;

namespace ZennoPosterBrowser.Forms.AccountSelection
{
    internal class AccountSelectionFormBrowserAction : IBrowserAction
    {
        private readonly AccountSelectionForm _accountSelectionForm;
        public AccountSelectionFormBrowserAction()
        {
            _accountSelectionForm = new AccountSelectionForm();
        }

        public void Run()
        {
            _accountSelectionForm.Form.ShowDialog();
        }
    }
}
