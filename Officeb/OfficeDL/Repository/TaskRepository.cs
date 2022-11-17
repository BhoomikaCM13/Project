using Microsoft.EntityFrameworkCore;
using OfficeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OfficeDL.Repository
{
    public class TaskRepository:ITaskRepository
    {
        Office_Context _officeDbContext;

        public TaskRepository(Office_Context officeDbContext)
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
            _officeDbContext.Entry(task).State = EntityState.Modified;
            _officeDbContext.SaveChanges();
        }

        public void DeleteTask(int tid)
        {
            var task1 = _officeDbContext.tasks.Find(tid);
            _officeDbContext.tasks.Remove(task1);
            _officeDbContext.SaveChanges();
        }

        public Tasks GetTaskById(int tid)
        {
            return _officeDbContext.tasks.Find(tid);
        }


        public IEnumerable<Tasks> GetAllTasks()
        {
            return _officeDbContext.tasks.Include(obj=>obj.profile).ToList();
        }


        
    }

}
