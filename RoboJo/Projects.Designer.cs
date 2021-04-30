namespace RoboJo
{
    partial class frmProjects
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.lblProjectName = new System.Windows.Forms.Label();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.lblWeight = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpEndTime_First = new System.Windows.Forms.DateTimePicker();
            this.dtpStartTime_First = new System.Windows.Forms.DateTimePicker();
            this.txtProjectID = new System.Windows.Forms.TextBox();
            this.lblProjectID = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.txtProjectName);
            this.panel1.Controls.Add(this.lblProjectName);
            this.panel1.Controls.Add(this.txtWeight);
            this.panel1.Controls.Add(this.lblWeight);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtpEndTime_First);
            this.panel1.Controls.Add(this.dtpStartTime_First);
            this.panel1.Controls.Add(this.txtProjectID);
            this.panel1.Controls.Add(this.lblProjectID);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(495, 278);
            this.panel1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(324, 239);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(407, 239);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 13;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtProjectName
            // 
            this.txtProjectName.Location = new System.Drawing.Point(161, 39);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(102, 20);
            this.txtProjectName.TabIndex = 12;
            // 
            // lblProjectName
            // 
            this.lblProjectName.AutoSize = true;
            this.lblProjectName.Location = new System.Drawing.Point(116, 42);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(38, 13);
            this.lblProjectName.TabIndex = 11;
            this.lblProjectName.Text = "Name:";
            // 
            // txtWeight
            // 
            this.txtWeight.Location = new System.Drawing.Point(161, 125);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(60, 20);
            this.txtWeight.TabIndex = 10;
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.Location = new System.Drawing.Point(104, 128);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(50, 13);
            this.lblWeight.TabIndex = 9;
            this.lblWeight.Text = "Duration:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(99, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "End Time:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Start Time:";
            // 
            // dtpEndTime_First
            // 
            this.dtpEndTime_First.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpEndTime_First.Location = new System.Drawing.Point(161, 100);
            this.dtpEndTime_First.Name = "dtpEndTime_First";
            this.dtpEndTime_First.Size = new System.Drawing.Size(102, 20);
            this.dtpEndTime_First.TabIndex = 4;
            this.dtpEndTime_First.ValueChanged += new System.EventHandler(this.dtpEndTime_First_ValueChanged);
            // 
            // dtpStartTime_First
            // 
            this.dtpStartTime_First.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpStartTime_First.Location = new System.Drawing.Point(161, 74);
            this.dtpStartTime_First.Name = "dtpStartTime_First";
            this.dtpStartTime_First.Size = new System.Drawing.Size(102, 20);
            this.dtpStartTime_First.TabIndex = 3;
            this.dtpStartTime_First.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dtpStartTime_First_KeyUp);
            // 
            // txtProjectID
            // 
            this.txtProjectID.Location = new System.Drawing.Point(161, 13);
            this.txtProjectID.Name = "txtProjectID";
            this.txtProjectID.Size = new System.Drawing.Size(102, 20);
            this.txtProjectID.TabIndex = 1;
            this.txtProjectID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserInput_KeyDown);
            // 
            // lblProjectID
            // 
            this.lblProjectID.AutoSize = true;
            this.lblProjectID.Location = new System.Drawing.Point(99, 20);
            this.lblProjectID.Name = "lblProjectID";
            this.lblProjectID.Size = new System.Drawing.Size(57, 13);
            this.lblProjectID.TabIndex = 0;
            this.lblProjectID.Text = "Project ID:";
            // 
            // frmProjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 322);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmProjects";
            this.Text = "Projects";
            this.Shown += new System.EventHandler(this.frmProjects_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpEndTime_First;
        private System.Windows.Forms.DateTimePicker dtpStartTime_First;
        private System.Windows.Forms.TextBox txtProjectID;
        private System.Windows.Forms.Label lblProjectID;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.TextBox txtProjectName;
        private System.Windows.Forms.Label lblProjectName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
    }
}