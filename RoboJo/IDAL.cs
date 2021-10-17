using RoboJo.Entities;
using System;
using System.Collections.Generic;

namespace RoboJo
{
    interface IDAL
    {
        bool ClearDb();
        bool ClearTable(String strTable);
        bool DeleteClient(int client_id);
        bool DeleteEntries(int entry_id);
        bool DeleteProjects(int project_id);
        bool DeleteTasks(int task_id);
        IEnumerable<Client> LoadClients();
        IEnumerable<Entry> LoadEntries();
        IEnumerable<Project> LoadProjects();
        IEnumerable<Task> LoadTasks();
        long WriteClient(string strName);
        long WriteProject(string strName);
        long WriteTask(string strName);
        long WriteEntries(DateTime? dtStart, DateTime? dtEnd, string strDescription, TimeSpan tsHours, bool booBillable);
    }
}