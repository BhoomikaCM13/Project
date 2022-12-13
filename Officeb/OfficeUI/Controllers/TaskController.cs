using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using Newtonsoft.Json;
using OfficeDL;
using OfficeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OfficeUI.Controllers
{
    public class TaskController : Controller
    {
        IConfiguration _configuration;

        Office_Context db=new Office_Context();

        public TaskController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Get Task details
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Tasks> taskresult = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBasedUrl"] + "Task/GetTask";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        taskresult = JsonConvert.DeserializeObject<IEnumerable<Tasks>>(result);


                    }
                }
            }
            return View(taskresult);
        }

        // Created a view to add Task:
        public async Task<IActionResult> TasksCreate()
        {
            return View( );
        }


        [HttpPost]

        public async Task<IActionResult> TasksCreate(Tasks Tasks)
        {
            //Get temporary Profile from  tempdata

            int Id = Convert.ToInt32(TempData["LoginID"]);
            TempData.Keep();
            Tasks.profileId = Id;
            Tasks.createdOn = DateTime.Now;
            using (HttpClient client = new HttpClient())
            {
                //Add Task

                StringContent content = new StringContent(JsonConvert.SerializeObject(Tasks), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBasedUrl"] + "Task/AddTask";
                using (var response = await client.PostAsync(endPoint, content))


                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Tasks details saved successfully ";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong Entries";
                    }
                }
            }

            return View();
        }


        public async Task<IActionResult> EditTasks(int taskId)
        {
            Tasks tasks = null;
          
            using (HttpClient client = new HttpClient())
            {
                //Edit Task: To display the Task ie related to TaskId

                string endPoint = _configuration["WebApiBasedUrl"] + "Task/GetTaskById?taskId=" + taskId;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        tasks = JsonConvert.DeserializeObject<Tasks>(result);

                        //Get temporary taskid from  tempdata

                        int TASKID = tasks.id;
                        TempData["TaskId"] = TASKID;
                        TempData.Keep();
                    }
                }
            }
           
            return View(tasks);
        }
        [HttpPost]
        public async Task<IActionResult> EditTasks(Tasks task)
        {
            //Get temporary Profile and Task from  tempdata

            int Id = Convert.ToInt32(TempData["LoginID"]);
            TempData.Keep();
            int taskId_ = Convert.ToInt32(TempData["TaskId"]);
            TempData.Keep();
            task.profileId = Id;
            task.createdOn = DateTime.Now;
            task.id = taskId_;

            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(task), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBasedUrl"] + "Task/UpdateTask";
                using (var response = await client.PutAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Tasks details saved successfully";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong Entries";
                    }
                }
            }
            return View();
        }
        public async Task<IActionResult> DeleteTasks(int taskId)
        {
            using (HttpClient client = new HttpClient())
            {
                //Editing the Task using PUT request 

                string endPoint = _configuration["WebApiBasedUrl"] + "Task/DeleteTask?taskId=" + taskId;
                using (var response = await client.DeleteAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Tasks details deleted successfully";
                        return RedirectToAction("Index", "Task");
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "WrongEntries";
                    }
                }

            }
            return View();
        }
}
}