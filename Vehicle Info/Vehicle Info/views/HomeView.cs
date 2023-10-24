using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vehicle_Info.views;

namespace Vehicle_Info
{
    public partial class HomeView : Form, IHomeView
    {
        //properties of the home view
        public bool isFormLoaded { get; set; } = false;
        public object vehicleData
        {
            get{
                return vehicleData_dtgrid.DataSource;
            }
            set {
                vehicleData_dtgrid.DataSource = value;
            }
        }

        public string selectedVehicleRow {
            get {
                if(vehicleData_dtgrid.SelectedRows.Count == 1)
                {
                    return vehicleData_dtgrid.SelectedRows[0].Cells[0].Value.ToString();
                }
                return string.Empty;
            } 
        }

        //events of the view
        public event EventHandler newVehicleBtnClicked;
        public event EventHandler formLoad;
        public event EventHandler vehicleInfoBtnClicked;

        public HomeView()
        {
            InitializeComponent();
            setEvents();

            isFormLoaded = true;
        }

        
        //function for attaching the events
        private void setEvents()
        {
            newVehicle_btn.Click += delegate { newVehicleBtnClicked?.Invoke(this, EventArgs.Empty); };
            vehicleInfo_btn.Click += delegate { vehicleInfoBtnClicked?.Invoke(this, EventArgs.Empty); };
            this.Load += delegate { formLoad?.Invoke(this, EventArgs.Empty); };
        }

        //function for show the vehicle data in the view controlled by controller
        public void showVehicleData(DataTable dt)
        {
            //clear the data grid view
            vehicleData_dtgrid.Rows.Clear();
            vehicleData_dtgrid.Refresh();

            //fill the data grid view
            if(dt != null || dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    int n = vehicleData_dtgrid.Rows.Add();
                    vehicleData_dtgrid.Rows[n].Cells[0].Value = dr["reg_no"].ToString();
                    vehicleData_dtgrid.Rows[n].Cells[1].Value = dr["model_name"].ToString();
                    vehicleData_dtgrid.Rows[n].Cells[2].Value = dr["no_of_seat"].ToString();
                    vehicleData_dtgrid.Rows[n].Cells[3].Value = dr["no_of_color"].ToString();
                }
            }

        }
    }
}
