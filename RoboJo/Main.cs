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

        public frmMain()
        {
            InitializeComponent();
            cboPromptEveryValue.SelectedIndex = 0; // todo : store default in config setting
            tmrMain.Interval = 1000; // this timer controls when the GUI is refreshed

            //tmrPrompt.Interval = 1800000; // minutes * 60 (seconds) * 1000 (milliseconds);
            cboPromptEveryValue_SelectedIndexChanged(this, null);

            this.Text = Application.ProductName + " - v" + Application.ProductVersion;
        }

        
        private void AddDetails(String strDetails)
        {
            // Calculate hours, to nearest half hour
            TimeSpan ts = _dtStart != null ? DateTime.Now - _dtStart.Value : new TimeSpan(0);
            TimeSpan tsHours = ts.RoundToNearestMinutes(15);

            // Add to grid
            dgTimesheet.Rows.Add(
                new object[]
                {
                    tsHours,
                    _dtStart != null ? _dtStart.Value.ToShortTimeString() : DateTime.Now.ToShortTimeString(),
                    DateTime.Now.ToShortTimeString(),
                    strDetails
                }
            );

            lblLastEntryValue.Text = lblCurrentEntryValue.Text;
            lblCurrentEntryValue.Text = strDetails;
        }

        #region Events

        private void btnStartOrEnd_Click(object sender, EventArgs e)
        {

            tmrMain.Enabled = true;
            tmrPrompt.Enabled = true;
            _dtStart = DateTime.Now;
            btnStartOrEnd.Enabled = false;
            btnStop.Enabled = true;
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
            btnStartOrEnd.Enabled = true;
            btnStop.Enabled = false;
        }

        private void tmrMain_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = _dtStart != null ? (DateTime.Now - _dtStart.Value) : new TimeSpan(0);
            int intSecondsElapsed = (int)ts.TotalSeconds; // todo: fix this lazy cast
            int intSecondsLeft = (tmrPrompt.Interval / 1000) - intSecondsElapsed;
            lblNextEntryInValue.Text = String.Concat(intSecondsLeft.ToString(), " seconds");
        }


        private void tmrPrompt_Tick(object sender, EventArgs e)
        {
            String strInput = Microsoft.VisualBasic.Interaction.InputBox("What have you been working on?", "Time Entry", "Default", 0, 0);

            if (!String.IsNullOrWhiteSpace(strInput))
            {
                AddDetails(strInput);
                _dtStart = DateTime.Now;
            }
        }

        private void cboPromptEveryValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(cboPromptEveryValue.Text)
            {
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
                notifyIcon.ShowBalloonTip(500);
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
