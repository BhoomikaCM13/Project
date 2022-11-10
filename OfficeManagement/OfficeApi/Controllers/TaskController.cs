using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeBusiness.Service;
using OfficeEntity;
using System.Collections;
using System.Collections.Generic;

namespace OfficeApi.Controllers
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

        [HttpGet("GetTasks")]
        public IEnumerable<Tasks> GetTask()
        {
            return taskService.GetTasks();
        }

        [HttpPost("AddTasks")]
        public IActionResult AddTask([FromBody] Tasks tasks)
        {
            taskService.AddTasks(tasks);
            return Ok("Task Added Successfully");
        }

        [HttpDelete("DeleteTasks")]
        public IActionResult DeleteTask(int tid)
        {
            taskService.DeleteTasks(tid);
            return Ok("Tasks Deleted Successfully");
        }

        [HttpPut("UpdateTasks")]
        public IActionResult UpdateTask(Tasks task)
        {
            taskService.UpdateTasks(task);
            return Ok("task updated successfully");
        }

        [HttpGet("GetTaskById")]
        public Tasks GetTaskById(int tid)
        {
            return taskService.GetTaskById(tid);
        }
       
    }
}
