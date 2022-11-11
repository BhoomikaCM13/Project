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

        public string AddTask(Tasks task)
        {
            List<Profile> list=new List<Profile>();
            list=_officeDbContext.profiles.ToList();
            #region Adding details of task
            _officeDbContext.tasks.Add(task);
            _officeDbContext.SaveChanges();
            #endregion
            foreach(var profile in list)
            {
                if (task.CreatedBy == profile.Name)
                {
                  return  profile.Name;
                  break;
                }
            }
            return "Error";
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
