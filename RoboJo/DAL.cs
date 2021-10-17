using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using RoboJo.Entities;

namespace RoboJo
{
    class DAL : IDAL
    {
        #region Entries

        public IEnumerable<Entry> LoadEntries()
        {
            String strReadStatement = "SELECT * " +
                                      "FROM entries";

            using (SQLiteConnection sqlCon = new SQLiteConnection(GetConnectionString()))
            {
                sqlCon.Open();

                using (SQLiteCommand cmd = new SQLiteCommand(strReadStatement, sqlCon))
                {
                    SQLiteDataReader sqlDr = cmd.ExecuteReader();
                    while (sqlDr.Read())
                    {
                        yield return new Entry()
                        {
                            Entry_ID = Convert.ToInt32(sqlDr["entry_id"].ToString()),
                            StartTime = Convert.ToDateTime(sqlDr["start_time"].ToString()),
                            EndTime = Convert.ToDateTime(sqlDr["end_time"].ToString()),
                            Description = sqlDr["description"].ToString(),
                            Hours = sqlDr["hours"].ToString(),
                            Billable = Convert.ToInt32(sqlDr["billable"].ToString())
                        };
                    }
                    sqlDr.Close();
                }
            }
        }

        public long WriteEntries(DateTime? dtStart, DateTime? dtEnd, String strDescription, TimeSpan tsHours, bool booBillable)
        {
            try
            {
                String strInsertStatement = "INSERT INTO entries ([start_time],[end_time],[description],[billable],[hours]) " +
                                           " VALUES (@start_time,@end_time,@description,@billable,@hours)";

                using (SQLiteConnection sqlCon = new SQLiteConnection(GetConnectionString()))
                {
                    sqlCon.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(strInsertStatement, sqlCon))
                    {
                        cmd.Parameters.AddWithValue("@start_time", dtStart);
                        cmd.Parameters.AddWithValue("@end_time", dtEnd);
                        cmd.Parameters.AddWithValue("@description", strDescription);
                        cmd.Parameters.AddWithValue("@billable", booBillable);
                        cmd.Parameters.AddWithValue("@hours", tsHours.ToString());

                        int intInsertCmd = cmd.ExecuteNonQuery();
                        long intInsertedId = sqlCon.LastInsertRowId;

                        return intInsertedId;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteEntries(int entry_id)
        {
            try
            {
                String strSQLStatement = "DELETE FROM entries " +
                                         "WHERE entry_id = @entry_id";

                using (SQLiteConnection sqlCon = new SQLiteConnection(GetConnectionString()))
                {
                    sqlCon.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(strSQLStatement, sqlCon))
                    {
                        cmd.Parameters.AddWithValue("@entry_id", entry_id);

                        int intRowsDeleted = cmd.ExecuteNonQuery();
                        if (intRowsDeleted > 0) return true;
                    }
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Clients

        public IEnumerable<Client> LoadClients()
        {
            String strReadStatement = "SELECT * " +
                                      "FROM Clients";

            using (SQLiteConnection sqlCon = new SQLiteConnection(GetConnectionString()))
            {
                sqlCon.Open();

                using (SQLiteCommand cmd = new SQLiteCommand(strReadStatement, sqlCon))
                {
                    SQLiteDataReader sqlDr = cmd.ExecuteReader();
                    while (sqlDr.Read())
                    {
                        yield return new Client()
                        {
                            Client_ID = Convert.ToInt32(sqlDr["client_id"].ToString()),
                            Name = sqlDr["name"].ToString()
                        };
                    }
                    sqlDr.Close();
                }
            }
        }

        public long WriteClient(String strName)
        {
            try
            {
                String strInsertStatement = "INSERT INTO Clients ([name]) " +
                                           " VALUES (@name)";

                using (SQLiteConnection sqlCon = new SQLiteConnection(GetConnectionString()))
                {
                    sqlCon.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(strInsertStatement, sqlCon))
                    {
                        cmd.Parameters.AddWithValue("@name", strName);

                        int intInsertCmd = cmd.ExecuteNonQuery();
                        long intInsertedId = sqlCon.LastInsertRowId;

                        return intInsertedId;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteClient(int client_id)
        {
            try
            {
                String strSQLStatement = "DELETE FROM Clients " +
                                         "WHERE client_id = @client_id";

                using (SQLiteConnection sqlCon = new SQLiteConnection(GetConnectionString()))
                {
                    sqlCon.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(strSQLStatement, sqlCon))
                    {
                        cmd.Parameters.AddWithValue("@client_id", client_id);

                        int intRowsDeleted = cmd.ExecuteNonQuery();
                        if (intRowsDeleted > 0) return true;
                    }
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Projects

        public IEnumerable<Project> LoadProjects()
        {
            String strReadStatement = "SELECT * " +
                                      "FROM Projects";

            using (SQLiteConnection sqlCon = new SQLiteConnection(GetConnectionString()))
            {
                sqlCon.Open();

                using (SQLiteCommand cmd = new SQLiteCommand(strReadStatement, sqlCon))
                {
                    SQLiteDataReader sqlDr = cmd.ExecuteReader();
                    while (sqlDr.Read())
                    {
                        yield return new Project()
                        {
                            Project_ID = Convert.ToInt32(sqlDr["project_id"].ToString()),
                            Name = sqlDr["name"].ToString()
                        };
                    }
                    sqlDr.Close();
                }
            }
        }

        public long WriteProject(String strName)
        {
            try
            {
                String strInsertStatement = "INSERT INTO Projects ([name]) " +
                                           " VALUES (@name)";

                using (SQLiteConnection sqlCon = new SQLiteConnection(GetConnectionString()))
                {
                    sqlCon.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(strInsertStatement, sqlCon))
                    {
                        cmd.Parameters.AddWithValue("@name", strName);

                        int intInsertCmd = cmd.ExecuteNonQuery();
                        long intInsertedId = sqlCon.LastInsertRowId;

                        return intInsertedId;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteProjects(int project_id)
        {
            try
            {
                String strSQLStatement = "DELETE FROM Project " +
                                         "WHERE project_id = @project_id";

                using (SQLiteConnection sqlCon = new SQLiteConnection(GetConnectionString()))
                {
                    sqlCon.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(strSQLStatement, sqlCon))
                    {
                        cmd.Parameters.AddWithValue("@project_id", project_id);

                        int intRowsDeleted = cmd.ExecuteNonQuery();
                        if (intRowsDeleted > 0) return true;
                    }
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Tasks

        public IEnumerable<Task> LoadTasks()
        {
            String strReadStatement = "SELECT * " +
                                      "FROM Tasks";

            using (SQLiteConnection sqlCon = new SQLiteConnection(GetConnectionString()))
            {
                sqlCon.Open();

                using (SQLiteCommand cmd = new SQLiteCommand(strReadStatement, sqlCon))
                {
                    SQLiteDataReader sqlDr = cmd.ExecuteReader();
                    while (sqlDr.Read())
                    {
                        yield return new Task()
                        {
                            Task_ID = Convert.ToInt32(sqlDr["task_id"].ToString()),
                            Name = sqlDr["name"].ToString()
                        };
                    }
                    sqlDr.Close();
                }
            }
        }

        public long WriteTask(String strName)
        {
            try
            {
                String strInsertStatement = "INSERT INTO Tasks ([name]) " +
                                           " VALUES (@name)";

                using (SQLiteConnection sqlCon = new SQLiteConnection(GetConnectionString()))
                {
                    sqlCon.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(strInsertStatement, sqlCon))
                    {
                        cmd.Parameters.AddWithValue("@name", strName);

                        int intInsertCmd = cmd.ExecuteNonQuery();
                        long intInsertedId = sqlCon.LastInsertRowId;

                        return intInsertedId;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteTasks(int task_id)
        {
            try
            {
                String strSQLStatement = "DELETE FROM Task " +
                                         "WHERE task_id = @task_id";

                using (SQLiteConnection sqlCon = new SQLiteConnection(GetConnectionString()))
                {
                    sqlCon.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(strSQLStatement, sqlCon))
                    {
                        cmd.Parameters.AddWithValue("@task_id", task_id);

                        int intRowsDeleted = cmd.ExecuteNonQuery();
                        if (intRowsDeleted > 0) return true;
                    }
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region General

        public bool ClearDb(string strTable)
        {
            try
            {
                String strClearSql = "DELETE FROM " + strTable;

                using (SQLiteConnection sqlCon = new SQLiteConnection(GetConnectionString()))
                {
                    sqlCon.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(strClearSql, sqlCon))
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string GetConnectionString()
        {
            try
            {
                String relativePath = @"Assets\robojo.db";
                String currentPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                String absolutePath = System.IO.Path.Combine(currentPath, relativePath).Remove(0, 6);

                return String.Format("Data Source={0}", absolutePath);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ClearDb()
        {
            throw new NotImplementedException();
        }

        public bool ClearTable(string strTable)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
