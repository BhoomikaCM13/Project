using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using OfficeEntity;
using System.Collections.Generic;
using System.Net.Http;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OfficeBoardMVC.Controllers
{
    public class TaskController : Controller
    {
        IConfiguration _configuration;

        public TaskController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Tasks> taskresult = null;
            using (HttpClient client=new HttpClient())
            {
                string endPoint = _configuration["WebApiBasedUrl"] + "Task/GetTask";
                using (var response = await client.GetAsync(endPoint))
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result=await response.Content.ReadAsStringAsync();
                        taskresult = JsonConvert.DeserializeObject<IEnumerable<Tasks>>(result);


                    }
                }
            }
            return View(taskresult);
        }

        public IActionResult TasksCreate()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> TasksCreate(Tasks Task)
        {
            using(HttpClient client=new HttpClient())
            {
                StringContent content=new StringContent(JsonConvert.SerializeObject(Task), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBasedUrl"] + "Task/AddTask";
                using(var response = await client.PostAsync(endPoint,content))


                {
                    if(response.StatusCode==System.Net.HttpStatusCode.OK)
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
            using (HttpClient client=new HttpClient())
            {
                string endPoint = _configuration["WebApiBasedUrl"] + "Task/GetTaskById?tid=" + taskId;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode==System.Net.HttpStatusCode.OK)
                    {
                        var result=await response.Content.ReadAsStringAsync();
                        tasks= JsonConvert.DeserializeObject<Tasks>(result);
                    }
                }
            }
            return View(tasks);
        }
        [HttpPost]
        public async Task<IActionResult> EditTasks(Tasks tasks)
        {
            using (HttpClient client=new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(tasks),Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBasedUrl"] + "Task/UpdateTask";
                using(var response = await client.PutAsync(endPoint,content))
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
            return View(tasks);
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
            //ViewBag.status = "";
            //using (HttpClient client = new HttpClient())
            //{
            //    string endPoint = _configuration["WebApiBasedUrl"] + "Task/DeleteTask?tid=" + taskId;
            //    using (var response = await client.DeleteAsync(endPoint))
            //    {
            //        if (response.StatusCode == System.Net.HttpStatusCode.OK)
            //        {
            //            ViewBag.status = "Ok";
            //            ViewBag.message = "Doctor Details Deleted Successfully!";
            //        }
            //        else
            //        {
            //            ViewBag.status = "Error";
            //            ViewBag.message = "Wrong Entries!";
            //        }
            //    }
            //}
            return View();
        }
    }
}
