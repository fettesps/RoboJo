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
            this.lblNextEntryInValue = new System.Windows.Forms.Label();
            this.lblCurrentEntryValue = new System.Windows.Forms.Label();
            this.lblLastEntryValue = new System.Windows.Forms.Label();
            this.lblNextEntryIn = new System.Windows.Forms.Label();
            this.lblLastEntry = new System.Windows.Forms.Label();
            this.tmrPrompt = new System.Windows.Forms.Timer(this.components);
            this.dgTimesheet = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.starttimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endtimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.billableDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.hoursDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timesheetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.timetrackerDataSet = new RoboJo.timetrackerDataSet();
            this.tmrMain = new System.Windows.Forms.Timer(this.components);
            this.lblCurrentEntry = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.tsslCurrentEntry = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslCurrentEntryVal = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslTotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Start = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Stop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_LogNow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Split = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Resave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Clear = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_About = new System.Windows.Forms.ToolStripMenuItem();
            this.lblDate_Label = new System.Windows.Forms.Label();
            this.lblDate_Value = new System.Windows.Forms.Label();
            this.btnMultiButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgTimesheet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timesheetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timetrackerDataSet)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
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
            this.cboPromptEveryValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPromptEveryValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPromptEveryValue.FormattingEnabled = true;
            this.cboPromptEveryValue.Items.AddRange(new object[] {
            "5 minutes",
            "15 minutes",
            "30 minutes",
            "60 minutes"});
            this.cboPromptEveryValue.Location = new System.Drawing.Point(695, 30);
            this.cboPromptEveryValue.Name = "cboPromptEveryValue";
            this.cboPromptEveryValue.Size = new System.Drawing.Size(121, 21);
            this.cboPromptEveryValue.TabIndex = 20;
            this.cboPromptEveryValue.SelectedIndexChanged += new System.EventHandler(this.cboPromptEveryValue_SelectedIndexChanged);
            // 
            // lblPromptEvery
            // 
            this.lblPromptEvery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPromptEvery.AutoSize = true;
            this.lblPromptEvery.Location = new System.Drawing.Point(616, 33);
            this.lblPromptEvery.Name = "lblPromptEvery";
            this.lblPromptEvery.Size = new System.Drawing.Size(73, 13);
            this.lblPromptEvery.TabIndex = 19;
            this.lblPromptEvery.Text = "Prompt Every:";
            // 
            // lblNextEntryInValue
            // 
            this.lblNextEntryInValue.AutoSize = true;
            this.lblNextEntryInValue.Location = new System.Drawing.Point(92, 71);
            this.lblNextEntryInValue.Name = "lblNextEntryInValue";
            this.lblNextEntryInValue.Size = new System.Drawing.Size(45, 13);
            this.lblNextEntryInValue.TabIndex = 17;
            this.lblNextEntryInValue.Text = "<blank>";
            // 
            // lblCurrentEntryValue
            // 
            this.lblCurrentEntryValue.AutoSize = true;
            this.lblCurrentEntryValue.Location = new System.Drawing.Point(92, 51);
            this.lblCurrentEntryValue.Name = "lblCurrentEntryValue";
            this.lblCurrentEntryValue.Size = new System.Drawing.Size(45, 13);
            this.lblCurrentEntryValue.TabIndex = 16;
            this.lblCurrentEntryValue.Text = "<blank>";
            // 
            // lblLastEntryValue
            // 
            this.lblLastEntryValue.AutoSize = true;
            this.lblLastEntryValue.Location = new System.Drawing.Point(92, 30);
            this.lblLastEntryValue.Name = "lblLastEntryValue";
            this.lblLastEntryValue.Size = new System.Drawing.Size(45, 13);
            this.lblLastEntryValue.TabIndex = 15;
            this.lblLastEntryValue.Text = "<blank>";
            // 
            // lblNextEntryIn
            // 
            this.lblNextEntryIn.AutoSize = true;
            this.lblNextEntryIn.Location = new System.Drawing.Point(15, 71);
            this.lblNextEntryIn.Name = "lblNextEntryIn";
            this.lblNextEntryIn.Size = new System.Drawing.Size(71, 13);
            this.lblNextEntryIn.TabIndex = 13;
            this.lblNextEntryIn.Text = "Next Entry In:";
            // 
            // lblLastEntry
            // 
            this.lblLastEntry.AutoSize = true;
            this.lblLastEntry.Location = new System.Drawing.Point(15, 30);
            this.lblLastEntry.Name = "lblLastEntry";
            this.lblLastEntry.Size = new System.Drawing.Size(57, 13);
            this.lblLastEntry.TabIndex = 12;
            this.lblLastEntry.Text = "Last Entry:";
            // 
            // tmrPrompt
            // 
            this.tmrPrompt.Interval = 1000;
            this.tmrPrompt.Tick += new System.EventHandler(this.tmrPrompt_Tick);
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
            this.dgTimesheet.Location = new System.Drawing.Point(18, 99);
            this.dgTimesheet.Name = "dgTimesheet";
            this.dgTimesheet.Size = new System.Drawing.Size(797, 419);
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
            // timesheetBindingSource
            // 
            this.timesheetBindingSource.DataMember = "timesheet";
            this.timesheetBindingSource.DataSource = this.timetrackerDataSet;
            // 
            // timetrackerDataSet
            // 
            this.timetrackerDataSet.DataSetName = "timetrackerDataSet";
            this.timetrackerDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tmrMain
            // 
            this.tmrMain.Interval = 1000;
            this.tmrMain.Tick += new System.EventHandler(this.tmrMain_Tick);
            // 
            // lblCurrentEntry
            // 
            this.lblCurrentEntry.AutoSize = true;
            this.lblCurrentEntry.Location = new System.Drawing.Point(15, 51);
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
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(831, 24);
            this.menuStrip1.TabIndex = 27;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_Start,
            this.toolStripMenuItem_Stop,
            this.toolStripMenuItem_LogNow,
            this.toolStripMenuItem_Split,
            this.toolStripMenuItem_Resave,
            this.toolStripMenuItem_Clear,
            this.toolStripSeparator2,
            this.toolStripMenuItem_Exit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // toolStripMenuItem_Start
            // 
            this.toolStripMenuItem_Start.Name = "toolStripMenuItem_Start";
            this.toolStripMenuItem_Start.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem_Start.Text = "&Start";
            this.toolStripMenuItem_Start.Click += new System.EventHandler(this.toolStripMenuItem_Start_Click);
            // 
            // toolStripMenuItem_Stop
            // 
            this.toolStripMenuItem_Stop.Name = "toolStripMenuItem_Stop";
            this.toolStripMenuItem_Stop.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem_Stop.Text = "Sto&p";
            this.toolStripMenuItem_Stop.Click += new System.EventHandler(this.toolStripMenuItem_Stop_Click);
            // 
            // toolStripMenuItem_LogNow
            // 
            this.toolStripMenuItem_LogNow.Name = "toolStripMenuItem_LogNow";
            this.toolStripMenuItem_LogNow.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem_LogNow.Text = "&Log Now";
            this.toolStripMenuItem_LogNow.Click += new System.EventHandler(this.toolStripMenuItem_LogNow_Click);
            // 
            // toolStripMenuItem_Split
            // 
            this.toolStripMenuItem_Split.Name = "toolStripMenuItem_Split";
            this.toolStripMenuItem_Split.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem_Split.Text = "Split Entry";
            this.toolStripMenuItem_Split.Click += new System.EventHandler(this.toolStripMenuItem_Split_Click);
            // 
            // toolStripMenuItem_Resave
            // 
            this.toolStripMenuItem_Resave.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem_Resave.Image")));
            this.toolStripMenuItem_Resave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem_Resave.Name = "toolStripMenuItem_Resave";
            this.toolStripMenuItem_Resave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.toolStripMenuItem_Resave.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem_Resave.Text = "&Resave";
            this.toolStripMenuItem_Resave.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripMenuItem_Clear
            // 
            this.toolStripMenuItem_Clear.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem_Clear.Image")));
            this.toolStripMenuItem_Clear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem_Clear.Name = "toolStripMenuItem_Clear";
            this.toolStripMenuItem_Clear.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.toolStripMenuItem_Clear.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem_Clear.Text = "&Clear";
            this.toolStripMenuItem_Clear.Click += new System.EventHandler(this.toolStripMenuItem_Clear_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // toolStripMenuItem_Exit
            // 
            this.toolStripMenuItem_Exit.Name = "toolStripMenuItem_Exit";
            this.toolStripMenuItem_Exit.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem_Exit.Text = "E&xit";
            this.toolStripMenuItem_Exit.Click += new System.EventHandler(this.toolStripMenuItem_Exit_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_About});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // toolStripMenuItem_About
            // 
            this.toolStripMenuItem_About.Name = "toolStripMenuItem_About";
            this.toolStripMenuItem_About.Size = new System.Drawing.Size(116, 22);
            this.toolStripMenuItem_About.Text = "&About...";
            this.toolStripMenuItem_About.Click += new System.EventHandler(this.toolStripMenuItem_About_Click);
            // 
            // lblDate_Label
            // 
            this.lblDate_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate_Label.AutoSize = true;
            this.lblDate_Label.Location = new System.Drawing.Point(716, 71);
            this.lblDate_Label.Name = "lblDate_Label";
            this.lblDate_Label.Size = new System.Drawing.Size(33, 13);
            this.lblDate_Label.TabIndex = 28;
            this.lblDate_Label.Text = "Date:";
            // 
            // lblDate_Value
            // 
            this.lblDate_Value.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate_Value.AutoSize = true;
            this.lblDate_Value.Location = new System.Drawing.Point(751, 71);
            this.lblDate_Value.Name = "lblDate_Value";
            this.lblDate_Value.Size = new System.Drawing.Size(64, 13);
            this.lblDate_Value.TabIndex = 29;
            this.lblDate_Value.Text = "<The Date>";
            // 
            // btnMultiButton
            // 
            this.btnMultiButton.Location = new System.Drawing.Point(357, 30);
            this.btnMultiButton.Name = "btnMultiButton";
            this.btnMultiButton.Size = new System.Drawing.Size(75, 23);
            this.btnMultiButton.TabIndex = 30;
            this.btnMultiButton.Text = "Multi Button";
            this.btnMultiButton.UseVisualStyleBackColor = true;
            this.btnMultiButton.Click += new System.EventHandler(this.btnMultiButton_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 553);
            this.Controls.Add(this.btnMultiButton);
            this.Controls.Add(this.lblDate_Value);
            this.Controls.Add(this.lblDate_Label);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.cboPromptEveryValue);
            this.Controls.Add(this.lblPromptEvery);
            this.Controls.Add(this.lblNextEntryInValue);
            this.Controls.Add(this.lblCurrentEntryValue);
            this.Controls.Add(this.lblLastEntryValue);
            this.Controls.Add(this.lblNextEntryIn);
            this.Controls.Add(this.lblLastEntry);
            this.Controls.Add(this.dgTimesheet);
            this.Controls.Add(this.lblCurrentEntry);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "RoboJo Time Tracker";
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgTimesheet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timesheetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timetrackerDataSet)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ComboBox cboPromptEveryValue;
        private System.Windows.Forms.Label lblPromptEvery;
        private System.Windows.Forms.Label lblNextEntryInValue;
        private System.Windows.Forms.Label lblCurrentEntryValue;
        private System.Windows.Forms.Label lblLastEntryValue;
        private System.Windows.Forms.Label lblNextEntryIn;
        private System.Windows.Forms.Label lblLastEntry;
        private timetrackerDataSet timetrackerDataSet;
        private System.Windows.Forms.Timer tmrPrompt;
        private System.Windows.Forms.BindingSource timesheetBindingSource;
        private System.Windows.Forms.DataGridView dgTimesheet;
        private System.Windows.Forms.Timer tmrMain;
        private System.Windows.Forms.Label lblCurrentEntry;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripProgressBar tsProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel tsslCurrentEntry;
        private System.Windows.Forms.ToolStripStatusLabel tsslCurrentEntryVal;
        private System.Windows.Forms.ToolStripStatusLabel tsslTotal;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Clear;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Resave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Exit;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_About;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Start;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Stop;
        private System.Windows.Forms.Label lblDate_Label;
        private System.Windows.Forms.Label lblDate_Value;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_LogNow;
        private System.Windows.Forms.Button btnMultiButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn starttimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn endtimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn billableDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hoursDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Split;
    }
}

