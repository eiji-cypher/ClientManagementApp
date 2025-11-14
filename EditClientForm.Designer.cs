namespace ClientManagementApp
{
    partial class EditClientForm
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
            btnCancel = new Button();
            btnSave = new Button();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtLastName = new TextBox();
            txtContactNumber = new TextBox();
            txtAddress = new TextBox();
            txtFirstName = new TextBox();
            SuspendLayout();
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(323, 298);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 19;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(242, 298);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 18;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(141, 254);
            label4.Name = "label4";
            label4.Size = new Size(49, 15);
            label4.TabIndex = 17;
            label4.Text = "Address";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(141, 214);
            label3.Name = "label3";
            label3.Size = new Size(71, 15);
            label3.TabIndex = 16;
            label3.Text = "Contact No.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(141, 172);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 15;
            label2.Text = "Last Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(141, 132);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 14;
            label1.Text = "First Name";
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(236, 169);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(424, 23);
            txtLastName.TabIndex = 13;
            // 
            // txtContactNumber
            // 
            txtContactNumber.Location = new Point(236, 211);
            txtContactNumber.Name = "txtContactNumber";
            txtContactNumber.Size = new Size(424, 23);
            txtContactNumber.TabIndex = 12;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(236, 251);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(424, 23);
            txtAddress.TabIndex = 11;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(236, 129);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(424, 23);
            txtFirstName.TabIndex = 10;
            // 
            // EditClientForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtLastName);
            Controls.Add(txtContactNumber);
            Controls.Add(txtAddress);
            Controls.Add(txtFirstName);
            Name = "EditClientForm";
            Text = " ";
            Load += EditClientForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        // DELETED: EditClientForm_Load method with throw new NotImplementedException()

        #endregion

        private Button btnCancel;
        private Button btnSave;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtLastName;
        private TextBox txtContactNumber;
        private TextBox txtAddress;
        private TextBox txtFirstName;
    }
}