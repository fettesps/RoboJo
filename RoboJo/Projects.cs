using RoboJo.Entities;
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
        private IDAL _dal;

        public frmProjects()
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
                txtProjectID.Text = "";
                txtProjectName.Text = "";
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
                IEnumerable<Project> projects = _dal.LoadProjects_fromDB();
                projects = projects.OrderBy(c => c.Project_ID);
                int nextId = projects.LastOrDefault()?.Project_ID ?? 0;
                nextId++;

                txtProjectID.Text = nextId.ToString();
                txtProjectName.Text = "";
                txtProjectName.Enabled = true;
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
                if (!String.IsNullOrEmpty(txtProjectName.Text))
                {
                    projectsDataSet.AcceptChanges();

                    _dal.WriteProject_toDB(txtProjectName.Text);

                    DataRow dr = projectsDataSet.Tables[2].NewRow();

                    dr["project_id"] = txtProjectID.Text;
                    dr["name"] = txtProjectName.Text;

                    projectsDataSet.projects.AddProjectsRow((timetrackerDataSet.projectsRow)dr);

                    btnSave.Enabled = false;
                    txtProjectName.Enabled = false;

                    projectsDataSet.AcceptChanges();
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
                if (dgProjects.SelectedRows.Count > 0 || dgProjects.SelectedCells.Count > 0)
                {
                    // Get selected item
                    int selectedRowIndex = 0;
                    if (dgProjects.SelectedRows.Count > 0)
                    {
                        selectedRowIndex = dgProjects.SelectedRows[0].Index;
                    }
                    else
                    {
                        selectedRowIndex = dgProjects.SelectedCells[0].RowIndex;
                    }

                    dgProjects.Rows[selectedRowIndex].Selected = false;
                    if (selectedRowIndex > 0) selectedRowIndex--;
                    dgProjects.Rows[selectedRowIndex].Selected = true;

                    txtProjectID.Text = dgProjects.Rows[selectedRowIndex].Cells[0].Value.ToString();
                    txtProjectName.Text = dgProjects.Rows[selectedRowIndex].Cells[1].Value.ToString();
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
                if (dgProjects.SelectedRows.Count > 0 || dgProjects.SelectedCells.Count > 0)
                {
                    // Get selected item
                    int selectedRowIndex = 0;
                    if (dgProjects.SelectedRows.Count > 0)
                    {
                        selectedRowIndex = dgProjects.SelectedRows[0].Index;
                    }
                    else
                    {
                        selectedRowIndex = dgProjects.SelectedCells[0].RowIndex;
                    }

                    dgProjects.Rows[selectedRowIndex].Selected = false;
                    if (selectedRowIndex < (dgProjects.Rows.Count - 1)) selectedRowIndex++;
                    dgProjects.Rows[selectedRowIndex].Selected = true;

                    txtProjectID.Text = dgProjects.Rows[selectedRowIndex].Cells[0].Value.ToString();
                    txtProjectName.Text = dgProjects.Rows[selectedRowIndex].Cells[1].Value.ToString();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void dgProjects_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                if (dgProjects.SelectedRows.Count > 0 || dgProjects.SelectedCells.Count > 0)
                {
                    // Get selected item
                    int selectedRowIndex = 0;
                    if (dgProjects.SelectedRows.Count > 0)
                    {
                        selectedRowIndex = dgProjects.SelectedRows[0].Index;
                    }
                    else
                    {
                        selectedRowIndex = dgProjects.SelectedCells[0].RowIndex;
                    }

                    var project_id = dgProjects.Rows[selectedRowIndex].Cells[0].Value;

                    _dal.DeleteProject_fromDB((int)project_id);
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
                IEnumerable<Project> projects = _dal.LoadProjects_fromDB();
                projects = projects.OrderBy(c => c.Project_ID);

                // Add to Grid
                foreach (Project project in projects)
                {
                    projectsDataSet.AcceptChanges();

                    DataRow dr = projectsDataSet.Tables[2].NewRow();

                    dr["project_id"] = project.Project_ID;
                    dr["name"] = project.Name;

                    projectsDataSet.projects.AddProjectsRow((timetrackerDataSet.projectsRow)dr);
                    projectsDataSet.AcceptChanges();
                }

                // Load last entry
                txtProjectID.Text = projects.FirstOrDefault()?.Project_ID.ToString();
                txtProjectName.Text = projects.FirstOrDefault()?.Name;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
