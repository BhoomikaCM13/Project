using Microsoft.AspNetCore.Mvc;
using OfficeDL;
using OfficeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace OfficeUI.Controllers
{
    public class CountController : Controller
    {
        Office_Context db=new Office_Context();

        public ActionResult GetFullCount()
        {
            List<Message> msg3 = new List<Message>();
            List<Tasks> tasks = new List<Tasks>();
            List<Dashboard> dashboards = new List<Dashboard>();
            msg3 = db.messages.ToList();

            

            var Messages = (from row in msg3
                            where row.CreatedOn.Month == System.DateTime.UtcNow.Month
                            select row).Count();
            Dashboard message1 = new Dashboard();
            message1.GetMonthmsg = Messages;

            var Messages2 = (from row in msg3
                            where row.CreatedOn.Date == System.DateTime.Today
                            select row).Count();
            message1.GetTodaymsg = Messages2;


            var Messages3 = (from row in msg3
                            where row.CreatedOn.Year == System.DateTime.UtcNow.Year
                            select row).Count();
            message1.GetYearmsg = Messages3;
           

            //Geting task count
       

            tasks = db.tasks.ToList();

            var tasks0 = (from row in tasks
                             where row.CreatedOn.Date == System.DateTime.Today
                             select row).Count();
            message1.GetTodayTask = tasks0;


            var tasks1 = (from row in tasks
                            where row.CreatedOn.Month == System.DateTime.UtcNow.Month
                            select row).Count();
            message1.GetMonthTask = tasks1;

            


            var tasks2 = (from row in tasks
                             where row.CreatedOn.Year == System.DateTime.UtcNow.Year
                             select row).Count();
            message1.GetYearTask = tasks2;



            List<Comment> comment = new List<Comment>();

            comment = db.comments.ToList();



            var commentMonth = (from row in comment
                                where row.CreatedOn.Month == System.DateTime.UtcNow.Month
                                select row).Count();
            message1.GetMonthcomment = commentMonth;

            var commentToday = (from row in comment
                                where row.CreatedOn.Date == System.DateTime.Today
                                select row).Count();
            message1.GetTodaycomment = commentToday;


            var commentYear = (from row in comment
                               where row.CreatedOn.Year == System.DateTime.UtcNow.Year
                               select row).Count();
            message1.GetYearcomment = commentYear;

            return View(message1);
        }




        
       

 

    }
}
