using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle_Info.views
{
    public interface IVehicleInfoView
    {
        //properties
        bool isFormLoaded { get; set; }
        string registrationNo { get; set; }
        string modelName { get; set; }
        string noSeatsStr { get; set; }
        HashSet<String> selectedColorList { get; set; }

        //events
        event EventHandler formLoaded;
    }
}
