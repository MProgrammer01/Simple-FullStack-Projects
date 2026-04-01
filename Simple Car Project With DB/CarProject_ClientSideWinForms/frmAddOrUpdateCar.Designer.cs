namespace CarProject_ClientSideForm
{
    partial class frmAddOrUpdateCar
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
            lblAddOrEditCar = new Label();
            label1 = new Label();
            txtCarName = new TextBox();
            label3 = new Label();
            txtCarModel = new TextBox();
            label4 = new Label();
            txtCarColor = new TextBox();
            label5 = new Label();
            btnSave = new Button();
            btnClose = new Button();
            lblID = new Label();
            SuspendLayout();
            // 
            // lblAddOrEditCar
            // 
            lblAddOrEditCar.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAddOrEditCar.Location = new Point(12, 9);
            lblAddOrEditCar.Name = "lblAddOrEditCar";
            lblAddOrEditCar.Size = new Size(294, 82);
            lblAddOrEditCar.TabIndex = 1;
            lblAddOrEditCar.Text = "Add New Car";
            lblAddOrEditCar.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 114);
            label1.Name = "label1";
            label1.Size = new Size(64, 21);
            label1.TabIndex = 2;
            label1.Text = "Car ID :";
            // 
            // txtCarName
            // 
            txtCarName.Location = new Point(111, 162);
            txtCarName.Name = "txtCarName";
            txtCarName.Size = new Size(195, 23);
            txtCarName.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 163);
            label3.Name = "label3";
            label3.Size = new Size(93, 21);
            label3.TabIndex = 4;
            label3.Text = "Car Name :";
            // 
            // txtCarModel
            // 
            txtCarModel.Location = new Point(114, 217);
            txtCarModel.Name = "txtCarModel";
            txtCarModel.Size = new Size(192, 23);
            txtCarModel.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(12, 218);
            label4.Name = "label4";
            label4.Size = new Size(96, 21);
            label4.TabIndex = 6;
            label4.Text = "Car Model :";
            // 
            // txtCarColor
            // 
            txtCarColor.Location = new Point(106, 272);
            txtCarColor.Name = "txtCarColor";
            txtCarColor.Size = new Size(200, 23);
            txtCarColor.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(12, 273);
            label5.Name = "label5";
            label5.Size = new Size(88, 21);
            label5.TabIndex = 8;
            label5.Text = "Car Color :";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(215, 330);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(91, 33);
            btnSave.TabIndex = 10;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(111, 330);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(91, 33);
            btnClose.TabIndex = 11;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblID.Location = new Point(82, 114);
            lblID.Name = "lblID";
            lblID.Size = new Size(45, 21);
            lblID.TabIndex = 12;
            lblID.Text = "*****";
            // 
            // frmAppOrUpdateCar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(318, 376);
            Controls.Add(lblID);
            Controls.Add(btnClose);
            Controls.Add(btnSave);
            Controls.Add(txtCarColor);
            Controls.Add(label5);
            Controls.Add(txtCarModel);
            Controls.Add(label4);
            Controls.Add(txtCarName);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(lblAddOrEditCar);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmAppOrUpdateCar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmAppOrUpdateCar";
            Load += frmAppOrUpdateCar_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblAddOrEditCar;
        private Label label1;
        private TextBox txtCarName;
        private Label label3;
        private TextBox txtCarModel;
        private Label label4;
        private TextBox txtCarColor;
        private Label label5;
        private Button btnSave;
        private Button btnClose;
        private Label lblID;
    }
}