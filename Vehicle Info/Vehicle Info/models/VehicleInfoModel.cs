using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle_Info.models
{
    class VehicleInfoModel
    {
        //constructor: default
        public VehicleInfoModel()
        {
        }

        //constructor: Initialize the current model
        public VehicleInfoModel(string registrationNo, string modelName, int noOfSeats, HashSet<string> vehicleColorList)
        {
            this.registrationNo = registrationNo;
            this.modelName = modelName;
            this.noOfSeats = noOfSeats;
            this.vehicleColorList = vehicleColorList;
        }

        //properites
        public String registrationNo { get; set; }
        public String modelName { get; set; }
        public int noOfSeats { get; set; }
        public HashSet<String> vehicleColorList { get; set; }
    }
}
