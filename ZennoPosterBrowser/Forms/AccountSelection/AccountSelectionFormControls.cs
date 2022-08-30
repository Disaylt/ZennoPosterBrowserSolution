using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZennoPosterBrowser.Configs;
using ZennoPosterBrowser.Forms.AccountSelection.Controls;
using ZennoPosterBrowser.Forms.Base;
using ZennoPosterBrowser.Forms.BaseControls;

namespace ZennoPosterBrowser.Forms.AccountSelection
{
    internal class AccountSelectionFormControls : IFormControls
    {
        public List<Control> Controls { get; }

        public AccountSelectionFormControls()
        {
            Controls = new List<Control>
            {
                Grid,
                TextBox,
                SelectMarket,
                SelectProject,
                FindAccount,
                AdditionAccounts
            };
        }

        private ComboBox _selectProject;
        public virtual ComboBox SelectProject
        {
            get
            {
                if(_selectProject == null)
                {
                    IEnumerable<string> projectNames = BrowserConfig.Instance.ProjectNamesStorage.AllProjectNames;
                    ComboBoxBuilder comboBoxBuilder = new SelectProjectComboBoxBuilder(projectNames);
                    _selectProject = comboBoxBuilder.Create();
                }
                return _selectProject;
            }
        }

        private ComboBox _selectMarket;
        public virtual ComboBox SelectMarket
        {
            get
            {
                if(_selectMarket == null)
                {
                    IEnumerable<string> marketNames = BrowserConfig.Instance.MarketNamesStorage.AllMarketNames;
                    ComboBoxBuilder comboBoxBuilder = new SelectMarketComboBoxBuilder(marketNames);
                    _selectMarket = comboBoxBuilder.Create();
                }
                return _selectMarket;
            }
        }

        private Button _additionAccounts;
        public virtual Button AdditionAccounts
        {
            get
            {
                if(_additionAccounts == null)
                {
                    ButtonForAdditionAccountsBuilder buttonForAdditionAccountsBuilder = new ButtonForAdditionAccountsBuilder();
                    _additionAccounts = buttonForAdditionAccountsBuilder.Create();
                }
                return _additionAccounts;
            }
        }

        private Button _findAccount;
        public virtual Button FindAccount 
        { 
            get 
            { 
                if(_findAccount == null)
                {
                    FindAccountButtonBuilder findAccountButton = new FindAccountButtonBuilder();
                    _findAccount = findAccountButton.Create();
                }
                return _findAccount; 
            } 
        }

        private DataGridView _grid;
        public virtual DataGridView Grid
        {
            get
            {
                if(_grid == null)
                {
                    AccountsDataGridBuilder accountSelectionDataGrid = new AccountsDataGridBuilder();
                    _grid = accountSelectionDataGrid.Create();
                }
                return _grid;
            }
        }

        private TextBox _textBox;
        public virtual TextBox TextBox
        {
            get
            {
                if(_textBox == null)
                {
                    SearchTextBoxBuilder searchTextBoxBuilder = new SearchTextBoxBuilder();
                    _textBox = searchTextBoxBuilder.Create();
                }
                return _textBox;
            }
        }

        public List<Control> GetFormControls()
        {
            return Controls;
        }
    }
}
