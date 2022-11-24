using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeDL;
using OfficeEntity;
using System.Collections.Generic;
using System.Linq;

namespace OfficeUI.Controllers
{
    public class TaskBoardController : Controller
    {
        public IActionResult Index(int taskId)
        {
            var db = new Office_Context();
            

            //Get Student detail as per student ID  
            var _tasks = (from a in db.tasks.Include(obj=>obj.profile)
                           where a.Id == taskId
                           select a).FirstOrDefault();

            




            //Get Result Exam marks detail as per student ID  
            var _result = (from a in db.comments.Include(obj=>obj.Profile)
                          where a.taskId == taskId
                          select a).ToList();

            //Get Comment count per task
            var _count = _result.Count();

            //Output set to ViewModel  
            var model = new TaskBoard { _task =_tasks , comments = _result, countMessage=_count };

            return View(model);
        }
    }
}
