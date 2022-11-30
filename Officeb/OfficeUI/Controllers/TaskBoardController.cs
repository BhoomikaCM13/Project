using Microsoft.AspNetCore.Mvc;
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
using System.Text;
using System.Threading.Tasks;

namespace OfficeUI.Controllers
{
    public class TaskBoardController : Controller
    {
        private IConfiguration configuration;

        public TaskBoardController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IActionResult Index(int taskId)
        {
            
            if (taskId != 0) 
            { 
                TempData["taskId_"] = taskId; 
                TempData.Keep();
            }


            var db = new Office_Context();


            var _tasks = (from a in db.tasks.Include(obj => obj.profile)
                          where a.Id == Convert.ToInt32(TempData["taskId_"])
                          select a).FirstOrDefault();

            TempData.Keep();

            //Get temp taskid from temp data
 
            var _result = (from a in db.comments.Include(obj => obj.Profile)
                           where a.taskId == Convert.ToInt32(TempData["taskId_"])
                           select a).ToList();
            TempData.Keep();
            //Get Comment count per task
            var _count = _result.Count();

            //Output set to ViewModel  
            var model = new TaskBoard { _task =_tasks , comments = _result, countMessage=_count };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(TaskBoard task)
        {
            Comment comment = new Comment();
            comment.Content = task._comment;
            int ProfileId = Convert.ToInt32(TempData["LoginID"]);
            TempData.Keep();
            comment.PId = ProfileId;
            comment.CreatedOn = DateTime.UtcNow;
            int taskId_ = Convert.ToInt32(TempData["taskId_"]);
            TempData.Keep();
           /* TempData["thedata"] = taskId_;
            TempData.Keep();*/
            comment.taskId = taskId_;
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(comment), Encoding.UTF8, "application/json");
                string endPoint = configuration["WebApiBasedUrl"] + "Comment/AddComment";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Comment Added Successfully";
                        return RedirectToAction("Index","TaskBoard");

                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Oops!";
                    }
                }
            }
            //TaskBoard taskBoard = new TaskBoard();

            return View( );
        }
        [HttpPost]
        public ActionResult Index1()
        {
            var db = new Office_Context();
            TempData["load"] = 3;
            int num = Convert.ToInt32(TempData["load"]) + 3;
            var projects = from pr in db.comments.
                           Include(obj => obj.Profile).Include(obj=>obj.task).Take(num)
                           select pr;
            TempData["load"] = num;
            return View(projects);
        }
    }
}
