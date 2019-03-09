using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface.MasterSetup
{
    public interface IDepartment
    {
        DataAccessLayer.MasterSetup.DepartmentViewModel Model { get; set; }
        string SaveDepartment();
        DataTable GetDataDepartment(int DepartmentId);
        DataTable DepartmentLevel();
    }
}
