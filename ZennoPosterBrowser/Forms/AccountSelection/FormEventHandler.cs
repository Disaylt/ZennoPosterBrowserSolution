using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZennoPosterBrowser.Forms.Base;
using ZennoPosterBrowser.Models.JSON.FormSettings;

namespace ZennoPosterBrowser.Forms.AccountSelection
{
    internal class FormEventHandler : IFormEventHandler
    {
        private AccountSelectionForm _accountSelectionForm;
        private AccountSelectinFormSettings _accountSelectinFormSettings;
        public FormEventHandler(BaseForm baseForm)
        {
            _accountSelectionForm = baseForm as AccountSelectionForm;
            _accountSelectinFormSettings = _accountSelectionForm.FormSettings.Load();
        }

        public void AddControlsEvent()
        {
            _accountSelectionForm.FormControls.TextBox.TextChanged += LoadAccounts;
            _accountSelectionForm.Form.FormClosed += SaveSettings;
        }

        protected virtual void LoadAccounts(object sender, EventArgs e)
        {
            _accountSelectionForm.Form.Close();
        }

        protected virtual void SaveSettings(object sender, FormClosedEventArgs e)
        {
            _accountSelectinFormSettings.LastChooseMarket = "WB";
            _accountSelectinFormSettings.LastChooseProject = "Компания";
            _accountSelectinFormSettings.LocationY = _accountSelectionForm.Form.Location.Y;
            _accountSelectinFormSettings.LocationX = _accountSelectionForm.Form.Location.X;
            _accountSelectionForm.FormSettings.Save(_accountSelectinFormSettings);
        }
    }
}
