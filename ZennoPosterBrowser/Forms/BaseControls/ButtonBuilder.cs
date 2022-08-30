using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZennoPosterBrowser.Forms.BaseControls
{
    internal abstract class ButtonBuilder
    {
        public ButtonBuilder()
        {
            Control = new Button();
        }

        protected Button Control { get; }

        public abstract Button GetButton();
    }
}
