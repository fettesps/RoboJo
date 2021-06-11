namespace RoboJo
{
    partial class frmPrompt
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSkip = new System.Windows.Forms.Button();
            this.chkRunEndTimer = new System.Windows.Forms.CheckBox();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.lblDuration = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.chkBillable = new System.Windows.Forms.CheckBox();
            this.txtUserInput = new System.Windows.Forms.TextBox();
            this.lblUserInput = new System.Windows.Forms.Label();
            this.tmrPromptTicker = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSkip);
            this.panel1.Controls.Add(this.chkRunEndTimer);
            this.panel1.Controls.Add(this.txtDuration);
            this.panel1.Controls.Add(this.lblDuration);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtpEndTime);
            this.panel1.Controls.Add(this.dtpStartTime);
            this.panel1.Controls.Add(this.chkBillable);
            this.panel1.Controls.Add(this.txtUserInput);
            this.panel1.Controls.Add(this.lblUserInput);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(495, 146);
            this.panel1.TabIndex = 0;
            // 
            // btnSkip
            // 
            this.btnSkip.Location = new System.Drawing.Point(311, 116);
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Size = new System.Drawing.Size(75, 23);
            this.btnSkip.TabIndex = 12;
            this.btnSkip.Text = "Skip";
            this.btnSkip.UseVisualStyleBackColor = true;
            this.btnSkip.Click += new System.EventHandler(this.btnSkip_Click);
            // 
            // chkRunEndTimer
            // 
            this.chkRunEndTimer.AutoSize = true;
            this.chkRunEndTimer.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkRunEndTimer.Checked = true;
            this.chkRunEndTimer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRunEndTimer.Location = new System.Drawing.Point(269, 68);
            this.chkRunEndTimer.Name = "chkRunEndTimer";
            this.chkRunEndTimer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkRunEndTimer.Size = new System.Drawing.Size(86, 17);
            this.chkRunEndTimer.TabIndex = 11;
            this.chkRunEndTimer.Text = "Auto Update";
            this.chkRunEndTimer.UseVisualStyleBackColor = true;
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(161, 91);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(60, 20);
            this.txtDuration.TabIndex = 10;
            this.txtDuration.Text = "00:00:00";
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
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(231, 116);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(392, 116);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
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
            // dtpEndTime
            // 
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpEndTime.Location = new System.Drawing.Point(161, 66);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(102, 20);
            this.dtpEndTime.TabIndex = 4;
            this.dtpEndTime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpEndTime_KeyDown);
            this.dtpEndTime.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dtpEndTime_MouseDown);
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpStartTime.Location = new System.Drawing.Point(161, 40);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Size = new System.Drawing.Size(102, 20);
            this.dtpStartTime.TabIndex = 3;
            this.dtpStartTime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpStartTime_KeyDown);
            // 
            // chkBillable
            // 
            this.chkBillable.AutoSize = true;
            this.chkBillable.Checked = true;
            this.chkBillable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBillable.Location = new System.Drawing.Point(116, 118);
            this.chkBillable.Name = "chkBillable";
            this.chkBillable.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkBillable.Size = new System.Drawing.Size(59, 17);
            this.chkBillable.TabIndex = 2;
            this.chkBillable.Text = "Billable";
            this.chkBillable.UseVisualStyleBackColor = true;
            // 
            // txtUserInput
            // 
            this.txtUserInput.Location = new System.Drawing.Point(161, 13);
            this.txtUserInput.Name = "txtUserInput";
            this.txtUserInput.Size = new System.Drawing.Size(306, 20);
            this.txtUserInput.TabIndex = 1;
            this.txtUserInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserInput_KeyDown);
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
            // tmrPromptTicker
            // 
            this.tmrPromptTicker.Enabled = true;
            this.tmrPromptTicker.Interval = 500;
            this.tmrPromptTicker.Tick += new System.EventHandler(this.tmrPromptTicker_Tick);
            // 
            // frmPrompt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 171);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmPrompt";
            this.Text = "Time Entry";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.CheckBox chkBillable;
        private System.Windows.Forms.TextBox txtUserInput;
        private System.Windows.Forms.Label lblUserInput;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Timer tmrPromptTicker;
        private System.Windows.Forms.CheckBox chkRunEndTimer;
        private System.Windows.Forms.Button btnSkip;
    }
}