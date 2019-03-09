using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.SystemSetting;

namespace DataAccessLayer.Interface.SystemSetting
{
   public interface IEntryControl
    {
       
         SystemControlView SystemControlModel { get; set; }
         List<EntryControlViewModel> EntryControl { get; set; }
        void SaveEntryControl();
        DataTable GetSystemSetting();
        void GetEntryControl(string EntryModule);


    }
}
