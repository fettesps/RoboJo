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
    public partial class frmProjects : Form
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

        public frmProjects()
        {
            InitializeComponent();
        }

        private void frmProjects_Shown(object sender, EventArgs e)
        {
            _booIsLoaded = true;
        }

        #region Controls 

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                txtProjectID.Text = "";
                txtWeight.Text = "";
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
                _booIsLocked = false;
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
                return txtProjectID.Text;
            }
            set 
            {
                txtProjectID.Text = value; 
            }
        }

        #endregion
    }
}
