using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoboJo.Entities;

namespace RoboJo
{
    class DAL : IDAL
    {
        public IEnumerable<Entry> ReadFromDb()
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

        public bool WriteToDb(DateTime? dtStart, DateTime? dtEnd, String strDescription, TimeSpan tsHours, bool booBillable)
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

                        int intRowsInserted = cmd.ExecuteNonQuery();
                        if (intRowsInserted > 0) return true;
                    }
                }

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ClearDb()
        {
            try
            {
                String strClearSql = "DELETE FROM entries";

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
    }
}
