using OfficeEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeDL.Repository
{
   public interface ITaskRepository
    {
        //Method Definition's for TaskEntity
        void AddTask(Tasks task);
        void DeleteTask(int taskId);
        void UpdateTask(Tasks task);
       
        Tasks GetTaskById(int id);
        IEnumerable<Tasks> GetAllTasks();
     
    }
}
