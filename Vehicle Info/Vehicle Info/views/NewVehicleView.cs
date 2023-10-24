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
    public partial class NewVehicleView : Form, INewVehicleView
    {
        //properties
        public string registrationNo { 
            get { 
                return registrationNo_txtbx.Text;
            }
            set { 
                registrationNo_txtbx.Text = value;
            } 
        }
        public string modelName { 
            get {
                return modelName_txtbx.Text;
            } 
            set {
                modelName_txtbx.Text = value;
            } 
        }
        public string noSeatsStr {
            get{
                return noOfSeats_txtbx.Text;
            } set {
                noOfSeats_txtbx.Text = value;
            } 
        }
        public Color selectedColor {
            get {
                return selectedColor_pane.BackColor;
            }
            set { 
                selectedColor_pane.BackColor = value; 
            } 
        }
        public HashSet<string> selectedColorList { 
            get {
                return getColorList();
            } set {
                setColorList(value);    
            } 
        }
        public string selectedColorRow { 
            get {
                if(color_dtgrid.SelectedRows.Count == 1)
                {
                    return color_dtgrid.SelectedRows[0].Cells[0].Value.ToString();
                }
                return string.Empty;
            }
        }

        //events
        public event EventHandler addButtonClicked;
        public event EventHandler clearButtonClicked;
        public event EventHandler colorSelectBtnClicked;
        public event EventHandler addColorBtnClicked;
        public event EventHandler deleteColorBtnClicked;

        //constructor: attach the events
        public NewVehicleView()
        {
            InitializeComponent();
            setEvents();
        }

        //function for attach the events
        private void setEvents()
        {
            add_btn.Click += delegate { addButtonClicked?.Invoke(this, EventArgs.Empty); };
            clear_btn.Click += delegate { clearButtonClicked?.Invoke(this, EventArgs.Empty); };
            colorSelect_btn.Click += delegate { colorSelectBtnClicked?.Invoke(this, EventArgs.Empty); };
            addColor_btn.Click += delegate { addColorBtnClicked?.Invoke(this, EventArgs.Empty); };
            deleteColor_btn.Click += delegate { deleteColorBtnClicked?.Invoke(this, EventArgs.Empty); };

            //numeric only
            noOfSeats_txtbx.KeyPress += (s, e) =>{
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }};
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

        //set the color list to the data grid view
        private void setColorList(HashSet<String> colorList)
        {
            color_dtgrid.Rows.Clear();
            color_dtgrid.Refresh();

            foreach(string value in colorList)
            {
                int n = color_dtgrid.Rows.Add();
                color_dtgrid.Rows[n].Cells[0].Value = value;
                color_dtgrid.Rows[n].Cells[1].Style.BackColor = ColorTranslator.FromHtml("#" + value.ToString());
            }
        }
    }
}
