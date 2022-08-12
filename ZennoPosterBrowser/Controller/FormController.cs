using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZennoPosterBrowser.Controller
{
    internal abstract class FormController
    {
        public Form Form { get; }

        public FormController(string name)
        {
            Form = new Form();
            Form.Name = name;
        }
    }
}
