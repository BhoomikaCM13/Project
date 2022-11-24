using Microsoft.EntityFrameworkCore;
using OfficeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var task = _officeDbContext.tasks.Find(tid);
            _officeDbContext.tasks.Remove(task);
            _officeDbContext.SaveChanges();
        }

        public Tasks GetTaskById(int tid)
        {
            /*return _officeDbContext.tasks.Find(tid);*/
            var tasks= _officeDbContext.tasks.Include(obj => obj.profile).ToList();
            foreach (var model in tasks)
            {
                if (model.Id == tid)
                {
                    return model;
                }
            }
            return null;
        }


        public IEnumerable<Tasks> GetAllTasks()
        {
            return _officeDbContext.tasks.Include(obj=>obj.profile).ToList();
        }

        ////.Include(obj => obj.Task)
        //public List<Task> GetTasksByTaskId(int taskId)
        //{
        //    List<Task> tasks = _officeDbContext.tasks.Include(obj => obj.Profile).ToList();
        //    List<Task> result = new List<Task>();
        //    foreach (var comment in tasks)

        //    {
        //        if (comment.Id == taskId)
        //        {
        //            result.Add(comment);
        //        }
        //    }
        //    return result;
        //}
    }

}
