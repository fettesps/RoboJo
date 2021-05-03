using RoboJo.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RoboJo
{
    public partial class frmMain : Form
    {
        private DateTime? _dtStartTimer;        // Stores current timer's start time, is reset when timer is stopped
        private DateTime? _dtEndTimer;          // Stores time for the last time entry that was entered
        private DateTime? _dtStartAbsolute;     // Stores original start time for the application life cycle
        private DateTime? _dtStartProgress;     // Stores start time for the progress bar
        private bool _booInputActive = false;
        private bool _booBillable = true;
        private bool _booRunEndTimer = true;
        private IDAL _dal;

        #region Constructor

        public frmMain()
        {
            try
            {
                _dal = Factory.OpenDB();

                InitializeComponent();
                cboPromptEveryValue.SelectedIndex = 2; 
                tmrMain.Interval = 1000; 
                cboPromptEveryValue_SelectedIndexChanged(this, null);
                lblDate_Value.Text = System.DateTime.Now.ToShortDateString();
                btnMultiButton.Text = "Start";

                LoadRecords();

                this.Text = Application.ProductName + " - v" + Application.ProductVersion;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading application." + System.Environment.NewLine + ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Methods

        private void LoadRecords()
        {
            try
            {
                // Get Records
                IEnumerable<Entry> entries =_dal.LoadEntries_fromDB();
                entries = entries.OrderBy(c => c.StartTime);

                // Add to Grid
                foreach(Entry entry in entries)
                {
                    timetrackerDataSet.AcceptChanges();

                    DataRow dr = timetrackerDataSet.Tables[4].NewRow();

                    dr["id"] = entry.Entry_ID;
                    dr["start_date"] = entry.StartTime.Value.ToShortDateString();
                    dr["start_time"] = entry.StartTime.Value.ToShortTimeString();
                    dr["end_date"] = entry.EndTime.Value.ToShortDateString();
                    dr["end_time"] = entry.EndTime.Value.ToShortTimeString();
                    dr["description"] = entry.Description;
                    dr["hours"] = entry.Hours;
                    dr["billable"] = entry.Billable;

                    timetrackerDataSet.timesheet.AddtimesheetRow((timetrackerDataSet.timesheetRow)dr);
                    timetrackerDataSet.AcceptChanges();
                }

                // Load last entry
                lblCurrentEntryValue.Text = entries.LastOrDefault()?.Description;
                tsslCurrentEntryVal.Text = entries.LastOrDefault()?.Description;

                _dtStartTimer = entries.FirstOrDefault()?.StartTime;
                _dtEndTimer = entries.LastOrDefault()?.EndTime;
                
                CalculateTotals();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void AddTimeRecord(String strDetails, bool booBillable = true, DateTime? dtStart = null, DateTime? dtEnd = null)
        {
            try
            {
                // Calculate hours, to nearest half hour
                dtStart = dtStart != null ? dtStart.Value : DateTime.Now;
                dtEnd = dtEnd != null ? dtEnd.Value : DateTime.Now;

                TimeSpan ts = dtEnd.Value - dtStart.Value;
                TimeSpan tsHours = ts.RoundToNearestMinutes(15);

                // Save it to the database
                long lngInsertedId = _dal.WriteEntries_toDB(dtStart, DateTime.Now, strDetails, tsHours, true);

                // Add to grid
                AddToGrid(lngInsertedId, strDetails, booBillable, dtStart, dtEnd, tsHours);

                // Update Totals
                CalculateTotals();

                // Update Trackers
                lblLastEntryValue.Text = lblCurrentEntryValue.Text;
                lblCurrentEntryValue.Text = strDetails;
                tsslCurrentEntryVal.Text = strDetails;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void AddToGrid(long lngEntryId, string strUserInput, bool booBillable, DateTime? dtStart, DateTime? dtEnd, TimeSpan tsHours)
        {
            try
            {
                timetrackerDataSet.AcceptChanges();

                DataRow dr = timetrackerDataSet.Tables[4].NewRow();

                dr["id"] = lngEntryId;
                dr["start_date"] = dtStart.Value.ToShortDateString();
                dr["start_time"] = dtStart.Value.ToShortTimeString();
                dr["end_date"] = dtEnd.Value.ToShortDateString();
                dr["end_time"] = dtEnd.Value.ToShortTimeString();
                dr["description"] = strUserInput;
                dr["hours"] = tsHours.ToString();
                dr["billable"] = booBillable ? 1 : 0;

                timetrackerDataSet.timesheet.AddtimesheetRow((timetrackerDataSet.timesheetRow)dr);
                timetrackerDataSet.AcceptChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void SaveSplitTimeRecord(String UserInput_First, bool Billable_First, DateTime? StartTime_First, DateTime? EndTime_First, TimeSpan ts_First,
                                        String UserInput_Second, bool Billable_Second, DateTime? StartTime_Second, DateTime? EndTime_Second, TimeSpan ts_Second)
        {
            try
            {
                #region First Record 

                // Save it to the database
                long lngInsertedId_First = _dal.WriteEntries_toDB(StartTime_First, EndTime_First, UserInput_First, ts_First, Billable_First);

                // Add to grid
                AddToGrid(lngInsertedId_First, UserInput_First, Billable_First, StartTime_First, EndTime_First, ts_First);

                #endregion

                #region Second Record

                // Save it to the database
                long lngInsertedId_Second = _dal.WriteEntries_toDB(StartTime_Second, EndTime_Second, UserInput_Second, ts_Second, Billable_Second);

                // Add to grid
                AddToGrid(lngInsertedId_Second, UserInput_Second, Billable_Second, StartTime_Second, EndTime_Second, ts_Second);

                #endregion

                #region Refresh Data

                ClearDataGrid();
                LoadRecords();

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void CalculateTotals()
        {
            try
            {
                IEnumerable<Entry> entries = _dal.LoadEntries_fromDB();

                TimeSpan tsHours;
                TimeSpan tsHoursTotal = new TimeSpan();

                // Recalculate Total Hours
                foreach (Entry entry in entries)
                {
                    tsHours = entry.EndTime.Value - entry.StartTime.Value;
                    tsHours = tsHours.RoundToNearestMinutes(15);

                    tsHoursTotal = tsHoursTotal.Add(tsHours);
                }

                tsslTotal.Text = "Total: " + tsHoursTotal.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ClearDataGrid()
        {
            try
            {
                // Add to grid
                timetrackerDataSet.AcceptChanges();
                timetrackerDataSet.Tables[4].Clear();
                timetrackerDataSet.AcceptChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void PromptSplitEntry()
        {
            try
            {
                if(dgTimesheet.SelectedRows.Count > 0 || dgTimesheet.SelectedCells.Count > 0)
                {
                    // Get selected item
                    int selectedRowIndex = 0;
                    if (dgTimesheet.SelectedRows.Count > 0)
                    {
                        selectedRowIndex = dgTimesheet.SelectedRows[0].Index;
                    } 
                    else
                    {
                        selectedRowIndex = dgTimesheet.SelectedCells[0].RowIndex;
                    }

                    // Since the datagrid stores everything as text we need to covert it all back into proper types
                    int intEntryId = (int)timetrackerDataSet.Tables[4].Rows[selectedRowIndex]["id"];
                    String strUserInput = timetrackerDataSet.Tables[4].Rows[selectedRowIndex]["description"].ToString();
                    DateTime.TryParse(timetrackerDataSet.Tables[4].Rows[selectedRowIndex]["start_time"].ToString(), out DateTime dtStartTime);
                    DateTime.TryParse(timetrackerDataSet.Tables[4].Rows[selectedRowIndex]["end_time"].ToString(), out DateTime dtEndTime);
                    DateTime.TryParse(timetrackerDataSet.Tables[4].Rows[selectedRowIndex]["start_date"].ToString(), out DateTime dtStartDate);
                    DateTime.TryParse(timetrackerDataSet.Tables[4].Rows[selectedRowIndex]["end_date"].ToString(), out DateTime dtEndDate);
                    TimeSpan.TryParse(timetrackerDataSet.Tables[4].Rows[selectedRowIndex]["hours"].ToString(), out TimeSpan tsHours);
                    var billable = timetrackerDataSet.Tables[4].Rows[selectedRowIndex]["billable"];
                    
                    // Prepare Split Entry window
                    frmSplitEntry splitEntry = new frmSplitEntry
                    {
                        StartPosition = FormStartPosition.CenterParent,

                        UserInput_First = strUserInput,
                        Billable_First = (bool)billable,
                        StartTime_First = dtStartDate.Date.Add(dtStartTime.TimeOfDay),
                        EndTime_First = dtEndDate.Date.Add(dtEndTime.TimeOfDay),

                        UserInput_Second = strUserInput,
                        Billable_Second = (bool)billable,
                        StartTime_Second = dtStartDate.Date.Add(dtStartTime.TimeOfDay),
                        EndTime_Second = dtEndDate.Date.Add(dtEndTime.TimeOfDay)
                    };

                    splitEntry.ShowDialog();
                    
                    // After user has closed the dialog
                    switch (splitEntry.ButtonPressed)
                    {
                        case frmSplitEntry.eButtons.Ok:
                            if (splitEntry.SaveInput && !String.IsNullOrWhiteSpace(splitEntry.UserInput_First))
                            {
                                // Delete the row from the grid 
                                timetrackerDataSet.AcceptChanges();
                                timetrackerDataSet.Tables[4].Rows[selectedRowIndex].Delete();
                                timetrackerDataSet.AcceptChanges();

                                // Delete the row in the database
                                _dal.DeleteEntries_fromDB(intEntryId);

                                // Add the Split Records
                                SaveSplitTimeRecord(
                                    splitEntry.UserInput_First, splitEntry.Billable_First, splitEntry.StartTime_First, splitEntry.EndTime_First, splitEntry.Duration_First,
                                    splitEntry.UserInput_Second, splitEntry.Billable_Second, splitEntry.StartTime_Second, splitEntry.EndTime_Second, splitEntry.Duration_Second
                                );
                            }
                            break;

                        case frmSplitEntry.eButtons.Cancel:
                            _booInputActive = false;

                            break;
                    }

                }
                else
                {
                    MessageBox.Show("No Row Selected", "Please make sure to select a row or a cell.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool ResaveAllToDb()
        {
            try
            {
                bool booSuccess = true;

                // Clear it out first
                _dal.ClearDb("entries");

                // Go through all the table rows and save them to the database
                if (timetrackerDataSet.Tables[4].Rows.Count > 0)
                {
                    foreach (DataRow row in timetrackerDataSet.Tables[4].Rows)
                    {
                        if (row.RowState == DataRowState.Deleted) continue;

                        // Since the datagrid stores everything as text we need to covert it all back into proper types

                        // Todo: Add some debugging incase conversions fail
                        DateTime.TryParse(row["start_time"].ToString(), out DateTime dtStartTime);
                        DateTime.TryParse(row["end_time"].ToString(), out DateTime dtEndTime);
                        DateTime.TryParse(row["start_date"].ToString(), out DateTime dtStartDate);
                        DateTime.TryParse(row["end_date"].ToString(), out DateTime dtEndDate);
                        TimeSpan.TryParse(row["hours"].ToString(), out TimeSpan tsHours);
                        var billable = row["billable"];

                        long lngResult = _dal.WriteEntries_toDB(
                            dtStartDate.Date.Add(dtStartTime.TimeOfDay), 
                            dtEndDate.Date.Add(dtEndTime.TimeOfDay), 
                            row["description"].ToString(), 
                            tsHours, 
                            (bool)billable
                        );
                        if (lngResult < 1)
                        {
                            booSuccess = false;
                        }
                    }
                }

                CalculateTotals();

                return booSuccess;
            }
            catch (Exception)
            {
                throw;
            }
        }      

        private void PromptUser()
        {
            try
            {
                // Prepare Prompt window
                frmPrompt timePrompt = new frmPrompt
                {
                    UserInput = String.Empty,
                    Billable = _booBillable,
                    RunEndTimer = _booRunEndTimer,
                    StartTime = _dtStartTimer != null ? _dtStartTimer.Value : DateTime.Now,
                    EndTime = DateTime.Now,
                    StartPosition = FormStartPosition.WindowsDefaultLocation
                };

                // Show the Prompt, if it's not already showing
                if (!_booInputActive)
                {
                    _booInputActive = true;
                    PlayChime();
                    timePrompt.ShowDialog();
                }
                else
                {
                    return;
                }                

                switch (timePrompt.ButtonPressed)
                {
                    case frmPrompt.eButtons.Ok:
                        if(timePrompt.SaveInput && !String.IsNullOrWhiteSpace(timePrompt.UserInput))
                        {
                            AddTimeRecord(timePrompt.UserInput, timePrompt.Billable, timePrompt.StartTime, timePrompt.EndTime);
                            _booInputActive = false;
                            _dtStartTimer = timePrompt.EndTime;
                            _dtStartProgress = DateTime.Now;
                            _booBillable = timePrompt.Billable;
                        }
                        goto default;

                    case frmPrompt.eButtons.Skip:
                        _dtStartTimer = DateTime.Now;
                        _dtStartProgress = DateTime.Now;
                        _booInputActive = false;
                        goto default;

                    case frmPrompt.eButtons.Cancel:
                        _booInputActive = false;
                        tmrMain.Enabled = false;
                        tmrPrompt.Enabled = false;
                        tsProgressBar.Value = 0;
                        _dtStartTimer = null;
                        _dtStartProgress = null;
                        btnMultiButton.Text = "Start";
                        break;

                    default:
                        // Restart timer
                        tmrPrompt.Stop();
                        tmrPrompt.Start();
                        break;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void PlayChime(bool bBeep = false)
        {
            try
            {
                if (bBeep)
                {
                    // Beep
                    System.Media.SystemSounds.Beep.Play();
                }
                else
                {
                    // Wave File
                    System.Media.SoundPlayer sound = new System.Media.SoundPlayer(@"c:\Windows\Media\chimes.wav");
                    sound.Play();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Start()
        {
            try
            {
                tmrMain.Enabled = true;
                tmrPrompt.Enabled = true;
                _dtStartTimer = _dtStartProgress = DateTime.Now;
                _dtStartAbsolute = _dtStartAbsolute == null ? DateTime.Now : _dtStartAbsolute;
                btnMultiButton.Text = "Stop";

                PromptUser();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Resave()
        {
            try
            {
                if (ResaveAllToDb())
                {
                    MessageBox.Show("Datagrid successfully resaved to database!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error while resaving", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to resave records to database." + System.Environment.NewLine + ex.ToString(),
                    "Exception",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void Stop()
        {
            try
            {
                if (!tmrMain.Enabled && !tmrPrompt.Enabled) return;

                tmrMain.Enabled = false;
                tmrPrompt_Tick(this, new EventArgs()); // make a final log entry
                tmrPrompt.Enabled = false;
                tsProgressBar.Value = 0;
                _dtStartTimer = null;
                _dtStartProgress = null;
                btnMultiButton.Text = "Start";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Clear()
        {
            try
            {
                if (_dal.ClearDb("entries"))
                {
                    ClearDataGrid();
                    CalculateTotals();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error clearing the grid." + System.Environment.NewLine + ex.ToString(), "Exception",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Events

        private void dgTimesheet_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                dgTimesheet.ClearSelection();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void tmrMain_Tick(object sender, EventArgs e)
        {
            try
            {
                TimeSpan ts = _dtStartProgress != null ? (DateTime.Now - _dtStartProgress.Value) : new TimeSpan(0);
                int intSecondsElapsed = (int)ts.TotalSeconds; 
                int intSecondsLeft = (tmrPrompt.Interval / 1000) - intSecondsElapsed;

                lblNextEntryInValue.Text = String.Concat(intSecondsLeft.ToString(), " seconds");

                tsProgressBar.Minimum = 0;
                tsProgressBar.Maximum = (tmrPrompt.Interval / 1000);
                tsProgressBar.Value = intSecondsElapsed < tsProgressBar.Maximum ? intSecondsElapsed : tsProgressBar.Maximum;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tmrPrompt_Tick(object sender, EventArgs e)
        {
            try
            {
                PromptUser();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving record." + System.Environment.NewLine + ex.ToString(), "Exception", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
        }

        private void cboPromptEveryValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (cboPromptEveryValue.Text)
                {
                    case "5 minutes":
                        {
                            tmrPrompt.Interval = 300000;
                        }
                        break;
                    case "15 minutes":
                        {
                            tmrPrompt.Interval = 900000;
                        }
                        break;
                    case "30 minutes":
                        {
                            tmrPrompt.Interval = 1800000;
                        }
                        break;
                    case "60 minutes":
                    default:
                        {
                            tmrPrompt.Interval = 3600000;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            try
            {
                if (FormWindowState.Minimized == this.WindowState)
                {
                    notifyIcon.Visible = true;
                    this.Hide();
                }
                else if (FormWindowState.Normal == this.WindowState)
                {
                    notifyIcon.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (tmrMain.Enabled || tmrPrompt.Enabled)
                {
                    DialogResult dlgExit = MessageBox.Show("Timer is still running!  Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if(dlgExit == DialogResult.No)
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Notification Icon Events

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {            
            try
            {
                notifyIcon.Visible = false;
                this.WindowState = FormWindowState.Minimized;
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void btnMultiButton_Click(object sender, EventArgs e)
        {
            switch (btnMultiButton.Text)
            {
                case "Start":
                    {
                        Start();
                    }
                    break;
                case "Stop":
                    {
                        Stop();
                    }
                    break;
            }
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stop();
        }

        private void logNowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PromptUser();
        }

        #endregion

        #region Strip Menu Events

        private void toolStripMenuItem_Exit_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Resave();
        }

        private void toolStripMenuItem_Start_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void toolStripMenuItem_Stop_Click(object sender, EventArgs e)
        {
            Stop();
        }

        private void toolStripMenuItem_Clear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void toolStripMenuItem_LogNow_Click(object sender, EventArgs e)
        {
            PromptUser();
        }

        private void toolStripMenuItem_About_Click(object sender, EventArgs e)
        {
            try
            {
                frmAboutBox ab = new frmAboutBox();
                ab.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripMenuItem_Split_Click(object sender, EventArgs e)
        {
            try
            {
                PromptSplitEntry();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripMenuItem_Projects_Click(object sender, EventArgs e)
        {
            try
            {
                frmProjects proj = new frmProjects();
                proj.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void toolStripMenuItem_Clients_Click(object sender, EventArgs e)
        {
            try
            {
                frmClients clients = new frmClients();
                clients.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

    }

    #endregion
}
