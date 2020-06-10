using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoboJo.Entities;

namespace RoboJo
{
    class DAL
    {
        public IEnumerable<TimeRecord> ReadFromDb()
        {
            String strReadStatement = "SELECT [start_time],[end_time],[description],[billable],[hours] " +
                                        "FROM timesheet";

            using (SqlConnection sqlCon = new SqlConnection(Properties.Settings.Default.connectionString))
            {
                sqlCon.Open();

                using (SqlCommand cmd = new SqlCommand(strReadStatement, sqlCon))
                {
                    SqlDataReader sqlDr = cmd.ExecuteReader();
                    while (sqlDr.Read())
                    {
                        yield return new TimeRecord()
                        {
                            StartTime = sqlDr.GetDateTime(sqlDr.GetOrdinal("start_time")),
                            EndTime = sqlDr.GetDateTime(sqlDr.GetOrdinal("end_time")),
                            Description = sqlDr["description"].ToString(),
                            Hours = sqlDr["hours"].ToString(),
                            Billable = (bool)sqlDr["billable"]
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
                String strInsertStatement = "INSERT INTO timesheet ([start_time],[end_time],[description],[billable],[hours]) " +
                                           " VALUES (@start_time,@end_time,@description,@billable,@hours)";

                using (SqlConnection sqlCon = new SqlConnection(Properties.Settings.Default.connectionString))
                {
                    sqlCon.Open();

                    using (SqlCommand cmd = new SqlCommand(strInsertStatement, sqlCon))
                    {
                        cmd.Parameters.Add("@start_time", SqlDbType.DateTime).Value = dtStart;
                        cmd.Parameters.Add("@end_time", SqlDbType.DateTime).Value = dtEnd;
                        cmd.Parameters.Add("@description", SqlDbType.NVarChar).Value = strDescription;
                        cmd.Parameters.Add("@billable", SqlDbType.Bit).Value = booBillable;
                        cmd.Parameters.Add("@hours", SqlDbType.NVarChar).Value = tsHours.ToString();

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
                String strClearSql = "TRUNCATE TABLE timesheet";

                using (SqlConnection sqlCon = new SqlConnection(Properties.Settings.Default.connectionString))
                {
                    sqlCon.Open();

                    using (SqlCommand cmd = new SqlCommand(strClearSql, sqlCon))
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
