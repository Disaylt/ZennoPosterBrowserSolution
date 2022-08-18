using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterBrowser.Models.JSON.FormSettings;

namespace ZennoPosterBrowser.Forms.Base
{
    internal interface IFormSettings<in T, out Y> 
        where T : FromSettingLocationModel 
        where Y : FromSettingLocationModel
    {
        Y Load();
        void Save(T setting);
    }
}
