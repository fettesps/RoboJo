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
    class BLL : IBLL
    {
        private IDAL _dal;

        public TimeSpan CalculateTotals()
        {
            try
            {
                _dal = Factory.OpenDB();

                IEnumerable<Entry> entries = _dal.ReadFromDb();

                TimeSpan tsHours;
                TimeSpan tsHoursTotal = new TimeSpan();

                // Recalculate Total Hours
                foreach (Entry entry in entries)
                {
                    tsHours = entry.EndTime.Value - entry.StartTime.Value;
                    tsHours = tsHours.RoundToNearestMinutes(15);

                    tsHoursTotal = tsHoursTotal.Add(tsHours);
                }

                return tsHoursTotal;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
