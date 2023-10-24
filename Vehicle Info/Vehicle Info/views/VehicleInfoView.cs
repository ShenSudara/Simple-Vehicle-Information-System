using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vehicle_Info.views
{
    public partial class VehicleInfoView : Form, IVehicleInfoView
    {

        
        //constructor: attach the event to the view
        public VehicleInfoView()
        {
            InitializeComponent();
            setEvents();
            isFormLoaded = true;
        }



        //properties
        public bool isFormLoaded { get; set; } = false;
        public string registrationNo
        {
            get
            {
                return registrationNo_txtbx.Text;
            }
            set
            {
                registrationNo_txtbx.Text = value;
            }
        }
        public string modelName
        {
            get
            {
                return modelName_txtbx.Text;
            }
            set
            {
                modelName_txtbx.Text = value;
            }
        }
        public string noSeatsStr
        {
            get
            {
                return noOfSeats_txtbx.Text;
            }
            set
            {
                noOfSeats_txtbx.Text = value;
            }
        }

        //events
        public HashSet<string> selectedColorList
        {
            get
            {
                return getColorList();
            }
            set
            {
                setColorList(value);
            }
        }

        public event EventHandler formLoaded;

        //attach the events
        private void setEvents()
        {
            this.Load += delegate { formLoaded?.Invoke(this, EventArgs.Empty); };
        }

        //get the color list from the data grid view
        private HashSet<String> getColorList()
        {
            HashSet<String> colorDic = new HashSet<string>();
            if (color_dtgrid.Rows.Count > 0)
            {
                foreach (DataGridViewRow dgr in color_dtgrid.Rows)
                {
                    colorDic.Add(dgr.Cells[0].Value.ToString());
                }
            }
            return colorDic;
        }

        //set the color list
        private void setColorList(HashSet<String> colorList)
        {
            color_dtgrid.Rows.Clear();
            color_dtgrid.Refresh();

            foreach (string value in colorList)
            {
                int n = color_dtgrid.Rows.Add();
                color_dtgrid.Rows[n].Cells[0].Value = value;
                color_dtgrid.Rows[n].Cells[1].Style.BackColor = ColorTranslator.FromHtml("#" + value.ToString());
            }
        }
    }
}
