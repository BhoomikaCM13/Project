using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using OfficeDL;
using OfficeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
//using Message = OfficeEntity.Message;

namespace OfficeUI.Controllers
{
    public class CountController : Controller
    {
        Office_Context db=new Office_Context();

        public IActionResult GetFullCount()
        {
            List<Tasks> tasks = new List<Tasks>();
            List<Dashboard> dashboards = new List<Dashboard>();
            List<Comment> comment = new List<Comment>();

            //Getting Message Count For Today,Month & Year:

            var Messages2 = (from row in db.messages
                             where row.createdOn.Date == System.DateTime.Today
                             select row).Count();
            Dashboard message1 = new Dashboard();
            message1.getTodayMessage = Messages2;


            var Messages = (from row in db.messages
                            where row.createdOn.Month == System.DateTime.UtcNow.Month
                            select row).Count();
            message1.getMonthMessage = Messages;

            var Messages3 = (from row in db.messages
                             where row.createdOn.Year == System.DateTime.UtcNow.Year
                             select row).Count();
            message1.getYearMessage = Messages3;


            //Geting Task Count For Today,Month & Year:


            tasks = db.tasks.ToList();

            var tasks0 = (from row in tasks
                          where row.createdOn.Date == System.DateTime.Today
                          select row).Count();
            message1.getTodayTask = tasks0;

            var tasks1 = (from row in tasks
                          where row.createdOn.Month == System.DateTime.UtcNow.Month
                          select row).Count();
            message1.getMonthTask = tasks1;

            var tasks2 = (from row in tasks
                          where row.createdOn.Year == System.DateTime.UtcNow.Year
                          select row).Count();
            message1.getYearTask = tasks2;


            //Getting Comment Count For Today,Month & Year:
            comment = db.comments.ToList();
            var commentMonth = (from row in comment
                                where row.createdOn.Month == System.DateTime.UtcNow.Month
                                select row).Count();
            message1.getMonthComment = commentMonth;

            var commentToday = (from row in comment
                                where row.createdOn.Date == System.DateTime.Today
                                select row).Count();
            message1.getTodayComment = commentToday;


            var commentYear = (from row in comment
                               where row.createdOn.Year == System.DateTime.UtcNow.Year
                               select row).Count();
            message1.getYearComment = commentYear;

            return View(message1);
        }
    }
}
