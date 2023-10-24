
namespace Vehicle_Info
{
    partial class HomeView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.vehicleData_dtgrid = new System.Windows.Forms.DataGridView();
            this.newVehicle_btn = new System.Windows.Forms.Button();
            this.reg_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.model_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.no_of_seat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.no_of_colors = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vehicleInfo_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.vehicleData_dtgrid)).BeginInit();
            this.SuspendLayout();
            // 
            // vehicleData_dtgrid
            // 
            this.vehicleData_dtgrid.AllowUserToAddRows = false;
            this.vehicleData_dtgrid.AllowUserToDeleteRows = false;
            this.vehicleData_dtgrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.vehicleData_dtgrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vehicleData_dtgrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.reg_no,
            this.model_name,
            this.no_of_seat,
            this.no_of_colors});
            this.vehicleData_dtgrid.Location = new System.Drawing.Point(12, 12);
            this.vehicleData_dtgrid.MultiSelect = false;
            this.vehicleData_dtgrid.Name = "vehicleData_dtgrid";
            this.vehicleData_dtgrid.ReadOnly = true;
            this.vehicleData_dtgrid.RowHeadersVisible = false;
            this.vehicleData_dtgrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.vehicleData_dtgrid.Size = new System.Drawing.Size(477, 307);
            this.vehicleData_dtgrid.TabIndex = 0;
            // 
            // newVehicle_btn
            // 
            this.newVehicle_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newVehicle_btn.Location = new System.Drawing.Point(495, 12);
            this.newVehicle_btn.Name = "newVehicle_btn";
            this.newVehicle_btn.Size = new System.Drawing.Size(149, 46);
            this.newVehicle_btn.TabIndex = 1;
            this.newVehicle_btn.Text = "New Vehicle";
            this.newVehicle_btn.UseVisualStyleBackColor = true;
            // 
            // reg_no
            // 
            this.reg_no.HeaderText = "Reg No";
            this.reg_no.Name = "reg_no";
            this.reg_no.ReadOnly = true;
            // 
            // model_name
            // 
            this.model_name.HeaderText = "Model Name";
            this.model_name.Name = "model_name";
            this.model_name.ReadOnly = true;
            // 
            // no_of_seat
            // 
            this.no_of_seat.HeaderText = "No. Seats";
            this.no_of_seat.Name = "no_of_seat";
            this.no_of_seat.ReadOnly = true;
            // 
            // no_of_colors
            // 
            this.no_of_colors.HeaderText = "No. Color";
            this.no_of_colors.Name = "no_of_colors";
            this.no_of_colors.ReadOnly = true;
            // 
            // vehicleInfo_btn
            // 
            this.vehicleInfo_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vehicleInfo_btn.Location = new System.Drawing.Point(495, 64);
            this.vehicleInfo_btn.Name = "vehicleInfo_btn";
            this.vehicleInfo_btn.Size = new System.Drawing.Size(149, 46);
            this.vehicleInfo_btn.TabIndex = 2;
            this.vehicleInfo_btn.Text = "Vehicle Info";
            this.vehicleInfo_btn.UseVisualStyleBackColor = true;
            // 
            // HomeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 331);
            this.Controls.Add(this.vehicleInfo_btn);
            this.Controls.Add(this.newVehicle_btn);
            this.Controls.Add(this.vehicleData_dtgrid);
            this.Name = "HomeView";
            this.Text = "Vehicle Info";
            ((System.ComponentModel.ISupportInitialize)(this.vehicleData_dtgrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView vehicleData_dtgrid;
        private System.Windows.Forms.Button newVehicle_btn;
        private System.Windows.Forms.DataGridViewTextBoxColumn reg_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn model_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn no_of_seat;
        private System.Windows.Forms.DataGridViewTextBoxColumn no_of_colors;
        private System.Windows.Forms.Button vehicleInfo_btn;
    }
}

