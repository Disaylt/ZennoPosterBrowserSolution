using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZennoPosterBrowser.Configs;
using ZennoPosterBrowser.Forms.AccountCreator.Controls;
using ZennoPosterBrowser.Forms.Base;

namespace ZennoPosterBrowser.Forms.AccountCreator
{
    internal class AccountCreatorFormControls : IFormControls
    {
        private readonly List<Control> _controls;

        public AccountCreatorFormControls()
        {
            _controls = new List<Control>
            {
                ButtonForCreateAccounts,
                TextBoxForWriteAccountName,
                ComboBoxForSelectProject,
                ComboBoxForSelectMarket
            };
        }

        public List<Control> GetFormControls()
        {
            return _controls;
        }

        private Button _buttonForCreateAccounts;
        public Button ButtonForCreateAccounts
        {
            get 
            { 
                if( _buttonForCreateAccounts == null )
                {
                    ButtonForCreateAccountsBuilder buttonForCreateAccountsBuilder = new ButtonForCreateAccountsBuilder();
                    _buttonForCreateAccounts = buttonForCreateAccountsBuilder.Create();
                }
                return _buttonForCreateAccounts; 
            }
        }

        private TextBox _textBoxForWriteAccountName;
        public TextBox TextBoxForWriteAccountName
        {
            get
            {
                if(_textBoxForWriteAccountName == null )
                {
                    TextBoxForWriteAccountNameBuilder textBoxForWriteAccountNameBuilder = new TextBoxForWriteAccountNameBuilder();
                    _textBoxForWriteAccountName = textBoxForWriteAccountNameBuilder.Create();
                }
                return _textBoxForWriteAccountName;
            }
        }

        private ComboBox _comboBoxForSelectProject;
        public ComboBox ComboBoxForSelectProject
        {
            get
            {
                if(_comboBoxForSelectProject == null)
                {
                    var projectNamesLoader = BrowserConfig.Instance.ProjectNamesStorage;
                    ComboBoxForSelectProjectBuilder comboBoxForSelectProjectBuilder = new ComboBoxForSelectProjectBuilder(projectNamesLoader.AllProjectNames);
                    _comboBoxForSelectProject = comboBoxForSelectProjectBuilder.Create();
                }
                return _comboBoxForSelectProject;
            }
        }

        private ComboBox _comboBoxForSelectMarket;
        public ComboBox ComboBoxForSelectMarket
        {
            get
            {
                if(_comboBoxForSelectMarket == null)
                {
                    var marketNamesLoader = BrowserConfig.Instance.MarketNamesStorage;
                    ComboBoxForSelectMarketBuilder comboBoxForSelectMarketBuilder = new ComboBoxForSelectMarketBuilder(marketNamesLoader.AllMarketNames);
                    _comboBoxForSelectMarket = comboBoxForSelectMarketBuilder.Create();
                }
                return _comboBoxForSelectMarket;
            }
        }
    }
}
