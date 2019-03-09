using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface.MasterSetup
{
    public interface IMainArea
    {
        DataAccessLayer.MasterSetup.MainAreaViewModel Model { get; set; }
        string SaveMainArea();
        DataTable GetDataMainArea(int MainAreaId);
    }
}
