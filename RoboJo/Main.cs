using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoboJo
{
    public partial class frmMain : Form
    {
        private DateTime? _dtStart;

        #region Functions

        public frmMain()
        {
            InitializeComponent();
            cboPromptEveryValue.SelectedIndex = 0; // todo : store default in config setting
            tmrMain.Interval = 1000; // this timer controls when the GUI is refreshed
            cboPromptEveryValue_SelectedIndexChanged(this, null);

            this.Text = Application.ProductName + " - v" + Application.ProductVersion;
        }

        private void AddDetails(String strDetails)
        {
            // Calculate hours, to nearest half hour
            TimeSpan ts = _dtStart != null ? DateTime.Now - _dtStart.Value : new TimeSpan(0);
            TimeSpan tsHours = ts.RoundToNearestMinutes(15);

            // Add to grid
            //timetrackerDataSet.timesheet.AddtimesheetRow(x);
            timetrackerDataSet.AcceptChanges();

            DataRow dr = timetrackerDataSet.Tables[0].NewRow();
            dr["start_time"] = _dtStart != null ? _dtStart.Value.ToShortTimeString() : DateTime.Now.ToShortTimeString();
            dr["end_time"] = DateTime.Now.ToShortTimeString();
            dr["description"] = strDetails;
            dr["hours"] = tsHours.ToString();
            dr["billable"] = 1;

            //timetrackerDataSet.Tables[0].Rows.Add(dr);
            //timetrackerDataSet.Tables[0].AcceptChanges();
            //timetrackerDataSet.AcceptChanges();
            //timesheetBindingSource.;

            timetrackerDataSet.timesheet.AddtimesheetRow((timetrackerDataSet.timesheetRow)dr);
            timetrackerDataSet.AcceptChanges();

            // Update Trackers
            lblLastEntryValue.Text = lblCurrentEntryValue.Text;
            lblCurrentEntryValue.Text = strDetails;
            tsslCurrentEntryVal.Text = strDetails;
        }

        private void Record(String strMessage = "What have you been working on?")
        {
            String strInput = Microsoft.VisualBasic.Interaction.InputBox(strMessage, "Time Entry", "Default", 0, 0);

            if (!String.IsNullOrWhiteSpace(strInput))
            {
                AddDetails(strInput);
                _dtStart = DateTime.Now;
            }
        }

        #endregion

        #region Events

        private void btnStart_Click(object sender, EventArgs e)
        {
            tmrMain.Enabled = true;
            tmrPrompt.Enabled = true;
            _dtStart = DateTime.Now;
            btnStart.Enabled = false;
            btnStop.Enabled = true;

            Record("What will you be working on?");
        }

        private void btnLogNow_Click(object sender, EventArgs e)
        {
            tmrPrompt_Tick(this, new EventArgs()); // make a final log entry
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            tmrMain.Enabled = false;
            tmrPrompt_Tick(this, new EventArgs()); // make a final log entry
            tmrPrompt.Enabled = false;
            _dtStart = null;
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            tsProgressBar.Value = 0;
        }

        private void tmrMain_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = _dtStart != null ? (DateTime.Now - _dtStart.Value) : new TimeSpan(0);
            int intSecondsElapsed = (int)ts.TotalSeconds; // todo: fix this lazy cast
            int intSecondsLeft = (tmrPrompt.Interval / 1000) - intSecondsElapsed;

            lblNextEntryInValue.Text = String.Concat(intSecondsLeft.ToString(), " seconds");

            tsProgressBar.Minimum = 0;
            tsProgressBar.Maximum = (tmrPrompt.Interval / 1000);
            tsProgressBar.Value = intSecondsElapsed < tsProgressBar.Maximum ? intSecondsElapsed : tsProgressBar.Maximum;
        }

        private void tmrPrompt_Tick(object sender, EventArgs e)
        {
            Record();
        }

        private void cboPromptEveryValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(cboPromptEveryValue.Text)
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

        private void frmMain_Resize(object sender, EventArgs e)
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


        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;
            this.WindowState = FormWindowState.Minimized;
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        #endregion
    }
}
