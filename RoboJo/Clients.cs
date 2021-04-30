﻿using RoboJo.Entities;
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
    public partial class frmClients : Form
    {
        private IDAL _dal;

        public frmClients()
        {
            InitializeComponent();
            _dal = Factory.OpenDB();
            LoadRecords();
        }

        private void frmClients_Shown(object sender, EventArgs e)
        {

        }

        #region Controls 

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                txtClient_ID.Text = "";
                txtClientName.Text = "";
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                txtClient_ID.Text = "";
                txtClientName.Text = "";
                btnSave.Enabled = true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                clientsDataSet.AcceptChanges();

                _dal.WriteClient_toDB(txtClientName.Text);

                DataRow dr = clientsDataSet.Tables[0].NewRow();

                dr["client_id"] = "0";
                dr["name"] = txtClientName.Text;

                clientsDataSet.clients.AddClientsRow((timetrackerDataSet.clientsRow)dr);

                btnSave.Enabled = false;
                clientsDataSet.AcceptChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }


        private void btnPrev_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgClients.SelectedRows.Count > 0 || dgClients.SelectedCells.Count > 0)
                {
                    // Get selected item
                    int selectedRowIndex = 0;
                    if (dgClients.SelectedRows.Count > 0)
                    {
                        selectedRowIndex = dgClients.SelectedRows[0].Index;
                    }
                    else
                    {
                        selectedRowIndex = dgClients.SelectedCells[0].RowIndex;
                    }

                    dgClients.Rows[selectedRowIndex].Selected = false;
                    if(selectedRowIndex > 0) selectedRowIndex--;
                    dgClients.Rows[selectedRowIndex].Selected = true;

                    txtClient_ID.Text = dgClients.Rows[selectedRowIndex].Cells[0].Value.ToString();
                    txtClientName.Text = dgClients.Rows[selectedRowIndex].Cells[1].Value.ToString();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgClients.SelectedRows.Count > 0 || dgClients.SelectedCells.Count > 0)
                {
                    // Get selected item
                    int selectedRowIndex = 0;
                    if (dgClients.SelectedRows.Count > 0)
                    {
                        selectedRowIndex = dgClients.SelectedRows[0].Index;
                    }
                    else
                    {
                        selectedRowIndex = dgClients.SelectedCells[0].RowIndex;
                    }

                    dgClients.Rows[selectedRowIndex].Selected = false;
                    if (selectedRowIndex < (dgClients.Rows.Count - 1)) selectedRowIndex++;
                    dgClients.Rows[selectedRowIndex].Selected = true;

                    txtClient_ID.Text = dgClients.Rows[selectedRowIndex].Cells[0].Value.ToString();
                    txtClientName.Text = dgClients.Rows[selectedRowIndex].Cells[1].Value.ToString();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void dgClients_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                if (dgClients.SelectedRows.Count > 0 || dgClients.SelectedCells.Count > 0)
                {
                    // Get selected item
                    int selectedRowIndex = 0;
                    if (dgClients.SelectedRows.Count > 0)
                    {
                        selectedRowIndex = dgClients.SelectedRows[0].Index;
                    }
                    else
                    {
                        selectedRowIndex = dgClients.SelectedCells[0].RowIndex;
                    }

                    var client_id = dgClients.Rows[selectedRowIndex].Cells[0].Value;

                    _dal.DeleteClient_fromDB((int)client_id);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region Data

        private void LoadRecords()
        {
            try
            {
                // Get Records
                IEnumerable<Client> clients = _dal.LoadClients_fromDB();
                clients = clients.OrderBy(c => c.Client_ID);

                // Add to Grid
                foreach (Client client in clients)
                {
                    clientsDataSet.AcceptChanges();

                    DataRow dr = clientsDataSet.Tables[0].NewRow();

                    dr["client_id"] = client.Client_ID;
                    dr["name"] = client.Name;

                    clientsDataSet.clients.AddClientsRow((timetrackerDataSet.clientsRow)dr);
                    clientsDataSet.AcceptChanges();
                }

                // Load last entry
                txtClient_ID.Text = clients.FirstOrDefault()?.Client_ID.ToString();
                txtClientName.Text = clients.FirstOrDefault()?.Name;
            }
            catch (Exception)
            {
                throw;
            }        
        }

        #endregion

    }
}
