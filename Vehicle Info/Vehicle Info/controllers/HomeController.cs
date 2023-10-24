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
    class HomeController
    {
        //attributes
        private HomeModel homeModel;
        private IHomeView homeView;

        private NewVehicleView newVehicleView;
        private NewVehicleModel newVehicleModel;
        private NewVehicleController newVehicleController;

        private VehicleInfoView vehicleInfoView;
        private VehicleInfoModel vehicleInfoModel;
        private VehicleInfoController vehicleInfoConttroller;

        //constructor: Get the model/view and trigger events
        public HomeController(HomeModel homeModel, HomeView homeView)
        {
            this.homeModel = homeModel;
            this.homeView = homeView;

            //setup events
            homeView.newVehicleBtnClicked += HomeView_newVehicleBtnClicked;
            homeView.formLoad += HomeView_formLoad;
            homeView.vehicleInfoBtnClicked += HomeView_vehicleInfoBtnClicked;
        }

        //when the vehicle info btn clicked in the view this trigger
        private void HomeView_vehicleInfoBtnClicked(object sender, EventArgs e)
        {
            try
            {
                if(homeView.selectedVehicleRow != string.Empty)
                {
                    vehicleInfoModel = new VehicleInfoModel();
                    vehicleInfoModel.registrationNo = homeView.selectedVehicleRow;
                    vehicleInfoView = new VehicleInfoView();
                    vehicleInfoConttroller = new VehicleInfoController(vehicleInfoView, vehicleInfoModel);
                }
                else
                {
                    MessageBox.Show(null, "select vehicle to see the information", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(null, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
       
        //when the home view load this trigger
        private void HomeView_formLoad(object sender, EventArgs e)
        {
            try
            {
                if (homeView.isFormLoaded) {
                    loadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(null, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //when the new vehicle btn clicked in the view this trigger
        private void HomeView_newVehicleBtnClicked(object sender, EventArgs e)
        {
            try
            {
                newVehicleView = new NewVehicleView();
                newVehicleModel = new NewVehicleModel();
                newVehicleController = new NewVehicleController(newVehicleModel, newVehicleView);

                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(null, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

      
        }

        //load data from the db to controller
        private void loadData()
        {
            //Retrive Data from the database
            DatabaseConnection con = new DatabaseConnection();
            con.openConnection();

            SqlCommand cmd = new SqlCommand(@"SELECT V.reg_no, V.model_name, V.no_of_seat, COUNT(VC.color_code) as no_of_color FROM vehicle_tbl V INNER JOIN  vehicle_color_tbl VC ON V.reg_no = VC.reg_no GROUP BY V.reg_no, V.model_name, V.no_of_seat ORDER BY V.model_name, V.reg_no asc;");
            DataTable dt = new DataTable();
            dt = con.getDataTable(cmd);

            homeView.showVehicleData(dt);

            con.closeConnection();
        }
    }
}
