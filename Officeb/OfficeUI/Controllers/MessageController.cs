using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using OfficeDL;
using OfficeEntity;
using System;
using System.Collections.Generic;
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

        public ActionResult Index(string searchtitle)
        {
            var projects = from pr in db.messages.
                           Include(obj=>obj.Profile
                           )
                           select pr;

            if (!String.IsNullOrEmpty(searchtitle))
            {
                projects = projects.Where(c => c.Title.Contains(searchtitle));
            }
            return View(projects); 
           

        }



      


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Message> messageresult = null;
            using (HttpClient client = new HttpClient())
            {
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
            return View(messageresult);
        }

  
       

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Message message)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
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
        public async Task<IActionResult> Edit(int Id)
        {
            Message message = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBasedUrl"] + "Message/GetMessageById?MessageId=" + Id;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        message = JsonConvert.DeserializeObject<Message>(result);
                    }
                }
            }
            return View(message);



        }

        [HttpPost]
        public async Task<IActionResult> Edit(Message message)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
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
        public async Task<IActionResult> Delete(int Id)
        {
            Message message = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBasedUrl"] + "Message/GetMessageById?MessageId=" + Id;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        message = JsonConvert.DeserializeObject<Message>(result);
                    }
                }
            }
            return View(message);
        }



        [HttpPost]
        public async Task<IActionResult> Delete(Message message)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBasedUrl"] + "Message/DeleteMessage?MessageId=" + message.Id;



                using (var response = await client.DeleteAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Message details deleted sucessfully!!";
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
