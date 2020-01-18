namespace RoboJo
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.cboPromptEveryValue = new System.Windows.Forms.ComboBox();
            this.lblPromptEvery = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblNextEntryInValue = new System.Windows.Forms.Label();
            this.lblCurrentEntryValue = new System.Windows.Forms.Label();
            this.lblLastEntryValue = new System.Windows.Forms.Label();
            this.lblNextEntryIn = new System.Windows.Forms.Label();
            this.lblLastEntry = new System.Windows.Forms.Label();
            this.timetrackerDataSet = new RoboJo.timetrackerDataSet();
            this.tmrPrompt = new System.Windows.Forms.Timer(this.components);
            this.timesheetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnStop = new System.Windows.Forms.Button();
            this.btnLogNow = new System.Windows.Forms.Button();
            this.dgTimesheet = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.starttimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endtimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.billableDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.hoursDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmrMain = new System.Windows.Forms.Timer(this.components);
            this.lblCurrentEntry = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.tsslCurrentEntry = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslCurrentEntryVal = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslTotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnResave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.timetrackerDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timesheetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgTimesheet)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "RoboJo is still running!";
            this.notifyIcon.BalloonTipTitle = "RoboJo";
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // cboPromptEveryValue
            // 
            this.cboPromptEveryValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPromptEveryValue.FormattingEnabled = true;
            this.cboPromptEveryValue.Items.AddRange(new object[] {
            "5 minutes",
            "15 minutes",
            "30 minutes",
            "60 minutes"});
            this.cboPromptEveryValue.Location = new System.Drawing.Point(348, 16);
            this.cboPromptEveryValue.Name = "cboPromptEveryValue";
            this.cboPromptEveryValue.Size = new System.Drawing.Size(121, 21);
            this.cboPromptEveryValue.TabIndex = 20;
            this.cboPromptEveryValue.SelectedIndexChanged += new System.EventHandler(this.cboPromptEveryValue_SelectedIndexChanged);
            // 
            // lblPromptEvery
            // 
            this.lblPromptEvery.AutoSize = true;
            this.lblPromptEvery.Location = new System.Drawing.Point(270, 20);
            this.lblPromptEvery.Name = "lblPromptEvery";
            this.lblPromptEvery.Size = new System.Drawing.Size(73, 13);
            this.lblPromptEvery.TabIndex = 19;
            this.lblPromptEvery.Text = "Prompt Every:";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(348, 54);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 18;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblNextEntryInValue
            // 
            this.lblNextEntryInValue.AutoSize = true;
            this.lblNextEntryInValue.Location = new System.Drawing.Point(92, 54);
            this.lblNextEntryInValue.Name = "lblNextEntryInValue";
            this.lblNextEntryInValue.Size = new System.Drawing.Size(45, 13);
            this.lblNextEntryInValue.TabIndex = 17;
            this.lblNextEntryInValue.Text = "<blank>";
            // 
            // lblCurrentEntryValue
            // 
            this.lblCurrentEntryValue.AutoSize = true;
            this.lblCurrentEntryValue.Location = new System.Drawing.Point(92, 34);
            this.lblCurrentEntryValue.Name = "lblCurrentEntryValue";
            this.lblCurrentEntryValue.Size = new System.Drawing.Size(45, 13);
            this.lblCurrentEntryValue.TabIndex = 16;
            this.lblCurrentEntryValue.Text = "<blank>";
            // 
            // lblLastEntryValue
            // 
            this.lblLastEntryValue.AutoSize = true;
            this.lblLastEntryValue.Location = new System.Drawing.Point(92, 16);
            this.lblLastEntryValue.Name = "lblLastEntryValue";
            this.lblLastEntryValue.Size = new System.Drawing.Size(45, 13);
            this.lblLastEntryValue.TabIndex = 15;
            this.lblLastEntryValue.Text = "<blank>";
            // 
            // lblNextEntryIn
            // 
            this.lblNextEntryIn.AutoSize = true;
            this.lblNextEntryIn.Location = new System.Drawing.Point(15, 54);
            this.lblNextEntryIn.Name = "lblNextEntryIn";
            this.lblNextEntryIn.Size = new System.Drawing.Size(71, 13);
            this.lblNextEntryIn.TabIndex = 13;
            this.lblNextEntryIn.Text = "Next Entry In:";
            // 
            // lblLastEntry
            // 
            this.lblLastEntry.AutoSize = true;
            this.lblLastEntry.Location = new System.Drawing.Point(15, 16);
            this.lblLastEntry.Name = "lblLastEntry";
            this.lblLastEntry.Size = new System.Drawing.Size(57, 13);
            this.lblLastEntry.TabIndex = 12;
            this.lblLastEntry.Text = "Last Entry:";
            // 
            // timetrackerDataSet
            // 
            this.timetrackerDataSet.DataSetName = "timetrackerDataSet";
            this.timetrackerDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tmrPrompt
            // 
            this.tmrPrompt.Interval = 1000;
            this.tmrPrompt.Tick += new System.EventHandler(this.tmrPrompt_Tick);
            // 
            // timesheetBindingSource
            // 
            this.timesheetBindingSource.DataMember = "timesheet";
            this.timesheetBindingSource.DataSource = this.timetrackerDataSet;
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(510, 54);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 23;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnLogNow
            // 
            this.btnLogNow.Location = new System.Drawing.Point(429, 54);
            this.btnLogNow.Name = "btnLogNow";
            this.btnLogNow.Size = new System.Drawing.Size(75, 23);
            this.btnLogNow.TabIndex = 22;
            this.btnLogNow.Text = "Log Now";
            this.btnLogNow.UseVisualStyleBackColor = true;
            this.btnLogNow.Click += new System.EventHandler(this.btnLogNow_Click);
            // 
            // dgTimesheet
            // 
            this.dgTimesheet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgTimesheet.AutoGenerateColumns = false;
            this.dgTimesheet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTimesheet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.starttimeDataGridViewTextBoxColumn,
            this.endtimeDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.billableDataGridViewTextBoxColumn,
            this.hoursDataGridViewTextBoxColumn});
            this.dgTimesheet.DataSource = this.timesheetBindingSource;
            this.dgTimesheet.Location = new System.Drawing.Point(18, 83);
            this.dgTimesheet.Name = "dgTimesheet";
            this.dgTimesheet.Size = new System.Drawing.Size(797, 435);
            this.dgTimesheet.TabIndex = 21;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // starttimeDataGridViewTextBoxColumn
            // 
            this.starttimeDataGridViewTextBoxColumn.DataPropertyName = "start_time";
            this.starttimeDataGridViewTextBoxColumn.HeaderText = "Start Time";
            this.starttimeDataGridViewTextBoxColumn.Name = "starttimeDataGridViewTextBoxColumn";
            // 
            // endtimeDataGridViewTextBoxColumn
            // 
            this.endtimeDataGridViewTextBoxColumn.DataPropertyName = "end_time";
            this.endtimeDataGridViewTextBoxColumn.HeaderText = "End Time";
            this.endtimeDataGridViewTextBoxColumn.Name = "endtimeDataGridViewTextBoxColumn";
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            // 
            // billableDataGridViewTextBoxColumn
            // 
            this.billableDataGridViewTextBoxColumn.DataPropertyName = "billable";
            this.billableDataGridViewTextBoxColumn.HeaderText = "Billable";
            this.billableDataGridViewTextBoxColumn.Name = "billableDataGridViewTextBoxColumn";
            this.billableDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.billableDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // hoursDataGridViewTextBoxColumn
            // 
            this.hoursDataGridViewTextBoxColumn.DataPropertyName = "hours";
            this.hoursDataGridViewTextBoxColumn.HeaderText = "Hours";
            this.hoursDataGridViewTextBoxColumn.Name = "hoursDataGridViewTextBoxColumn";
            // 
            // tmrMain
            // 
            this.tmrMain.Interval = 1000;
            this.tmrMain.Tick += new System.EventHandler(this.tmrMain_Tick);
            // 
            // lblCurrentEntry
            // 
            this.lblCurrentEntry.AutoSize = true;
            this.lblCurrentEntry.Location = new System.Drawing.Point(15, 34);
            this.lblCurrentEntry.Name = "lblCurrentEntry";
            this.lblCurrentEntry.Size = new System.Drawing.Size(71, 13);
            this.lblCurrentEntry.TabIndex = 14;
            this.lblCurrentEntry.Text = "Current Entry:";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.tsProgressBar,
            this.tsslCurrentEntry,
            this.tsslCurrentEntryVal,
            this.tsslTotal});
            this.statusStrip.Location = new System.Drawing.Point(0, 531);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(831, 22);
            this.statusStrip.TabIndex = 24;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(64, 17);
            this.toolStripStatusLabel.Text = "Next Event";
            // 
            // tsProgressBar
            // 
            this.tsProgressBar.Name = "tsProgressBar";
            this.tsProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // tsslCurrentEntry
            // 
            this.tsslCurrentEntry.Name = "tsslCurrentEntry";
            this.tsslCurrentEntry.Size = new System.Drawing.Size(80, 17);
            this.tsslCurrentEntry.Text = "Current Entry:";
            // 
            // tsslCurrentEntryVal
            // 
            this.tsslCurrentEntryVal.Name = "tsslCurrentEntryVal";
            this.tsslCurrentEntryVal.Size = new System.Drawing.Size(0, 17);
            // 
            // tsslTotal
            // 
            this.tsslTotal.Name = "tsslTotal";
            this.tsslTotal.Size = new System.Drawing.Size(38, 17);
            this.tsslTotal.Text = "Total: ";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(592, 54);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 25;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnResave
            // 
            this.btnResave.Location = new System.Drawing.Point(673, 54);
            this.btnResave.Name = "btnResave";
            this.btnResave.Size = new System.Drawing.Size(75, 23);
            this.btnResave.TabIndex = 26;
            this.btnResave.Text = "Resave";
            this.btnResave.UseVisualStyleBackColor = true;
            this.btnResave.Click += new System.EventHandler(this.btnResave_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 553);
            this.Controls.Add(this.btnResave);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.cboPromptEveryValue);
            this.Controls.Add(this.lblPromptEvery);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblNextEntryInValue);
            this.Controls.Add(this.lblCurrentEntryValue);
            this.Controls.Add(this.lblLastEntryValue);
            this.Controls.Add(this.lblNextEntryIn);
            this.Controls.Add(this.lblLastEntry);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnLogNow);
            this.Controls.Add(this.dgTimesheet);
            this.Controls.Add(this.lblCurrentEntry);
            this.Name = "frmMain";
            this.Text = "RoboJo Time Tracker";
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.timetrackerDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timesheetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgTimesheet)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ComboBox cboPromptEveryValue;
        private System.Windows.Forms.Label lblPromptEvery;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblNextEntryInValue;
        private System.Windows.Forms.Label lblCurrentEntryValue;
        private System.Windows.Forms.Label lblLastEntryValue;
        private System.Windows.Forms.Label lblNextEntryIn;
        private System.Windows.Forms.Label lblLastEntry;
        private timetrackerDataSet timetrackerDataSet;
        private System.Windows.Forms.Timer tmrPrompt;
        private System.Windows.Forms.BindingSource timesheetBindingSource;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnLogNow;
        private System.Windows.Forms.DataGridView dgTimesheet;
        private System.Windows.Forms.Timer tmrMain;
        private System.Windows.Forms.Label lblCurrentEntry;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripProgressBar tsProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel tsslCurrentEntry;
        private System.Windows.Forms.ToolStripStatusLabel tsslCurrentEntryVal;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn starttimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn endtimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn billableDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hoursDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripStatusLabel tsslTotal;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnResave;
    }
}

