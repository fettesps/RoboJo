using RoboJo.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace RoboJo
{
    public partial class frmTasks : Form
    {
        private IDAL _dal;

        public frmTasks()
        {
            InitializeComponent();
            _dal = Factory.OpenDB();
            LoadRecords();
        }

        #region Controls 

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                txtTaskID.Text = "";
                txtTaskName.Text = "";
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
                // Estimate the next Insert ID
                IEnumerable<Task> tasks = _dal.LoadTasks();
                tasks = tasks.OrderBy(c => c.Task_ID);
                int nextId = tasks.LastOrDefault()?.Task_ID ?? 0;
                nextId++;

                txtTaskID.Text = nextId.ToString();
                txtTaskName.Text = "";
                txtTaskName.Enabled = true;
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
                if (!String.IsNullOrEmpty(txtTaskName.Text))
                {
                    tasksDataSet.AcceptChanges();

                    _dal.WriteTask(txtTaskName.Text);

                    DataRow dr = tasksDataSet.Tables[3].NewRow();

                    dr["task_id"] = txtTaskID.Text;
                    dr["name"] = txtTaskName.Text;

                    tasksDataSet.tasks.AddtasksRow((timetrackerDataSet.tasksRow)dr);

                    btnSave.Enabled = false;
                    txtTaskName.Enabled = false;

                    tasksDataSet.AcceptChanges();
                }
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
                if (dgTasks.SelectedRows.Count > 0 || dgTasks.SelectedCells.Count > 0)
                {
                    // Get selected item
                    int selectedRowIndex = 0;
                    if (dgTasks.SelectedRows.Count > 0)
                    {
                        selectedRowIndex = dgTasks.SelectedRows[0].Index;
                    }
                    else
                    {
                        selectedRowIndex = dgTasks.SelectedCells[0].RowIndex;
                    }

                    dgTasks.Rows[selectedRowIndex].Selected = false;
                    if (selectedRowIndex > 0) selectedRowIndex--;
                    dgTasks.Rows[selectedRowIndex].Selected = true;

                    txtTaskID.Text = dgTasks.Rows[selectedRowIndex].Cells[0].Value.ToString();
                    txtTaskName.Text = dgTasks.Rows[selectedRowIndex].Cells[1].Value.ToString();
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
                if (dgTasks.SelectedRows.Count > 0 || dgTasks.SelectedCells.Count > 0)
                {
                    // Get selected item
                    int selectedRowIndex = 0;
                    if (dgTasks.SelectedRows.Count > 0)
                    {
                        selectedRowIndex = dgTasks.SelectedRows[0].Index;
                    }
                    else
                    {
                        selectedRowIndex = dgTasks.SelectedCells[0].RowIndex;
                    }

                    dgTasks.Rows[selectedRowIndex].Selected = false;
                    if (selectedRowIndex < (dgTasks.Rows.Count - 1)) selectedRowIndex++;
                    dgTasks.Rows[selectedRowIndex].Selected = true;

                    txtTaskID.Text = dgTasks.Rows[selectedRowIndex].Cells[0].Value.ToString();
                    txtTaskName.Text = dgTasks.Rows[selectedRowIndex].Cells[1].Value.ToString();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void dgTasks_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                if (dgTasks.SelectedRows.Count > 0 || dgTasks.SelectedCells.Count > 0)
                {
                    // Get selected item
                    int selectedRowIndex = 0;
                    if (dgTasks.SelectedRows.Count > 0)
                    {
                        selectedRowIndex = dgTasks.SelectedRows[0].Index;
                    }
                    else
                    {
                        selectedRowIndex = dgTasks.SelectedCells[0].RowIndex;
                    }

                    var task_id = dgTasks.Rows[selectedRowIndex].Cells[0].Value;

                    _dal.DeleteTasks((int)task_id);
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
                IEnumerable<Task> tasks = _dal.LoadTasks();
                tasks = tasks.OrderBy(c => c.Task_ID);

                // Add to Grid
                foreach (Task task in tasks)
                {
                    tasksDataSet.AcceptChanges();

                    DataRow dr = tasksDataSet.Tables[3].NewRow();

                    dr["task_id"] = task.Task_ID;
                    dr["name"] = task.Name;

                    tasksDataSet.tasks.AddtasksRow((timetrackerDataSet.tasksRow)dr);
                    tasksDataSet.AcceptChanges();
                }

                // Load last entry
                txtTaskID.Text = tasks.FirstOrDefault()?.Task_ID.ToString();
                txtTaskName.Text = tasks.FirstOrDefault()?.Name;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
