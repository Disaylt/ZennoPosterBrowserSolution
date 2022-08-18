using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterBrowser.Models.JSON;

namespace ZennoPosterBrowser.Forms.Base
{
    internal interface IFormSettings<T> where T : FromSettingLocationModel
    {
        T Load();
        void Save(T setting);
    }
}
