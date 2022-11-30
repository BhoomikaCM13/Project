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
        public async Task<IActionResult> TasksCreate()
        {
            return View( );
        }


        [HttpPost]

        public async Task<IActionResult> TasksCreate(Tasks Tasks)
        {

            int Id = Convert.ToInt32(TempData["LoginID"]);
            TempData.Keep();
            Tasks.ProfileId = Id;
            Tasks.CreatedOn = DateTime.Now;
            using (HttpClient client = new HttpClient())
            {
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
                string endPoint = _configuration["WebApiBasedUrl"] + "Task/GetTaskById?tid=" + taskId;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        tasks = JsonConvert.DeserializeObject<Tasks>(result);

                        //Get temporary taskid from  tempdata
                        int TASKID = tasks.Id;
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

            int Id = Convert.ToInt32(TempData["LoginID"]);
            TempData.Keep();
            int taskId_ = Convert.ToInt32(TempData["TaskId"]);
            TempData.Keep();
            task.ProfileId = Id;
            task.CreatedOn = DateTime.Now;
            task.Id = taskId_;

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
            /*int taskId_ = Convert.ToInt32(TempData["TaskId_"]);
            TempData.Keep();
            task.Id = taskId_;*/
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBasedUrl"] + "Task/DeleteTask?tid="+ taskId;
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