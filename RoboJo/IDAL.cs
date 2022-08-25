using RoboJo.Entities;
using System;
using System.Collections.Generic;

namespace RoboJo
{
    interface IDAL
    {
        bool ClearDb();
        bool DeleteFromDb(int entry_id);
        IEnumerable<Entry> ReadFromDb();
        long WriteToDb(DateTime? dtStart, DateTime? dtEnd, string strDescription, TimeSpan tsHours, bool booBillable);
    }
}