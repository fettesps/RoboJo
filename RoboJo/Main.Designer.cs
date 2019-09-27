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
            this.tmrMain = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgTimesheet = new System.Windows.Forms.DataGridView();
            this.cboPromptEveryValue = new System.Windows.Forms.ComboBox();
            this.lblPromptEvery = new System.Windows.Forms.Label();
            this.btnStartOrEnd = new System.Windows.Forms.Button();
            this.lblNextEntryInValue = new System.Windows.Forms.Label();
            this.lblCurrentEntryValue = new System.Windows.Forms.Label();
            this.lblLastEntryValue = new System.Windows.Forms.Label();
            this.lblCurrentEntry = new System.Windows.Forms.Label();
            this.lblNextEntryIn = new System.Windows.Forms.Label();
            this.lblLastEntry = new System.Windows.Forms.Label();
            this.tmrPrompt = new System.Windows.Forms.Timer(this.components);
            this.Hours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Start = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.End = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaskDetails = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Billable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTimesheet)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrMain
            // 
            this.tmrMain.Interval = 1000;
            this.tmrMain.Tick += new System.EventHandler(this.tmrMain_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgTimesheet);
            this.panel1.Controls.Add(this.cboPromptEveryValue);
            this.panel1.Controls.Add(this.lblPromptEvery);
            this.panel1.Controls.Add(this.btnStartOrEnd);
            this.panel1.Controls.Add(this.lblNextEntryInValue);
            this.panel1.Controls.Add(this.lblCurrentEntryValue);
            this.panel1.Controls.Add(this.lblLastEntryValue);
            this.panel1.Controls.Add(this.lblCurrentEntry);
            this.panel1.Controls.Add(this.lblNextEntryIn);
            this.panel1.Controls.Add(this.lblLastEntry);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(611, 420);
            this.panel1.TabIndex = 0;
            // 
            // dgTimesheet
            // 
            this.dgTimesheet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTimesheet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Hours,
            this.Start,
            this.End,
            this.TaskDetails,
            this.Billable});
            this.dgTimesheet.Location = new System.Drawing.Point(7, 71);
            this.dgTimesheet.Name = "dgTimesheet";
            this.dgTimesheet.Size = new System.Drawing.Size(601, 346);
            this.dgTimesheet.TabIndex = 9;
            // 
            // cboPromptEveryValue
            // 
            this.cboPromptEveryValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPromptEveryValue.FormattingEnabled = true;
            this.cboPromptEveryValue.Items.AddRange(new object[] {
            "15 minutes",
            "30 minutes",
            "60 minutes"});
            this.cboPromptEveryValue.Location = new System.Drawing.Point(337, 4);
            this.cboPromptEveryValue.Name = "cboPromptEveryValue";
            this.cboPromptEveryValue.Size = new System.Drawing.Size(121, 21);
            this.cboPromptEveryValue.TabIndex = 8;
            this.cboPromptEveryValue.SelectedIndexChanged += new System.EventHandler(this.cboPromptEveryValue_SelectedIndexChanged);
            // 
            // lblPromptEvery
            // 
            this.lblPromptEvery.AutoSize = true;
            this.lblPromptEvery.Location = new System.Drawing.Point(259, 8);
            this.lblPromptEvery.Name = "lblPromptEvery";
            this.lblPromptEvery.Size = new System.Drawing.Size(73, 13);
            this.lblPromptEvery.TabIndex = 7;
            this.lblPromptEvery.Text = "Prompt Every:";
            // 
            // btnStartOrEnd
            // 
            this.btnStartOrEnd.Location = new System.Drawing.Point(337, 42);
            this.btnStartOrEnd.Name = "btnStartOrEnd";
            this.btnStartOrEnd.Size = new System.Drawing.Size(75, 23);
            this.btnStartOrEnd.TabIndex = 6;
            this.btnStartOrEnd.Text = "Start";
            this.btnStartOrEnd.UseVisualStyleBackColor = true;
            this.btnStartOrEnd.Click += new System.EventHandler(this.btnStartOrEnd_Click);
            // 
            // lblNextEntryInValue
            // 
            this.lblNextEntryInValue.AutoSize = true;
            this.lblNextEntryInValue.Location = new System.Drawing.Point(81, 42);
            this.lblNextEntryInValue.Name = "lblNextEntryInValue";
            this.lblNextEntryInValue.Size = new System.Drawing.Size(45, 13);
            this.lblNextEntryInValue.TabIndex = 5;
            this.lblNextEntryInValue.Text = "<blank>";
            // 
            // lblCurrentEntryValue
            // 
            this.lblCurrentEntryValue.AutoSize = true;
            this.lblCurrentEntryValue.Location = new System.Drawing.Point(81, 22);
            this.lblCurrentEntryValue.Name = "lblCurrentEntryValue";
            this.lblCurrentEntryValue.Size = new System.Drawing.Size(45, 13);
            this.lblCurrentEntryValue.TabIndex = 4;
            this.lblCurrentEntryValue.Text = "<blank>";
            // 
            // lblLastEntryValue
            // 
            this.lblLastEntryValue.AutoSize = true;
            this.lblLastEntryValue.Location = new System.Drawing.Point(81, 4);
            this.lblLastEntryValue.Name = "lblLastEntryValue";
            this.lblLastEntryValue.Size = new System.Drawing.Size(45, 13);
            this.lblLastEntryValue.TabIndex = 3;
            this.lblLastEntryValue.Text = "<blank>";
            // 
            // lblCurrentEntry
            // 
            this.lblCurrentEntry.AutoSize = true;
            this.lblCurrentEntry.Location = new System.Drawing.Point(4, 22);
            this.lblCurrentEntry.Name = "lblCurrentEntry";
            this.lblCurrentEntry.Size = new System.Drawing.Size(71, 13);
            this.lblCurrentEntry.TabIndex = 2;
            this.lblCurrentEntry.Text = "Current Entry:";
            // 
            // lblNextEntryIn
            // 
            this.lblNextEntryIn.AutoSize = true;
            this.lblNextEntryIn.Location = new System.Drawing.Point(4, 42);
            this.lblNextEntryIn.Name = "lblNextEntryIn";
            this.lblNextEntryIn.Size = new System.Drawing.Size(71, 13);
            this.lblNextEntryIn.TabIndex = 1;
            this.lblNextEntryIn.Text = "Next Entry In:";
            // 
            // lblLastEntry
            // 
            this.lblLastEntry.AutoSize = true;
            this.lblLastEntry.Location = new System.Drawing.Point(4, 4);
            this.lblLastEntry.Name = "lblLastEntry";
            this.lblLastEntry.Size = new System.Drawing.Size(57, 13);
            this.lblLastEntry.TabIndex = 0;
            this.lblLastEntry.Text = "Last Entry:";
            // 
            // tmrPrompt
            // 
            this.tmrPrompt.Interval = 1000;
            this.tmrPrompt.Tick += new System.EventHandler(this.tmrPrompt_Tick);
            // 
            // Hours
            // 
            this.Hours.HeaderText = "Hours";
            this.Hours.Name = "Hours";
            // 
            // Start
            // 
            this.Start.HeaderText = "Start";
            this.Start.Name = "Start";
            // 
            // End
            // 
            this.End.HeaderText = "End";
            this.End.Name = "End";
            // 
            // TaskDetails
            // 
            this.TaskDetails.HeaderText = "Task Details";
            this.TaskDetails.Name = "TaskDetails";
            // 
            // Billable
            // 
            this.Billable.HeaderText = "Billable";
            this.Billable.Name = "Billable";
            this.Billable.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Billable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 444);
            this.Controls.Add(this.panel1);
            this.Name = "frmMain";
            this.Text = "Timesheet Logger";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTimesheet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnStartOrEnd;
        private System.Windows.Forms.Label lblNextEntryInValue;
        private System.Windows.Forms.Label lblCurrentEntryValue;
        private System.Windows.Forms.Label lblLastEntryValue;
        private System.Windows.Forms.Label lblCurrentEntry;
        private System.Windows.Forms.Label lblNextEntryIn;
        private System.Windows.Forms.Label lblLastEntry;
        private System.Windows.Forms.ComboBox cboPromptEveryValue;
        private System.Windows.Forms.Label lblPromptEvery;
        private System.Windows.Forms.Timer tmrPrompt;
        private System.Windows.Forms.DataGridView dgTimesheet;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hours;
        private System.Windows.Forms.DataGridViewTextBoxColumn Start;
        private System.Windows.Forms.DataGridViewTextBoxColumn End;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskDetails;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Billable;
    }
}

