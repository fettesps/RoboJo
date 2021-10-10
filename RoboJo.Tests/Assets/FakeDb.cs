using RoboJo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboJo.Tests
{
    class FakeDb : IDAL
    {
        bool IDAL.ClearDb()
        {
            throw new NotImplementedException();
        }

        bool IDAL.DeleteFromDb(int entry_id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Entry> IDAL.ReadFromDb()
        {
            var ret = new List<Entry>();
            ret.Add(new Entry()
            {
                StartTime = DateTime.Now.AddHours(-1),
                EndTime = DateTime.Now,
                Description = "FakeDB test description",
                Billable = 1,
                Hours = "01:00"
            });
            return ret;
        }

        long IDAL.WriteToDb(DateTime? dtStart, DateTime? dtEnd, string strDescription, TimeSpan tsHours, bool booBillable)
        {
            throw new NotImplementedException();
        }
    }
}
