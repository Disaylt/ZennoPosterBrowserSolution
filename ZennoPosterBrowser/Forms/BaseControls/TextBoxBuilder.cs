using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZennoPosterBrowser.Forms.BaseControls
{
    internal abstract class TextBoxBuilder
    {
        public TextBoxBuilder()
        {
            Control = new TextBox();
        }
        protected TextBox Control { get; }
        public abstract TextBox GetTextBox();
    }
}
