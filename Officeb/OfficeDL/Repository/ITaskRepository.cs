using OfficeEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeDL.Repository
{
   public interface ITaskRepository
    {
        void AddTask(Tasks task);
        void DeleteTask(int tid);
        void UpdateTask(Tasks task);
       
        Tasks GetTaskById(int id);
        IEnumerable<Tasks> GetAllTasks();
     
    }
}
