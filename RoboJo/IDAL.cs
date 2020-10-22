using RoboJo.Entities;
using System;
using System.Collections.Generic;

namespace RoboJo
{
    interface IDAL
    {
        bool ClearDb();
        IEnumerable<Entry> ReadFromDb();
        bool WriteToDb(DateTime? dtStart, DateTime? dtEnd, string strDescription, TimeSpan tsHours, bool booBillable);
    }
}