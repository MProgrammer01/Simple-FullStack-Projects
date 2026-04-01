using System.Data;

namespace CarProject_ClientSideForm
{
    public partial class frmManageCars : Form
    {
        DataTable dataCars;
        DataView dataCarsView;

        public frmManageCars()
        {
            InitializeComponent();
        }

        private async Task _LoadData()
        {
            try
            {
                dataCars = await clsCarsAPI.GetAllDataOfCars();
                dataCarsView = dataCars.DefaultView;
                dgv_ListOfCars.DataSource = dataCarsView;

                if (dgv_ListOfCars.Rows.Count > 0)
                {

                    dgv_ListOfCars.Columns[0].HeaderText = "Car ID";
                    dgv_ListOfCars.Columns[0].Width = 194;

                    dgv_ListOfCars.Columns[1].HeaderText = "Car Name";
                    dgv_ListOfCars.Columns[1].Width = 194;


                    dgv_ListOfCars.Columns[2].HeaderText = "Car Model";
                    dgv_ListOfCars.Columns[2].Width = 194;

                    dgv_ListOfCars.Columns[3].HeaderText = "Car Color";
                    dgv_ListOfCars.Columns[3].Width = 194;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error In frmManageCars/_LoadData()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void frmManageCars_Load(object sender, EventArgs e)
        {
            try
            {
                await _LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error In frmManageCars/frmManageCars_Load()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void deleteCarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Are You Sure You Want To Delete This Car Have ID {Convert.ToInt32(dgv_ListOfCars.CurrentRow.Cells["CarID"].Value)}",
                "Conferm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    await clsCarsAPI.DeleteCar(Convert.ToInt32(dgv_ListOfCars.CurrentRow.Cells[0].Value));
                    await _LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error In frmManageCars/deleteCarToolStripMenuItem_Click()", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnAddNewCar_Click(object sender, EventArgs e)
        {
            try
            {
                Form frm = new frmAddOrUpdateCar();
                frm.ShowDialog();

                await _LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error In frmManageCars/btnAddNewCar_Click()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void updateCarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form frm = new frmAddOrUpdateCar(Convert.ToInt32(dgv_ListOfCars.CurrentRow.Cells["CarID"].Value));
                frm.ShowDialog();

                await _LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error In frmManageCars/updateCarToolStripMenuItem_Click()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
