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
            this.lblClient = new System.Windows.Forms.Label();
            this.cboClient = new System.Windows.Forms.ComboBox();
            this.clientsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.timetrackerDataSet = new RoboJo.timetrackerDataSet();
            this.lblTask = new System.Windows.Forms.Label();
            this.cboTasks = new System.Windows.Forms.ComboBox();
            this.tasksBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblProject = new System.Windows.Forms.Label();
            this.cboProject = new System.Windows.Forms.ComboBox();
            this.projectsBindingSource = new System.Windows.Forms.BindingSource(this.components);
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
            ((System.ComponentModel.ISupportInitialize)(this.clientsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timetrackerDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tasksBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblClient);
            this.panel1.Controls.Add(this.cboClient);
            this.panel1.Controls.Add(this.lblTask);
            this.panel1.Controls.Add(this.cboTasks);
            this.panel1.Controls.Add(this.lblProject);
            this.panel1.Controls.Add(this.cboProject);
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
            this.panel1.Size = new System.Drawing.Size(555, 174);
            this.panel1.TabIndex = 0;
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Location = new System.Drawing.Point(118, 40);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(36, 13);
            this.lblClient.TabIndex = 18;
            this.lblClient.Text = "Client:";
            // 
            // cboClient
            // 
            this.cboClient.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientsBindingSource, "name", true));
            this.cboClient.DataSource = this.clientsBindingSource;
            this.cboClient.DisplayMember = "name";
            this.cboClient.FormattingEnabled = true;
            this.cboClient.Location = new System.Drawing.Point(161, 37);
            this.cboClient.Name = "cboClient";
            this.cboClient.Size = new System.Drawing.Size(121, 21);
            this.cboClient.TabIndex = 17;
            this.cboClient.ValueMember = "client_id";
            // 
            // clientsBindingSource
            // 
            this.clientsBindingSource.DataMember = "clients";
            this.clientsBindingSource.DataSource = this.timetrackerDataSet;
            // 
            // timetrackerDataSet
            // 
            this.timetrackerDataSet.DataSetName = "timetrackerDataSet";
            this.timetrackerDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblTask
            // 
            this.lblTask.AutoSize = true;
            this.lblTask.Location = new System.Drawing.Point(120, 91);
            this.lblTask.Name = "lblTask";
            this.lblTask.Size = new System.Drawing.Size(34, 13);
            this.lblTask.TabIndex = 16;
            this.lblTask.Text = "Task:";
            // 
            // cboTasks
            // 
            this.cboTasks.DataSource = this.tasksBindingSource;
            this.cboTasks.DisplayMember = "name";
            this.cboTasks.FormattingEnabled = true;
            this.cboTasks.Location = new System.Drawing.Point(161, 88);
            this.cboTasks.Name = "cboTasks";
            this.cboTasks.Size = new System.Drawing.Size(121, 21);
            this.cboTasks.TabIndex = 15;
            this.cboTasks.ValueMember = "task_id";
            // 
            // tasksBindingSource
            // 
            this.tasksBindingSource.DataMember = "tasks";
            this.tasksBindingSource.DataSource = this.timetrackerDataSet;
            // 
            // lblProject
            // 
            this.lblProject.AutoSize = true;
            this.lblProject.Location = new System.Drawing.Point(111, 65);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(43, 13);
            this.lblProject.TabIndex = 14;
            this.lblProject.Text = "Project:";
            // 
            // cboProject
            // 
            this.cboProject.DataSource = this.projectsBindingSource;
            this.cboProject.DisplayMember = "name";
            this.cboProject.FormattingEnabled = true;
            this.cboProject.Location = new System.Drawing.Point(161, 62);
            this.cboProject.Name = "cboProject";
            this.cboProject.Size = new System.Drawing.Size(121, 21);
            this.cboProject.TabIndex = 13;
            this.cboProject.ValueMember = "project_id";
            // 
            // projectsBindingSource
            // 
            this.projectsBindingSource.DataMember = "projects";
            this.projectsBindingSource.DataSource = this.timetrackerDataSet;
            // 
            // btnSkip
            // 
            this.btnSkip.Location = new System.Drawing.Point(336, 138);
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
            this.chkRunEndTimer.Location = new System.Drawing.Point(461, 68);
            this.chkRunEndTimer.Name = "chkRunEndTimer";
            this.chkRunEndTimer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkRunEndTimer.Size = new System.Drawing.Size(86, 17);
            this.chkRunEndTimer.TabIndex = 11;
            this.chkRunEndTimer.Text = "Auto Update";
            this.chkRunEndTimer.UseVisualStyleBackColor = true;
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(353, 91);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(60, 20);
            this.txtDuration.TabIndex = 10;
            this.txtDuration.Text = "00:00:00";
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(296, 94);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(50, 13);
            this.lblDuration.TabIndex = 9;
            this.lblDuration.Text = "Duration:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(256, 138);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(417, 138);
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
            this.label2.Location = new System.Drawing.Point(291, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "End Time:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(289, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Start Time:";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpEndTime.Location = new System.Drawing.Point(353, 62);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(102, 20);
            this.dtpEndTime.TabIndex = 4;
            this.dtpEndTime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpEndTime_KeyDown);
            this.dtpEndTime.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dtpEndTime_MouseDown);
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpStartTime.Location = new System.Drawing.Point(353, 37);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Size = new System.Drawing.Size(102, 20);
            this.dtpStartTime.TabIndex = 3;
            // 
            // chkBillable
            // 
            this.chkBillable.AutoSize = true;
            this.chkBillable.Checked = true;
            this.chkBillable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBillable.Location = new System.Drawing.Point(223, 114);
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
            this.txtUserInput.Size = new System.Drawing.Size(386, 20);
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
            this.ClientSize = new System.Drawing.Size(579, 195);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmPrompt";
            this.Text = "Time Entry";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timetrackerDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tasksBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectsBindingSource)).EndInit();
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
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.ComboBox cboClient;
        private System.Windows.Forms.BindingSource clientsBindingSource;
        private timetrackerDataSet timetrackerDataSet;
        private System.Windows.Forms.Label lblTask;
        private System.Windows.Forms.ComboBox cboTasks;
        private System.Windows.Forms.BindingSource tasksBindingSource;
        private System.Windows.Forms.Label lblProject;
        private System.Windows.Forms.ComboBox cboProject;
        private System.Windows.Forms.BindingSource projectsBindingSource;
    }
}