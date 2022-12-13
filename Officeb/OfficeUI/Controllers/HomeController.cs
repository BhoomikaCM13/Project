using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OfficeDL;
using OfficeEntity;
using OfficeUI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OfficeUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        Office_Context db = new Office_Context();
        public IActionResult Index()
        {
            List<Message> msg3 = new List<Message>();
            List<Tasks> tasks = new List<Tasks>();
            List<Dashboard> dashboards = new List<Dashboard>();
            List<Comment> comment = new List<Comment>();
            msg3 = db.messages.ToList();

            //Getting Message Count For Today,Month & Year:
            var Messages2 = (from row in msg3
                             where row.createdOn.Date == System.DateTime.Today
                             select row).Count();
            Dashboard message1 = new Dashboard();
            message1.getTodayMessage = Messages2;

            var Messages = (from row in msg3
                            where row.createdOn.Month == System.DateTime.UtcNow.Month
                            select row).Count();
            message1.getMonthMessage = Messages;

            var Messages3 = (from row in msg3
                             where row.createdOn.Year == System.DateTime.UtcNow.Year
                             select row).Count();
            message1.getYearMessage = Messages3;


            //Getting task Count For Today,Month & Year:


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

    //OfficeBoard Policy:
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Privacy1()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
