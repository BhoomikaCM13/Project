using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeBusiness.Services;
using OfficeEntity;
using System.Collections.Generic;

namespace OfficeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {

        private TaskService taskService;
        public TaskController(TaskService taskService)
        {
            this.taskService = taskService;
        }

        [HttpGet("GetTask")]
        public IEnumerable<Tasks> GetTask()
        {
            #region Get Task
            return taskService.GetTasks();
            #endregion 
        }

        [HttpPost("AddTask")]
        public IActionResult AddTask([FromBody] Tasks tasks)
        {
            #region Add Task 
            taskService.AddTasks(tasks);
            return Ok("Task Added Successfully");
            #endregion
        }

        [HttpDelete("DeleteTask")]
        public IActionResult DeleteTask(int taskId)
        {
            #region Delete Task
            taskService.DeleteTasks(taskId);
            return Ok("Tasks Deleted Successfully");
            #endregion
        }

        [HttpPut("UpdateTask")]
        public IActionResult UpdateTask(Tasks task)
        {
            #region Edit Task 
            taskService.UpdateTasks(task);
            return Ok("task updated successfully");
            #endregion 
        }

        [HttpGet("GetTaskById")]
        public Tasks GetTaskById(int taskId)
        {
            #region Get Task By Id
            return taskService.GetTaskById(taskId);
            #endregion
        }
    }
}
