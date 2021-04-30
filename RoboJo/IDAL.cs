using RoboJo.Entities;
using System;
using System.Collections.Generic;

namespace RoboJo
{
    interface IDAL
    {
        bool ClearDb(String strTable);
        bool DeleteClient_fromDB(int client_id);
        bool DeleteEntries_fromDB(int entry_id);
        IEnumerable<Client> LoadClients_fromDB();
        IEnumerable<Entry> LoadEntries_fromDB();
        long WriteClient_toDB(string strName);
        long WriteEntries_toDB(DateTime? dtStart, DateTime? dtEnd, string strDescription, TimeSpan tsHours, bool booBillable);
    }
}