using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        [HttpGet]
        public async Task<IActionResult> Index1(int taskId)
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
                    }
                }
            }
              
            return View(tasks);
        }

        //[HttpGet]
        //public async Task<IActionResult> Index1()
        //{
        //    IEnumerable<Tasks> taskresult = null;
        //    using (HttpClient client = new HttpClient())
        //    {
        //        string endPoint = _configuration["WebApiBasedUrl"] + "Task/GetTask";
        //        using (var response = await client.GetAsync(endPoint))
        //        {
        //            if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //            {
        //                var result = await response.Content.ReadAsStringAsync();
        //                taskresult = JsonConvert.DeserializeObject<IEnumerable<Tasks>>(result);


        //            }
        //        }
        //    }
        //    return View(taskresult);
        //}

        public async Task<IActionResult> TasksCreate()
        {
            /*Profile profile = new Profile();
            using (HttpClient client = new HttpClient())
            {
                int Id = Convert.ToInt32(TempData["LoginID"]);
                string endpoint = _configuration["WebApiBasedUrl"] + "Profile/GetProfileById?profileId=" + Id;
                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        profile = JsonConvert.DeserializeObject<Profile>(result);
                    }
                }
            }*/
          Tasks tasks = new Tasks();
            tasks.ProfileId = Convert.ToInt32(TempData["LoginID"]);
            return View(tasks);
        }
        

        [HttpPost]

        public async Task<IActionResult> TasksCreate(Tasks Task)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(Task), Encoding.UTF8, "application/json");
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
                    }
                }
            }
            return View(tasks);
        }
        [HttpPost]
        public async Task<IActionResult> EditTasks(Tasks task)
        {
           
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
                    }
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTasks(Tasks task)
        {

            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBasedUrl"] + "Task/DeleteTask?tid=" + task.Id;
                using (var response = await client.DeleteAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Tasks details deleted successfully";
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

        //public ActionResult GetTodayCount()
        //{

        //    var count = (from row in db.tasks
        //                 where row.CreatedOn.Date == DateTime.UtcNow.Date
        //                 select row).Count();
        //    ViewBag.ItemCount = count;
        //    return View(count);
        //}
       

}
}



