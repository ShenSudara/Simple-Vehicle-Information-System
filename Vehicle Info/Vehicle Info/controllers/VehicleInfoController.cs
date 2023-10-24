using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vehicle_Info.config;
using Vehicle_Info.models;
using Vehicle_Info.views;

namespace Vehicle_Info.controllers
{
    class VehicleInfoController
    {
        //attributes
        private IVehicleInfoView vehicleInfoView;
        private VehicleInfoModel vehicleInfoModel;

        //constructor: get the model/view from vehicle info and trigger events
        public VehicleInfoController(VehicleInfoView vehicleInfoView, VehicleInfoModel vehicleInfoModel)
        {
            this.vehicleInfoView = vehicleInfoView;
            this.vehicleInfoModel = vehicleInfoModel;

            vehicleInfoView.formLoaded += VehicleInfoView_formLoaded;

            vehicleInfoView.ShowDialog();
        }

        //when the Vehicle Info Form load this will trigger
        private void VehicleInfoView_formLoaded(object sender, EventArgs e)
        {
            try
            {
                setSingleVehicleData(vehicleInfoModel.registrationNo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(null, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //get the single vehicle data from the database
        private void setSingleVehicleData(string registrationNo)
        {
            DatabaseConnection con = new DatabaseConnection();
            con.openConnection();

            SqlCommand cmd = new SqlCommand(@"SELECT V.reg_no, V.model_name, V.no_of_seat, VC.color_code FROM vehicle_tbl V INNER JOIN  vehicle_color_tbl VC ON V.reg_no = VC.reg_no WHERE V.reg_no = @reg_no");
            cmd.Parameters.AddWithValue("@reg_no", registrationNo);
            DataTable dt = new DataTable();
            dt = con.getDataTable(cmd);
            
            //set data to view
            vehicleInfoView.registrationNo = dt.Rows[0][0].ToString();
            vehicleInfoView.modelName = dt.Rows[0][1].ToString();
            vehicleInfoView.noSeatsStr = dt.Rows[0][2].ToString();

            HashSet<String> colorList = new HashSet<string>();
            foreach (DataRow dr in dt.Rows)
            {
                colorList.Add(dr[3].ToString());
            }
            vehicleInfoView.selectedColorList = colorList;

            con.closeConnection();
        }
    }
}
