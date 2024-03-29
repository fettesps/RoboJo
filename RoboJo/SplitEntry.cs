﻿using System;
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
    public partial class frmSplitEntry : Form
    {
        public enum eButtons
        {
            Cancel,
            Ok
        }
        bool _booSaveInput = false;
        bool _booIsLoaded = false;
        bool _booIsLocked = false;
        eButtons _ButtonPressed;

        public frmSplitEntry()
        {
            InitializeComponent();
        }

        private void frmSplitEntry_Shown(object sender, EventArgs e)
        {
            UpdateHours();
            _booIsLoaded = true;
        }

        #region Controls 


        private void txtUserInput_Second_KeyDown(object sender, KeyEventArgs e)
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


        private void dtpEndTime_First_KeyDown(object sender, KeyEventArgs e)
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

        private void dtpStartTime_First_KeyDown(object sender, KeyEventArgs e)
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

        private void dtpStartTime_Second_KeyDown(object sender, KeyEventArgs e)
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

        private void dtpEndTime_Second_KeyDown(object sender, KeyEventArgs e)
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                txtUserInput_First.Text = "";
                txtDuration_First.Text = "00:00:00";
                _booSaveInput = false;
                _ButtonPressed = eButtons.Cancel;
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

        private void dtpStartTime_First_KeyUp(object sender, EventArgs e)
        {
            try
            {
                UpdateHours();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void dtpStartTime_Second_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!_booIsLoaded || _booIsLocked) return;

                _booIsLocked = true;
                dtpEndTime_First.Value = dtpStartTime_Second.Value;
                _booIsLocked = false;
                UpdateHours();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void dtpEndTime_First_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!_booIsLoaded || _booIsLocked) return;

                _booIsLocked = true;
                dtpStartTime_Second.Value = dtpEndTime_First.Value;
                _booIsLocked = false;
                UpdateHours();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void dtpEndTime_Second_KeyUp(object sender, EventArgs e)
        {
            try
            {
                UpdateHours();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void UpdateHours()
        {
            try
            {
                // Calculate hours, to nearest half hour
                TimeSpan ts = dtpEndTime_First.Value - dtpStartTime_First.Value;
                TimeSpan tsHours = ts.RoundToNearestMinutes(15);
                txtDuration_First.Text = tsHours.ToString();

                TimeSpan ts2 = dtpEndTime_Second.Value - dtpStartTime_Second.Value;
                TimeSpan tsHours2 = ts2.RoundToNearestMinutes(15);
                txtDuration_Second.Text = tsHours2.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Getter and Setters

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

        public string UserInput_First
        {
            get
            {
                return txtUserInput_First.Text;
            }
            set
            {
                txtUserInput_First.Text = value;
            }
        }

        public TimeSpan Duration_First
        {
            get
            {
                TimeSpan ts = dtpStartTime_First != null ? dtpEndTime_First.Value - dtpStartTime_First.Value : new TimeSpan(0);
                TimeSpan tsHours = ts.RoundToNearestMinutes(15);

                return tsHours;
            }
        }

        public DateTime StartTime_First
        {
            get
            {
                return dtpStartTime_First.Value;
            }
            set
            {
                dtpStartTime_First.Value = value;
            }
        }

        public DateTime EndTime_First
        {
            get
            {
                return dtpEndTime_First.Value;
            }
            set
            {
                dtpEndTime_First.Value = value;
            }
        }

        public bool Billable_First
        {
            get
            {
                return chkBillable_First.Checked;
            }
            set
            {
                chkBillable_First.Checked = value;
            }
        }

        public string UserInput_Second
        {
            get
            {
                return txtUserInput_Second.Text;
            }
            set
            {
                txtUserInput_Second.Text = value;
            }
        }

        public TimeSpan Duration_Second
        {
            get
            {
                TimeSpan ts = dtpStartTime_Second != null ? dtpEndTime_Second.Value - dtpStartTime_Second.Value : new TimeSpan(0);
                TimeSpan tsHours = ts.RoundToNearestMinutes(15);

                return tsHours;
            }
        }

        public DateTime StartTime_Second
        {
            get
            {
                return dtpStartTime_Second.Value;
            }
            set
            {
                dtpStartTime_Second.Value = value;
            }
        }

        public DateTime EndTime_Second
        {
            get
            {
                return dtpEndTime_Second.Value;
            }
            set
            {
                dtpEndTime_Second.Value = value;
            }
        }

        public bool Billable_Second
        {
            get
            {
                return chkBillable_Second.Checked;
            }
            set
            {
                chkBillable_Second.Checked = value;
            }
        }

        #endregion

    }
}
