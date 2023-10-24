using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle_Info.views
{
    public interface INewVehicleView
    {
        //properties
        string registrationNo { get; set; }
        string modelName { get; set; }
        string noSeatsStr { get; set; }
        Color selectedColor { get; set; }
        string selectedColorRow { get; }
        HashSet<String> selectedColorList { get; set; }

        //events
        event EventHandler addButtonClicked;
        event EventHandler clearButtonClicked;
        event EventHandler colorSelectBtnClicked;
        event EventHandler addColorBtnClicked;
        event EventHandler deleteColorBtnClicked;
    }
}
