using OfficeData.Repository;
using OfficeEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeBusiness.Service
{
    public class TaskService
    {
        ITaskRepository taskRepository;
        public TaskService(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }   

        public void AddTasks(Tasks task)
        {
            taskRepository.AddTask(task);
        }

        public void UpdateTasks(Tasks task)
        {
            taskRepository.UpdateTask(task);
        }
        public void DeleteTasks(int tid)
        {
            taskRepository.DeleteTask(tid);
        }
        public Tasks GetTaskById(int tid)
        {
           return taskRepository.GetTaskById(tid);    
        }
        public IEnumerable<Tasks> GetTasks()
        {
            return taskRepository.GetAllTasks();
        }

    }
}
