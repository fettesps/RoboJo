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
    public partial class frmPrompt : Form
    {
        public enum eButtons
        {
            Cancel,
            Skip,
            Ok
        }
        bool _booSaveInput = false;
        eButtons _ButtonPressed;
        private IDAL _dal;

        public frmPrompt()
        {
            _dal = Factory.OpenDB();
            InitializeComponent();
            BindControls();
        }

        private void BindControls()
        {
            try
            {
                cboClient.DataSource = _dal.LoadClients().ToList();
                cboClient.ValueMember = "client_id";
                cboClient.DisplayMember = "name";
                cboClient.SelectedValue = -1;

                cboProject.DataSource = _dal.LoadProjects().ToList();
                cboProject.ValueMember = "project_id";
                cboProject.DisplayMember = "name";
                cboProject.SelectedValue = -1;

                cboTasks.DataSource = _dal.LoadTasks().ToList();
                cboTasks.ValueMember = "task_id";
                cboTasks.DisplayMember = "Name";
                cboTasks.SelectedValue = -1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region Controls 

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                txtUserInput.Text = "";
                txtDuration.Text = "00:00:00";
                _booSaveInput = false;
                _ButtonPressed = eButtons.Cancel;
                this.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            try
            {
                _booSaveInput = false;
                _ButtonPressed = eButtons.Skip;
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
                _booSaveInput = true;
                _ButtonPressed = eButtons.Ok;
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
                TimeSpan ts = dtpStartTime != null ? dtpEndTime.Value - dtpStartTime.Value : new TimeSpan(0);
                TimeSpan tsHours = ts.RoundToNearestMinutes(15);
                txtDuration.Text = tsHours.ToString();

                if(chkRunEndTimer.Checked) dtpEndTime.Value = DateTime.Now;
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

        private void dtpEndTime_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                chkRunEndTimer.Checked = false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void dtpEndTime_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                chkRunEndTimer.Checked = false;
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

        public bool SaveInput
        {
            get
            {
                return _booSaveInput;
            }
        }

        public eButtons ButtonPressed
        {
            get
            {
                return _ButtonPressed;
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

        public bool RunEndTimer
        {
            get
            {
                return chkRunEndTimer.Checked;
            }
            set
            {
                chkRunEndTimer.Checked = value;
            }
        }

        public String Project
        {
            get
            {
                return cboProject.SelectedValue.ToString();
            }
        }

        public String Client
        {
            get
            {
                return cboClient.SelectedValue.ToString();
            }
        }

        public String Task
        {
            get
            {
                return cboTasks.SelectedValue.ToString();
            }
        }

        #endregion
    }
}
