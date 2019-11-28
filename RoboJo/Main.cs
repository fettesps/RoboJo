using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        private DateTime? _dtStartAbsolute;
        private bool _booInputActive = false;

        #region Functions

        public frmMain()
        {
            InitializeComponent();
            cboPromptEveryValue.SelectedIndex = 0; // todo : store default in config setting
            tmrMain.Interval = 1000; // this timer controls when the GUI is refreshed
            cboPromptEveryValue_SelectedIndexChanged(this, null);
            
            readFromDb();

            this.Text = Application.ProductName + " - v" + Application.ProductVersion;
        }

        private void AddDetails(String strDetails)
        {
            // Calculate hours, to nearest half hour
            DateTime dtStart = _dtStart != null ? _dtStart.Value : DateTime.Now;
            TimeSpan ts = _dtStart != null ? DateTime.Now - _dtStart.Value : new TimeSpan(0);
            TimeSpan tsHours = ts.RoundToNearestMinutes(15);

            // Add to grid
            timetrackerDataSet.AcceptChanges();

            DataRow dr = timetrackerDataSet.Tables[0].NewRow();
            dr["start_time"] = dtStart.ToShortTimeString();
            dr["end_time"] = DateTime.Now.ToShortTimeString();
            dr["description"] = strDetails;
            dr["hours"] = tsHours.ToString();
            dr["billable"] = 1;

            timetrackerDataSet.timesheet.AddtimesheetRow((timetrackerDataSet.timesheetRow)dr);
            timetrackerDataSet.AcceptChanges();

            // Add to Total 
            TimeSpan tsAbs = _dtStartAbsolute != null ? DateTime.Now - _dtStartAbsolute.Value : new TimeSpan(0);
            tsAbs = tsAbs.RoundToNearestMinutes(15);
            tsslTotal.Text = "Total: " + tsAbs.ToString();

            // Update Trackers
            lblLastEntryValue.Text = lblCurrentEntryValue.Text;
            lblCurrentEntryValue.Text = strDetails;
            tsslCurrentEntryVal.Text = strDetails;

            writeToDb(dtStart, DateTime.Now, strDetails, tsHours, true);
        }

        private void AddDetailsToGridView(String strDetails)
        {
            // Calculate hours, to nearest half hour
            DateTime dtStart = _dtStart != null ? _dtStart.Value : DateTime.Now;
            TimeSpan ts = _dtStart != null ? DateTime.Now - _dtStart.Value : new TimeSpan(0);
            TimeSpan tsHours = ts.RoundToNearestMinutes(15);

            // Add to grid
            timetrackerDataSet.AcceptChanges();

            DataRow dr = timetrackerDataSet.Tables[0].NewRow();
            dr["start_time"] = dtStart.ToShortTimeString();
            dr["end_time"] = DateTime.Now.ToShortTimeString();
            dr["description"] = strDetails;
            dr["hours"] = tsHours.ToString();
            dr["billable"] = 1;

            timetrackerDataSet.timesheet.AddtimesheetRow((timetrackerDataSet.timesheetRow)dr);
            timetrackerDataSet.AcceptChanges();
        }

        private bool writeToDb(DateTime? dtStart, DateTime? dtEnd, String strDescription, TimeSpan tsHours, bool booBillable)
        {
            String strInsertStatement = "INSERT INTO timesheet ([start_time],[end_time],[description],[billable],[hours]) VALUES (@start_time,@end_time,@description,@billable,@hours)";

            using (SqlConnection sqlCon = new SqlConnection(Properties.Settings.Default.timetrackerConnectionString))
            {
                sqlCon.Open();

                using (SqlCommand cmd = new SqlCommand(strInsertStatement, sqlCon))
                {
                    cmd.Parameters.Add("@start_time", SqlDbType.DateTime).Value = dtStart;
                    cmd.Parameters.Add("@end_time", SqlDbType.DateTime).Value = dtEnd;
                    cmd.Parameters.Add("@description", SqlDbType.NVarChar).Value = strDescription;
                    cmd.Parameters.Add("@billable", SqlDbType.Bit).Value = booBillable;
                    cmd.Parameters.Add("@hours", SqlDbType.NVarChar).Value = tsHours.ToString();

                    int intRowsInserted = cmd.ExecuteNonQuery();
                    if (intRowsInserted > 0) return true;
                }
            }

            return false;
        }

        private void readFromDb()
        {
            String strReadStatement = "SELECT [start_time],[end_time],[description],[billable],[hours] FROM timesheet";

            using (SqlConnection sqlCon = new SqlConnection(Properties.Settings.Default.timetrackerConnectionString))
            {
                sqlCon.Open();

                using (SqlCommand cmd = new SqlCommand(strReadStatement, sqlCon))
                {
                    SqlDataReader sqlDr = cmd.ExecuteReader();
                    while (sqlDr.Read())
                    {
                        timetrackerDataSet.AcceptChanges();

                        DataRow dr = timetrackerDataSet.Tables[0].NewRow();

                        dr["start_time"] = sqlDr.GetDateTime(sqlDr.GetOrdinal("start_time")).ToShortTimeString();
                        dr["end_time"] = sqlDr.GetDateTime(sqlDr.GetOrdinal("end_time")).ToShortTimeString();
                        dr["description"] = sqlDr["description"].ToString();
                        dr["hours"] = sqlDr["hours"].ToString();
                        dr["billable"] = sqlDr["billable"].ToString();

                        timetrackerDataSet.timesheet.AddtimesheetRow((timetrackerDataSet.timesheetRow)dr);
                        timetrackerDataSet.AcceptChanges();
                    }
                }
            }

        }

        private bool clearDb()
        {
            String strClearSql = "DELETE FROM timesheet WHERE 1=1";

            using (SqlConnection sqlCon = new SqlConnection(Properties.Settings.Default.timetrackerConnectionString))
            {
                sqlCon.Open();

                using (SqlCommand cmd = new SqlCommand(strClearSql, sqlCon))
                {
                    int intRowsInserted = cmd.ExecuteNonQuery();
                    if (intRowsInserted > 0) return true;
                }
            }

            return false;
        }


        private void Record(String strMessage = "What have you been working on?")
        {
            String strInput = Microsoft.VisualBasic.Interaction.InputBox(strMessage, "Time Entry", "Default", 0, 0);
            _booInputActive = true;

            if (!String.IsNullOrWhiteSpace(strInput))
            {
                _booInputActive = false;
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
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            _dtStart = DateTime.Now;
            _dtStartAbsolute = _dtStartAbsolute == null ? DateTime.Now : _dtStartAbsolute;

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
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            tsProgressBar.Value = 0;
            _dtStart = null;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            bool cleared = clearDb();

            dgTimesheet.DataSource = dgTimesheet.DataSource;
            dgTimesheet.Refresh();
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
