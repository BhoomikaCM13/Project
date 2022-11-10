using Microsoft.EntityFrameworkCore;
using OfficeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeData.Repository
{
    public class TaskRepository : ITaskRepository
    {
        OfficeDbContext _officeDbContext;

        public TaskRepository(OfficeDbContext officeDbContext)
        {
            _officeDbContext = officeDbContext;
        }

        public void AddTask(Tasks task)
        {
            #region Adding details of task
            _officeDbContext.tasks.Add(task);
            _officeDbContext.SaveChanges();
            #endregion
        }

        public void UpdateTask(Tasks task)
        {
            _officeDbContext.Entry(task).State= EntityState.Modified;
            _officeDbContext.SaveChanges();
        }

        public void DeleteTask(int tid)
        {
            var task1=_officeDbContext.tasks.Find(tid);
            _officeDbContext.tasks.Remove(task1);
            _officeDbContext.SaveChanges();
        }

        public Tasks GetTaskById(int tid)
        {
            return _officeDbContext.tasks.Find(tid);
        }


       public  IEnumerable<Tasks> GetAllTasks()
        {
            return _officeDbContext.tasks.ToList();
        }
    }
}
