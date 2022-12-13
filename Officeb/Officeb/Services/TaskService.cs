using OfficeDL.Repository;
using OfficeEntity;
using System;
using System.Collections.Generic;
using System.Text;


namespace OfficeBusiness.Services
{
    public class TaskService
    {
        ITaskRepository taskRepository;
        public TaskService(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }

        // CRUD Service Operations for Tasks:
        public void AddTasks(Tasks task)
        {
            taskRepository.AddTask(task);
        }

        public void UpdateTasks(Tasks task)
        {
            taskRepository.UpdateTask(task);
        }
        public void DeleteTasks(int taskId)
        {
            taskRepository.DeleteTask(taskId);
        }
        public Tasks GetTaskById(int taskId)
        {
            return taskRepository.GetTaskById(taskId);
        }
        public IEnumerable<Tasks> GetTasks()
        {
            return taskRepository.GetAllTasks();
        }


    }
}
