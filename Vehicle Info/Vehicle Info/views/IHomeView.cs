using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle_Info.views
{
    public interface IHomeView
    {
        //events
        event EventHandler newVehicleBtnClicked;
        event EventHandler vehicleInfoBtnClicked;
        event EventHandler formLoad;

        //properties
        bool isFormLoaded { get; set; }
        object vehicleData { get; set; }
        string selectedVehicleRow { get; }

        //methods
        void showVehicleData(DataTable dt);
    }
}
