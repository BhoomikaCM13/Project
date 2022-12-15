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
                          where a.id == Convert.ToInt32(TempData["taskId_"])
                          select a).FirstOrDefault();

            TempData.Keep();

            //Get temp taskid from temp data
 
            var _result = (from a in db.comments.Include(obj => obj.profile).OrderByDescending(obj=>obj.createdOn)
                           where a.taskId == Convert.ToInt32(TempData["taskId_"])
                           select a).ToList();
            
            
            TempData.Keep();

            //Get Comment count per task

            var _count = _result.Count();

            //Output set to ViewModel
            
            var model = new TaskBoard { task =_tasks , commentsList = _result, countMessage=_count };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(TaskBoard task)
        {
            //For auto generating values using TempData:

            Comment commentobj = new Comment();
            commentobj.content = task.comment;
            int ProfileId = Convert.ToInt32(TempData["LoginID"]);
            TempData.Keep();
            commentobj.profileId = ProfileId;
            commentobj.createdOn = DateTime.Now;
            int task_Id = Convert.ToInt32(TempData["taskId_"]);
            TempData.Keep();
            commentobj.taskId = task_Id;
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                //Add Comment for Particular Task

                StringContent content = new StringContent(JsonConvert.SerializeObject(commentobj), Encoding.UTF8, "application/json");
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

            return View( );
        }
    }
}
