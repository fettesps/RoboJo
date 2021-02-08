namespace RoboJo
{
    partial class frmSplitEntry
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
            this.txtDuration_First = new System.Windows.Forms.TextBox();
            this.lblDuration = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpEndTime_First = new System.Windows.Forms.DateTimePicker();
            this.dtpStartTime_First = new System.Windows.Forms.DateTimePicker();
            this.chkBillable_First = new System.Windows.Forms.CheckBox();
            this.txtUserInput_First = new System.Windows.Forms.TextBox();
            this.lblUserInput = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtDuration_Second = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpEndTime_Second = new System.Windows.Forms.DateTimePicker();
            this.dtpStartTime_Second = new System.Windows.Forms.DateTimePicker();
            this.chkBillable_Second = new System.Windows.Forms.CheckBox();
            this.txtUserInput_Second = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtDuration_First);
            this.panel1.Controls.Add(this.lblDuration);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtpEndTime_First);
            this.panel1.Controls.Add(this.dtpStartTime_First);
            this.panel1.Controls.Add(this.chkBillable_First);
            this.panel1.Controls.Add(this.txtUserInput_First);
            this.panel1.Controls.Add(this.lblUserInput);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(495, 146);
            this.panel1.TabIndex = 0;
            // 
            // txtDuration_First
            // 
            this.txtDuration_First.Location = new System.Drawing.Point(161, 91);
            this.txtDuration_First.Name = "txtDuration_First";
            this.txtDuration_First.Size = new System.Drawing.Size(60, 20);
            this.txtDuration_First.TabIndex = 10;
            this.txtDuration_First.Text = "00:00:00";
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(104, 94);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(50, 13);
            this.lblDuration.TabIndex = 9;
            this.lblDuration.Text = "Duration:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(99, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "End Time:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Start Time:";
            // 
            // dtpEndTime_First
            // 
            this.dtpEndTime_First.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpEndTime_First.Location = new System.Drawing.Point(161, 66);
            this.dtpEndTime_First.Name = "dtpEndTime_First";
            this.dtpEndTime_First.Size = new System.Drawing.Size(102, 20);
            this.dtpEndTime_First.TabIndex = 4;
            this.dtpEndTime_First.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dtpEndTime_First_KeyUp);
            // 
            // dtpStartTime_First
            // 
            this.dtpStartTime_First.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpStartTime_First.Location = new System.Drawing.Point(161, 40);
            this.dtpStartTime_First.Name = "dtpStartTime_First";
            this.dtpStartTime_First.Size = new System.Drawing.Size(102, 20);
            this.dtpStartTime_First.TabIndex = 3;
            this.dtpStartTime_First.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dtpStartTime_First_KeyUp);
            // 
            // chkBillable_First
            // 
            this.chkBillable_First.AutoSize = true;
            this.chkBillable_First.Checked = true;
            this.chkBillable_First.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBillable_First.Location = new System.Drawing.Point(116, 118);
            this.chkBillable_First.Name = "chkBillable_First";
            this.chkBillable_First.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkBillable_First.Size = new System.Drawing.Size(59, 17);
            this.chkBillable_First.TabIndex = 2;
            this.chkBillable_First.Text = "Billable";
            this.chkBillable_First.UseVisualStyleBackColor = true;
            // 
            // txtUserInput_First
            // 
            this.txtUserInput_First.Location = new System.Drawing.Point(161, 13);
            this.txtUserInput_First.Name = "txtUserInput_First";
            this.txtUserInput_First.Size = new System.Drawing.Size(306, 20);
            this.txtUserInput_First.TabIndex = 1;
            this.txtUserInput_First.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserInput_KeyDown);
            // 
            // lblUserInput
            // 
            this.lblUserInput.AutoSize = true;
            this.lblUserInput.Location = new System.Drawing.Point(16, 17);
            this.lblUserInput.Name = "lblUserInput";
            this.lblUserInput.Size = new System.Drawing.Size(140, 13);
            this.lblUserInput.TabIndex = 0;
            this.lblUserInput.Text = "What were you working on?";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(392, 114);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtDuration_Second);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.btnOk);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.dtpEndTime_Second);
            this.panel2.Controls.Add(this.dtpStartTime_Second);
            this.panel2.Controls.Add(this.chkBillable_Second);
            this.panel2.Controls.Add(this.txtUserInput_Second);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(12, 166);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(495, 146);
            this.panel2.TabIndex = 1;
            // 
            // txtDuration_Second
            // 
            this.txtDuration_Second.Location = new System.Drawing.Point(161, 91);
            this.txtDuration_Second.Name = "txtDuration_Second";
            this.txtDuration_Second.Size = new System.Drawing.Size(60, 20);
            this.txtDuration_Second.TabIndex = 10;
            this.txtDuration_Second.Text = "00:00:00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(104, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Duration:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(309, 114);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(99, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "End Time:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(98, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Start Time:";
            // 
            // dtpEndTime_Second
            // 
            this.dtpEndTime_Second.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpEndTime_Second.Location = new System.Drawing.Point(161, 66);
            this.dtpEndTime_Second.Name = "dtpEndTime_Second";
            this.dtpEndTime_Second.Size = new System.Drawing.Size(102, 20);
            this.dtpEndTime_Second.TabIndex = 4;
            this.dtpEndTime_Second.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dtpEndTime_Second_KeyUp);
            // 
            // dtpStartTime_Second
            // 
            this.dtpStartTime_Second.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpStartTime_Second.Location = new System.Drawing.Point(161, 40);
            this.dtpStartTime_Second.Name = "dtpStartTime_Second";
            this.dtpStartTime_Second.Size = new System.Drawing.Size(102, 20);
            this.dtpStartTime_Second.TabIndex = 3;
            this.dtpStartTime_Second.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dtpStartTime_Second_KeyUp);
            // 
            // chkBillable_Second
            // 
            this.chkBillable_Second.AutoSize = true;
            this.chkBillable_Second.Checked = true;
            this.chkBillable_Second.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBillable_Second.Location = new System.Drawing.Point(116, 118);
            this.chkBillable_Second.Name = "chkBillable_Second";
            this.chkBillable_Second.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkBillable_Second.Size = new System.Drawing.Size(59, 17);
            this.chkBillable_Second.TabIndex = 2;
            this.chkBillable_Second.Text = "Billable";
            this.chkBillable_Second.UseVisualStyleBackColor = true;
            // 
            // txtUserInput_Second
            // 
            this.txtUserInput_Second.Location = new System.Drawing.Point(161, 13);
            this.txtUserInput_Second.Name = "txtUserInput_Second";
            this.txtUserInput_Second.Size = new System.Drawing.Size(306, 20);
            this.txtUserInput_Second.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "What were you working on?";
            // 
            // frmSplitEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 322);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmSplitEntry";
            this.Text = "Split Entry";
            this.Shown += new System.EventHandler(this.frmSplitEntry_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpEndTime_First;
        private System.Windows.Forms.DateTimePicker dtpStartTime_First;
        private System.Windows.Forms.CheckBox chkBillable_First;
        private System.Windows.Forms.TextBox txtUserInput_First;
        private System.Windows.Forms.Label lblUserInput;
        private System.Windows.Forms.TextBox txtDuration_First;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtDuration_Second;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpEndTime_Second;
        private System.Windows.Forms.DateTimePicker dtpStartTime_Second;
        private System.Windows.Forms.CheckBox chkBillable_Second;
        private System.Windows.Forms.TextBox txtUserInput_Second;
        private System.Windows.Forms.Label label6;
    }
}