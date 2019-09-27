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
            tmrPrompt.Interval = 1800000; // minutes * 60 (seconds) * 1000 (milliseconds);
        }

        
        private void AddDetails(String strDetails)
        {
            // Calculate hours, to nearest half hour
            TimeSpan ts = _dtStart != null ? DateTime.Now - _dtStart.Value : new TimeSpan(0);
            //double dblMinutesElapsed = ts.TotalHours; 
            //double dblHours = Math.Round(dblMinutesElapsed * 4, MidpointRounding.ToEven) / 4;
            var test = ts.RoundToNearestMinutes(15);

            // Add to grid
            dgTimesheet.Rows.Add(
                new object[]
                {
                    test,
                    _dtStart.Value.ToShortTimeString(),
                    DateTime.Now.ToShortTimeString(),
                    strDetails
                }
            );

            //timetrackerDataSet. = dgTimesheet;

        }

        #region Events

        private void btnStartOrEnd_Click(object sender, EventArgs e)
        {
            switch(btnStartOrEnd.Text)
            {
                case "Start":
                    {
                        btnStartOrEnd.Text = "End";
                        tmrMain.Enabled = true;
                        tmrPrompt.Enabled = true;
                        _dtStart = DateTime.Now;
                    }
                    break;
                case "End":
                default:
                    {
                        btnStartOrEnd.Text = "Start";
                        tmrMain.Enabled = false;
                        tmrPrompt_Tick(this, new EventArgs()); // make a final log entry
                        tmrPrompt.Enabled = false;
                        _dtStart = null;
                    } break;
            }
            
        }

        private void tmrMain_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = _dtStart != null ? DateTime.Now - _dtStart.Value : new TimeSpan(0);
            int intSecondsElapsed = (int)ts.TotalSeconds; // todo: fix this lazy cast
            int intSecondsLeft = (tmrPrompt.Interval / 10000) - intSecondsElapsed;
            lblNextEntryInValue.Text = String.Concat(intSecondsLeft.ToString(), " seconds");
        }


        private void tmrPrompt_Tick(object sender, EventArgs e)
        {
            String strInput = Microsoft.VisualBasic.Interaction.InputBox("What have you been working on?", "Time Entry", "Default", 0, 0);

            if (!String.IsNullOrWhiteSpace(strInput))
            {
                AddDetails(strInput);
            }

            // Debug
            //Microsoft.VisualBasic.Interaction.MsgBox("You entered: " + strInput, Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Result");
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

        #region Helpers


        #endregion

    }
}
