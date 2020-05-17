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
    public partial class Prompt : Form
    {
        public Prompt()
        {
            InitializeComponent();
        }

        #region Controls 

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                txtUserInput.Text = "";
                txtDuration.Text = "00:00:00";
                this.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void tmrPromptTicker_Tick(object sender, EventArgs e)
        {
            try
            {
                // Calculate hours, to nearest half hour
                TimeSpan ts = dtpStartTime != null ? DateTime.Now - dtpStartTime.Value : new TimeSpan(0);
                TimeSpan tsHours = ts.RoundToNearestMinutes(15);
                txtDuration.Text = tsHours.ToString();

                dtpEndTime.Value = DateTime.Now;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void txtUserInput_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnOk_Click(sender, e);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region Getter and Setters

        public string UserInput
        {
            get 
            {
                return txtUserInput.Text;
            }
            set 
            {
                txtUserInput.Text = value; 
            }
        }

        public DateTime StartTime
        {
            get
            {
                return dtpStartTime.Value;
            }
            set
            {
                dtpStartTime.Value = value;
            }
        }

        public DateTime EndTime
        {
            get
            {
                return dtpEndTime.Value;
            }
            set
            {
                dtpEndTime.Value = value;
            }
        }

        public bool Billable
        {
            get
            {
                return chkBillable.Checked;
            }
            set
            {
                chkBillable.Checked = value;
            }
        }

        #endregion
    }
}
