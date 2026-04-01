namespace CarProject_ClientSideForm
{
    partial class frmManageCars
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            dgv_ListOfCars = new DataGridView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            updateCarToolStripMenuItem = new ToolStripMenuItem();
            deleteCarToolStripMenuItem = new ToolStripMenuItem();
            btnAddNewCar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgv_ListOfCars).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(776, 96);
            label1.TabIndex = 0;
            label1.Text = "List Of Cars";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgv_ListOfCars
            // 
            dgv_ListOfCars.AllowUserToAddRows = false;
            dgv_ListOfCars.AllowUserToDeleteRows = false;
            dgv_ListOfCars.BackgroundColor = Color.White;
            dgv_ListOfCars.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_ListOfCars.ContextMenuStrip = contextMenuStrip1;
            dgv_ListOfCars.Location = new Point(12, 147);
            dgv_ListOfCars.Name = "dgv_ListOfCars";
            dgv_ListOfCars.ReadOnly = true;
            dgv_ListOfCars.Size = new Size(776, 291);
            dgv_ListOfCars.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { updateCarToolStripMenuItem, deleteCarToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(185, 86);
            // 
            // updateCarToolStripMenuItem
            // 
            updateCarToolStripMenuItem.Name = "updateCarToolStripMenuItem";
            updateCarToolStripMenuItem.Size = new Size(184, 30);
            updateCarToolStripMenuItem.Text = "Update Car";
            updateCarToolStripMenuItem.Click += updateCarToolStripMenuItem_Click;
            // 
            // deleteCarToolStripMenuItem
            // 
            deleteCarToolStripMenuItem.Name = "deleteCarToolStripMenuItem";
            deleteCarToolStripMenuItem.Size = new Size(184, 30);
            deleteCarToolStripMenuItem.Text = "Delete Car";
            deleteCarToolStripMenuItem.Click += deleteCarToolStripMenuItem_Click;
            // 
            // btnAddNewCar
            // 
            btnAddNewCar.Location = new Point(697, 108);
            btnAddNewCar.Name = "btnAddNewCar";
            btnAddNewCar.Size = new Size(91, 33);
            btnAddNewCar.TabIndex = 2;
            btnAddNewCar.Text = "Add New Car";
            btnAddNewCar.UseVisualStyleBackColor = true;
            btnAddNewCar.Click += btnAddNewCar_Click;
            // 
            // frmManageCars
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 450);
            Controls.Add(btnAddNewCar);
            Controls.Add(dgv_ListOfCars);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmManageCars";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cars";
            Load += frmManageCars_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_ListOfCars).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private DataGridView dgv_ListOfCars;
        private Button btnAddNewCar;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem updateCarToolStripMenuItem;
        private ToolStripMenuItem deleteCarToolStripMenuItem;
    }
}
