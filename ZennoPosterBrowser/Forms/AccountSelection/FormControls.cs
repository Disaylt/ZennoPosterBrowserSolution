using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZennoPosterBrowser.Configs;
using ZennoPosterBrowser.Forms.Base;
using ZennoPosterBrowser.Forms.BaseControls;

namespace ZennoPosterBrowser.Forms.AccountSelection
{
    internal class FormControls : IFormControls
    {
        public List<Control> Controls { get; }

        public FormControls()
        {
            Controls = new List<Control>();
            Controls.Add(Grid);
            Controls.Add(TextBox);
            Controls.Add(SelectMarket);
            Controls.Add(SelectProject);
        }

        private ComboBox _selectProject;
        public virtual ComboBox SelectProject
        {
            get
            {
                if(_selectProject == null)
                {
                    IEnumerable<string> projectNames = BrowserConfig.Instance.ProjectNamesStorage.ProjectNames;
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
                    IEnumerable<string> marketNames = BrowserConfig.Instance.MarketNamesStorage.MarketNames;
                    ComboBoxBuilder comboBoxBuilder = new SelectMarketComboBoxBuilder(marketNames);
                    _selectMarket = comboBoxBuilder.Create();
                }
                return _selectMarket;
            }
        }

        private DataGridView _grid;
        public virtual DataGridView Grid
        {
            get
            {
                if(_grid == null)
                {
                    AccountSelectionDataGridBuilder accountSelectionDataGrid = new AccountSelectionDataGridBuilder();
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
                    TextBox textBoxSearch = new TextBox();
                    textBoxSearch.Location = new System.Drawing.Point(15, 15);
                    textBoxSearch.Name = "textBoxSearch";
                    textBoxSearch.Size = new System.Drawing.Size(150, 20);
                    _textBox = textBoxSearch;
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
