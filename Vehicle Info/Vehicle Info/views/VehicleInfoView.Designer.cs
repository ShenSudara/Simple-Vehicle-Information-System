
namespace Vehicle_Info.views
{
    partial class VehicleInfoView
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
            this.color_dtgrid = new System.Windows.Forms.DataGridView();
            this.color_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.noOfSeats_txtbx = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.modelName_txtbx = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.registrationNo_txtbx = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.color_dtgrid)).BeginInit();
            this.SuspendLayout();
            // 
            // color_dtgrid
            // 
            this.color_dtgrid.AllowUserToAddRows = false;
            this.color_dtgrid.AllowUserToDeleteRows = false;
            this.color_dtgrid.BackgroundColor = System.Drawing.Color.White;
            this.color_dtgrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.color_dtgrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.color_code,
            this.color});
            this.color_dtgrid.Location = new System.Drawing.Point(119, 107);
            this.color_dtgrid.MultiSelect = false;
            this.color_dtgrid.Name = "color_dtgrid";
            this.color_dtgrid.ReadOnly = true;
            this.color_dtgrid.RowHeadersVisible = false;
            this.color_dtgrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.color_dtgrid.Size = new System.Drawing.Size(220, 136);
            this.color_dtgrid.TabIndex = 27;
            // 
            // color_code
            // 
            this.color_code.HeaderText = "Color Code";
            this.color_code.Name = "color_code";
            this.color_code.ReadOnly = true;
            // 
            // color
            // 
            this.color.HeaderText = "Color";
            this.color.Name = "color";
            this.color.ReadOnly = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 16);
            this.label4.TabIndex = 20;
            this.label4.Text = "Vehicle Color:";
            // 
            // noOfSeats_txtbx
            // 
            this.noOfSeats_txtbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noOfSeats_txtbx.Location = new System.Drawing.Point(119, 74);
            this.noOfSeats_txtbx.Name = "noOfSeats_txtbx";
            this.noOfSeats_txtbx.ReadOnly = true;
            this.noOfSeats_txtbx.Size = new System.Drawing.Size(220, 22);
            this.noOfSeats_txtbx.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 16);
            this.label3.TabIndex = 18;
            this.label3.Text = "No of Seats:";
            // 
            // modelName_txtbx
            // 
            this.modelName_txtbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modelName_txtbx.Location = new System.Drawing.Point(119, 46);
            this.modelName_txtbx.Name = "modelName_txtbx";
            this.modelName_txtbx.ReadOnly = true;
            this.modelName_txtbx.Size = new System.Drawing.Size(220, 22);
            this.modelName_txtbx.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "Model Name:";
            // 
            // registrationNo_txtbx
            // 
            this.registrationNo_txtbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registrationNo_txtbx.Location = new System.Drawing.Point(119, 18);
            this.registrationNo_txtbx.Name = "registrationNo_txtbx";
            this.registrationNo_txtbx.ReadOnly = true;
            this.registrationNo_txtbx.Size = new System.Drawing.Size(220, 22);
            this.registrationNo_txtbx.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Registration No:";
            // 
            // VehicleInfoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 258);
            this.Controls.Add(this.color_dtgrid);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.noOfSeats_txtbx);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.modelName_txtbx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.registrationNo_txtbx);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "VehicleInfoView";
            this.Text = "Vehicle Info";
            ((System.ComponentModel.ISupportInitialize)(this.color_dtgrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView color_dtgrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn color_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn color;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox noOfSeats_txtbx;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox modelName_txtbx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox registrationNo_txtbx;
        private System.Windows.Forms.Label label1;
    }
}