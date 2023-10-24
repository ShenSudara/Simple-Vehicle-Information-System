using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vehicle_Info.config;
using Vehicle_Info.models;
using Vehicle_Info.views;

namespace Vehicle_Info.controllers
{
    class NewVehicleController
    {
        //attributes
        private NewVehicleModel newVehicleModel;
        private INewVehicleView newVehicleView;

        //constructor: get the model/view from homeview and trigger events
        public NewVehicleController(NewVehicleModel newVehicleModel, NewVehicleView newVehicleView)
        {
            this.newVehicleModel = newVehicleModel;
            this.newVehicleView = newVehicleView;

            //setup events
            newVehicleView.colorSelectBtnClicked += NewVehicleView_colorSelectBtnClicked;
            newVehicleView.clearButtonClicked += NewVehicleView_clearButtonClicked;
            newVehicleView.addButtonClicked += NewVehicleView_addButtonClicked;
            newVehicleView.addColorBtnClicked += NewVehicleView_addColorBtnClicked;
            newVehicleView.deleteColorBtnClicked += NewVehicleView_deleteColorBtnClicked;

            newVehicleView.ShowDialog();
        }

        //when the delete color btn click in the view this will trigger
        private void NewVehicleView_deleteColorBtnClicked(object sender, EventArgs e)
        {
            try
            {
                if (newVehicleView.selectedColorRow != string.Empty)
                {
                    HashSet<string> colorList = newVehicleView.selectedColorList;
                    colorList.Remove(newVehicleView.selectedColorRow);
                    newVehicleView.selectedColorList = colorList;
                    MessageBox.Show(null, "color removed successfuly", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(null, "please select a color to remove", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(null, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //when the add color btn click in the view this will trigger
        private void NewVehicleView_addColorBtnClicked(object sender, EventArgs e)
        {
            try
            {
                if (newVehicleView.selectedColor != Color.Transparent)
                {
                    HashSet<string> colorList = newVehicleView.selectedColorList;
                    colorList.Add(newVehicleView.selectedColor.R.ToString("X2") + newVehicleView.selectedColor.G.ToString("X2") + newVehicleView.selectedColor.B.ToString("X2"));
                    newVehicleView.selectedColorList = colorList;
                }
                else
                {
                    MessageBox.Show(null, "please select a color to add", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(null, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        
        //when the new vehicle add btn click in the view this will trigger
        private void NewVehicleView_addButtonClicked(object sender, EventArgs e)
        {
            try
            {
                if (newVehicleView.noSeatsStr == string.Empty)
                    MessageBox.Show(null, "no of seats must included", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    NewVehicleModel vehicleModel = new NewVehicleModel(newVehicleView.registrationNo, newVehicleView.modelName, int.Parse(newVehicleView.noSeatsStr), newVehicleView.selectedColorList);
                    string message = vehicleModel.validateObject(vehicleModel);
                    if (message != String.Empty)
                        MessageBox.Show(null, message, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else if (findSimilar(vehicleModel))
                    {
                        MessageBox.Show(null, "similar registration no was found", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        int flag = 0;

                        DatabaseConnection con = null;
                        SqlTransaction transaction = null;

                        try
                        {
                            //save to the database
                            con = new DatabaseConnection();
                            con.openConnection();

                            transaction = con.startTransaction();
                            SqlCommand cmd = new SqlCommand(@"INSERT INTO vehicle_tbl(reg_no, model_name, no_of_seat) VALUES (@reg_no, @model_name, @no_of_seat)");
                            cmd.Parameters.AddWithValue("@reg_no", vehicleModel.registrationNo);
                            cmd.Parameters.AddWithValue("@model_name", vehicleModel.modelName);
                            cmd.Parameters.AddWithValue("@no_of_seat", vehicleModel.noOfSeats);

                            flag += con.executeQuery(cmd, transaction);

                            foreach(string color in vehicleModel.vehicleColorList)
                            {
                                cmd = new SqlCommand(@"INSERT INTO vehicle_color_tbl(reg_no, color_code) VALUES (@reg_no, @color_code)");
                                cmd.Parameters.AddWithValue("@reg_no", vehicleModel.registrationNo);
                                cmd.Parameters.AddWithValue("@color_code", color);
                                flag += con.executeQuery(cmd, transaction);
                            }

                            if (flag > 1)
                            {
                                transaction.Commit();
                                MessageBox.Show(null, "new vehicle inserted successfuly", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                transaction.Rollback();
                                MessageBox.Show(null, "vehicle did not inserted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            con.closeConnection();
                        }
                        catch (Exception ex)
                        {
                            if (transaction == null || transaction.Connection.State == System.Data.ConnectionState.Open)
                            {
                                transaction.Rollback();
                                MessageBox.Show(null, "vehicle did not inserted. \n " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        clearForm();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(null, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        
        //when the clear btn click in the view this will trigger
        private void NewVehicleView_clearButtonClicked(object sender, EventArgs e)
        {
            try
            {
                clearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(null, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //clear form in the view
        private void clearForm()
        {
            newVehicleView.registrationNo = String.Empty;
            newVehicleView.modelName = String.Empty;
            newVehicleView.noSeatsStr = String.Empty;
            newVehicleView.selectedColor = Color.Transparent;
            newVehicleView.selectedColorList = new HashSet<string>();
        }

        //when the color select btn click in the view this will trigger
        private void NewVehicleView_colorSelectBtnClicked(object sender, EventArgs e)
        {
            try
            {
                ColorDialog colorDialog = new ColorDialog();
                colorDialog.AllowFullOpen = false;
                colorDialog.ShowHelp = true;
                if (colorDialog.ShowDialog() == DialogResult.OK)
                    newVehicleView.selectedColor = colorDialog.Color;
            }
            catch (Exception ex)
            {
                MessageBox.Show(null, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //find similar registration no through the data base
        private bool findSimilar(NewVehicleModel newVehicleModel)
        {
            DatabaseConnection con = new DatabaseConnection();
            con.openConnection();

            SqlCommand cmd = new SqlCommand(@"SELECT reg_no FROM vehicle_tbl WHERE reg_no= @reg_no");
            cmd.Parameters.AddWithValue("@reg_no", newVehicleModel.registrationNo);
            if (con.getSingleValue(cmd) != null) {
                con.closeConnection();
                return true;
            }
            con.closeConnection();
            return false;
        }
    }
}
