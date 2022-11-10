using OfficeEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OfficeData.Repository
{
    public interface ITaskRepository
    {
        void AddTask(Tasks task);
        void DeleteTask(int tid);
        void UpdateTask(Tasks task);

        Tasks GetTaskById (int id);  
        IEnumerable<Tasks> GetAllTasks();    
    }
}
