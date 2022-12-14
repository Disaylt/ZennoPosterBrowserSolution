using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZennoPosterBrowser.Forms.BaseControls
{
    internal abstract class ComboBoxBuilder
    {
        public ComboBoxBuilder()
        {
            Control = new ComboBox();
        }
        protected ComboBox Control { get; }
        public abstract ComboBox GetComboBox();
    }
}
