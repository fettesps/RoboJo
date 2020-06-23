﻿using RoboJo.Entities;
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
        private DateTime? _dtStart;
        private DateTime? _dtStartAbsolute;
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
                cboPromptEveryValue.SelectedIndex = 0; 
                tmrMain.Interval = 1000; 
                cboPromptEveryValue_SelectedIndexChanged(this, null);
                lblDate_Value.Text = System.DateTime.Now.ToShortDateString();

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
                TimeSpan tsAbs = _dtStartAbsolute != null ? dtEnd.Value - _dtStartAbsolute.Value : new TimeSpan(0);
                tsAbs = tsAbs.RoundToNearestMinutes(15);
                tsslTotal.Text = "Total: " + tsAbs.ToString();

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

        private void PromptUser(String strMessage = "What have you been working on?")
        {
            try
            {
                // Prepare Prompt window
                Prompt timePrompt = new Prompt
                {
                    UserInput = String.Empty,
                    Billable = _booBillable,
                    RunEndTimer = _booRunEndTimer,
                    StartTime = _dtStart != null ? _dtStart.Value : DateTime.Now,
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

                // If there was user input, save it
                if (!String.IsNullOrWhiteSpace(timePrompt.UserInput))
                {
                    AddTimeRecord(timePrompt.UserInput, timePrompt.Billable, timePrompt.StartTime, timePrompt.EndTime);
                    _booInputActive = false;
                    _dtStart = DateTime.Now;
                    _booBillable = timePrompt.Billable;
                }
                // User canceled action
                else
                {
                    _booInputActive = false;
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

        #endregion

        #region Events

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                tmrMain.Enabled = true;
                tmrPrompt.Enabled = true;
                btnStart.Enabled = false;
                btnStop.Enabled = true;
                _dtStart = DateTime.Now;
                _dtStartAbsolute = _dtStartAbsolute == null ? DateTime.Now : _dtStartAbsolute;

                PromptUser("What will you be working on?");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogNow_Click(object sender, EventArgs e)
        {
            try
            {
                tmrPrompt_Tick(this, new EventArgs());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                tmrMain.Enabled = false;
                tmrPrompt_Tick(this, new EventArgs()); // make a final log entry
                tmrPrompt.Enabled = false;
                btnStart.Enabled = true;
                btnStop.Enabled = false;
                tsProgressBar.Value = 0;
                _dtStart = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
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

        private void tmrMain_Tick(object sender, EventArgs e)
        {
            try
            {
                TimeSpan ts = _dtStart != null ? (DateTime.Now - _dtStart.Value) : new TimeSpan(0);
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

        private void btnResave_Click(object sender, EventArgs e)
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
            try
            {
                btnResave_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripMenuItem_Start_Click(object sender, EventArgs e)
        {
            try
            {
                btnStart_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripMenuItem_Stop_Click(object sender, EventArgs e)
        {
            try
            {
                btnStop_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripMenuItem_Clear_Click(object sender, EventArgs e)
        {
            try
            {
                btnClear_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripMenuItem_LogNow_Click(object sender, EventArgs e)
        {
            try
            {
                btnLogNow_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripMenuItem_About_Click(object sender, EventArgs e)
        {
            try
            {
                AboutBox ab = new AboutBox();
                ab.ShowDialog();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }

    #endregion
}
