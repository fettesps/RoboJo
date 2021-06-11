using RoboJo.Entities;
using System;
using System.Collections.Generic;

namespace RoboJo
{
    interface IDAL
    {
        bool ClearDb(String strTable);        
        bool DeleteEntries_fromDB(int entry_id);
        IEnumerable<Entry> LoadEntries_fromDB();
        long WriteEntries_toDB(DateTime? dtStart, DateTime? dtEnd, string strDescription, TimeSpan tsHours, bool booBillable);
        IEnumerable<Client> LoadClients_fromDB();
        bool DeleteClient_fromDB(int client_id);
        long WriteClient_toDB(string strName);
        IEnumerable<Project> LoadProjects_fromDB();
        bool DeleteProject_fromDB(int project_id);
        long WriteProject_toDB(string strName);
        IEnumerable<Task> LoadTasks_fromDB();
        bool DeleteTask_fromDB(int task_id);
        long WriteTask_toDB(string strName);
    }
}