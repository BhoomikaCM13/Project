using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using OfficeDL;
using OfficeEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OfficeUI.Controllers
{
    public class MessageController : Controller
    {
        private IConfiguration _configuration;

        Office_Context db = new Office_Context();

        public MessageController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        public ActionResult Index(string searchtitle)
        {
            //MessageBoard Search Bar by message title 

            var projects = from pr in db.messages.
                           Include(obj => obj.Profile
                           )
                           select pr;

            if (!String.IsNullOrEmpty(searchtitle))
            {
                projects = projects.Where(c => c.title.Contains(searchtitle));
            }
            return View(projects); 

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            Profile a = new Profile();
            
           
            IEnumerable<Message> messageresult = null;
            
            using (HttpClient client = new HttpClient())
            {
                // Created a view to get Message:

                string endPoint = _configuration["WebApiBasedUrl"] + "Message/GetMessages";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        messageresult = JsonConvert.DeserializeObject<IEnumerable<Message>>(result);
                    }
                    TempData["countofmessage"] = messageresult.Count();
                    TempData.Keep();

                }
            }

            // Displaying first two Messages

            List<Message> messages = new List<Message>();

            int i = 0;

            foreach (var message in messageresult)
            {
                if (i < 2)
                {
                    i += 1;
                    messages.Add(message);
                }
            }
            
            return View(messages);
        }

        //Used for getting the LoadAll Implementation
        public async Task<IActionResult> Index1(int a)
        {

            IEnumerable<Message> messageresult = null;

            using (HttpClient client = new HttpClient())
            {
                // Created a view to get Message:

                string endPoint = _configuration["WebApiBasedUrl"] + "Message/GetMessages";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        messageresult = JsonConvert.DeserializeObject<IEnumerable<Message>>(result);
                    }

                }
            }
            //TempData["load"] = 2;
            //int num = Convert.ToInt32(TempData["load"]) + Convert.ToInt32(TempData["countofmessage"]) - 2;
            //TempData.Keep();
            //var projects = from pr in db.messages.
            //               Include(obj => obj.Profile
            //               ).Take(num)
            //               select pr;
            //TempData["load"] = num;
            return View(messageresult);
        }

        //Creating a View to Add Message
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> Create(Message message)
        {
            //Get temporary Profile from  tempdata

            int Id = Convert.ToInt32(TempData["LoginID"]);
            TempData.Keep();
            message.pId= Id;
            message.createdOn= DateTime.Now;
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                //Add Messages 

                StringContent content = new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBasedUrl"] + "Message/AddMessage";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Message details saved sucessfully!!";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong entries!";
                    }
                }
            }
            return View();
        }
        public async Task<IActionResult> Edit(int id)
        {

            int Id = Convert.ToInt32(TempData["LoginID"]);
            TempData.Keep();
            Message message = null;
            using (HttpClient client = new HttpClient())
            {
                //Edit Message: To display the Message ie related to MessageId

                string endPoint = _configuration["WebApiBasedUrl"] + "Message/GetMessageById?MessageId=" + id;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        message = JsonConvert.DeserializeObject<Message>(result);

                        //Storing temporary messageId from  tempdata

                        int MESSAGEID = message.id;
                        TempData["messageId"] = MESSAGEID;
                        TempData.Keep();
                    }
                }
            }
            
            return View(message);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Message message)
        {
            //For auto generating values using TempData:

            int Id = Convert.ToInt32(TempData["LoginID"]);
            TempData.Keep();
            int messageId_ = Convert.ToInt32(TempData["messageId"]);
            TempData.Keep();
            message.pId = Id;
            message.createdOn = DateTime.Now;
            message.id = messageId_;

            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                //Editing the message using PUT request 

                StringContent content = new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBasedUrl"] + "Message/UpdateMessage";
                using (var response = await client.PutAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Message details updated sucessfully!!";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong entries!";
                    }
                }
            }
            return View();
        }


        //Fetching messageId to deleting the message
        public async Task<IActionResult> Delete(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBasedUrl"] + "Message/DeleteMessage?MessageId=" + id;

                using (var response = await client.DeleteAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Message details deleted sucessfully!!";
                        return RedirectToAction("Index", "Message");
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong entries!";
                    }
                }
            }
            return View();
        }

    }
}
