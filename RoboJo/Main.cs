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
                IEnumerable<Entry> entries =_dal.ReadFromDb();

                foreach(Entry entry in entries)
                {
                    timetrackerDataSet.AcceptChanges();

                    DataRow dr = timetrackerDataSet.Tables[0].NewRow();

                    dr["start_time"] = entry.StartTime.Value.ToShortTimeString();
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
                CalculateTotal(_dtStartTimer, _dtEndTimer);
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

                // Add to grid
                timetrackerDataSet.AcceptChanges();

                DataRow dr = timetrackerDataSet.Tables[0].NewRow();

                dr["start_time"] = dtStart.Value.ToShortTimeString();
                dr["end_time"] = dtEnd.Value.ToShortTimeString();
                dr["description"] = strDetails;
                dr["hours"] = tsHours.ToString();
                dr["billable"] = booBillable ? 1 : 0;

                timetrackerDataSet.timesheet.AddtimesheetRow((timetrackerDataSet.timesheetRow)dr);
                timetrackerDataSet.AcceptChanges();

                // Add to Total 
                CalculateTotal(_dtStartAbsolute, dtEnd);

                // Update Trackers
                lblLastEntryValue.Text = lblCurrentEntryValue.Text;
                lblCurrentEntryValue.Text = strDetails;
                tsslCurrentEntryVal.Text = strDetails;

                // Save it to the database
                _dal.WriteToDb(dtStart, DateTime.Now, strDetails, tsHours, true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void CalculateTotal(DateTime? dtStart, DateTime? dtEnd)
        {
            try
            {
                // Recalculate Total Hours
                TimeSpan tsAbs = dtStart != null ? dtEnd.Value - dtStart.Value : new TimeSpan(0);
                tsAbs = tsAbs.RoundToNearestMinutes(15);

                tsslTotal.Text = "Total: " + tsAbs.ToString();
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
                timetrackerDataSet.Tables[0].Clear();
                timetrackerDataSet.AcceptChanges();
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
                bool booSuccess = false;

                // Clear it out first
                _dal.ClearDb();

                // Go through all the table rows and save them to the database
                foreach (DataRow row in timetrackerDataSet.Tables[0].Rows)
                {
                    // Since the datagrid stores everything as text we need to covert it all back into proper types
                    DateTime dtOut, dtStartTime, dtEndTime;

                    // Todo: Add some debugging incase conversions fail
                    DateTime.TryParse(row["start_time"].ToString(), out dtOut);
                    dtStartTime = dtOut;

                    DateTime.TryParse(row["end_time"].ToString(), out dtOut);
                    dtEndTime = dtOut;

                    TimeSpan tsHours;
                    TimeSpan.TryParse(row["hours"].ToString(), out tsHours);

                    var billable = row["billable"];

                    if (_dal.WriteToDb(dtStartTime, dtEndTime, row["description"].ToString(), tsHours, (bool)billable))
                    {
                        booSuccess = true;
                    }
                }

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
                Prompt timePrompt = new Prompt
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
                    case Prompt.eButtons.Ok:
                        if(timePrompt.SaveInput && !String.IsNullOrWhiteSpace(timePrompt.UserInput))
                        {
                            AddTimeRecord(timePrompt.UserInput, timePrompt.Billable, timePrompt.StartTime, timePrompt.EndTime);
                            _booInputActive = false;
                            _dtStartTimer = DateTime.Now;
                            _dtStartProgress = DateTime.Now;
                            _booBillable = timePrompt.Billable;
                        }
                        goto default;

                    case Prompt.eButtons.Skip:
                        _dtStartTimer = DateTime.Now;
                        _dtStartProgress = DateTime.Now;
                        _booInputActive = false;
                        goto default;

                    case Prompt.eButtons.Cancel:
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
                if (_dal.ClearDb())
                {
                    ClearDataGrid();
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
                AboutBox ab = new AboutBox();
                ab.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMultiButton_Click(object sender, EventArgs e)
        {
            switch (btnMultiButton.Text)
            {
                case "Start":
                    {
                        Start();
                    } break;
                case "Stop":
                    {
                        Stop();
                    } break;
            }
        }

        #endregion
    }

    #endregion
}
