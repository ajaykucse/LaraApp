using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface.MasterSetup
{
    public interface INarration
    {
        DataAccessLayer.MasterSetup.NarrationViewModel Model { get; set; }
        string SaveNarration();
        DataTable GetDataNarration(int NarrationId);
    }
}
