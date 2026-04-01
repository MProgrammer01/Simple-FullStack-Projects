using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarProject_ClientSideForm
{
    public partial class frmAddOrUpdateCar : Form
    {
        static int Car_ID = 0;


        public frmAddOrUpdateCar(int car_id = 0)
        {
            InitializeComponent();

            if (car_id != 0)
            {
                Car_ID = car_id;
            }
        }

        private async Task _LoadData()
        {
            try
            {
                if (Car_ID == 0)
                {
                    lblAddOrEditCar.Text = "Add New Car";
                }
                else
                {
                    lblAddOrEditCar.Text = "Update Car";

                    clsCar car = await clsCarsAPI.GetCarById(Car_ID);

                    lblID.Text = car.CarID.ToString();
                    txtCarName.Text = car.CarName;
                    txtCarModel.Text = car.CarModel;
                    txtCarColor.Text = car.CarColor;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error In frmAddOrUpdateCar/_LoadData()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string CarName = txtCarName.Text.ToString();
                string CarModel = txtCarModel.Text.ToString();
                string CarColor = txtCarColor.Text.ToString();
                clsCar Car = new clsCar
                {
                    //CarID = 0,
                    CarName = CarName,
                    CarModel = CarModel,
                    CarColor = CarColor
                };

                if (Car_ID == 0)
                {
                    int carID = await clsCarsAPI.AddCar(Car);
                    if (carID != 0)
                    {
                        lblID.Text = carID.ToString();
                        Car_ID = carID;
                    }

                }
                else
                {
                    await clsCarsAPI.UpdateCar(Car_ID, Car);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error In frmAddOrUpdateCar/btnSave_Click()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async void frmAppOrUpdateCar_Load(object sender, EventArgs e)
        {
            try
            {
                await _LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error In frmAddOrUpdateCar/frmAppOrUpdateCar_Load()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
