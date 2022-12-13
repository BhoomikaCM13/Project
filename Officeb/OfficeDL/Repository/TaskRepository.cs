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
           
            #region ADD TASK
            _officeDbContext.tasks.Add(task);
            _officeDbContext.SaveChanges();
            #endregion
           
        }

        public void UpdateTask(Tasks task)
        {
            #region EDIT TASK
            _officeDbContext.Entry(task).State = EntityState.Modified;
            _officeDbContext.SaveChanges();
            #endregion
        }

        public void DeleteTask(int taskId)
        {
            #region DELETE TASK 
            var task = _officeDbContext.tasks.Find(taskId);
            _officeDbContext.tasks.Remove(task);
            _officeDbContext.SaveChanges();
            #endregion
        }

        public Tasks GetTaskById(int taskId)
        {
            #region GET TASK BY ID
            var tasks = _officeDbContext.tasks.Include(obj => obj.profile).ToList();
            foreach (var model in tasks)
            {
                if (model.id == taskId)
                {
                    return model;
                }
            }
            return null;
            #endregion
        }


        public IEnumerable<Tasks> GetAllTasks()
        {
            #region GET ALL TASKS WITH PROFILE PROPERTY
            return _officeDbContext.tasks.Include(obj=>obj.profile).ToList();
            #endregion
        }
    }

}
