using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System;
using OfficeEntity;
using Microsoft.Extensions.Configuration;
using OfficeDL;

namespace OfficeUI.Controllers
{
    public class ContactController : Controller
    {
        private IConfiguration _configuration;

        public ContactController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult CreateContact()
        {
            return View();
        }

<<<<<<< HEAD

        [HttpPost]
        public async Task<IActionResult> CreateContact(Contactus message)
=======
       
        [HttpPost]
        public async Task<IActionResult> CreateContact(Contactus contact)
>>>>>>> fb3f0d99ccdc41457d78ae7d68293daf3b347d3d
        {
            
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                //Add Messages 

<<<<<<< HEAD
                StringContent content = new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8, "application/json");
=======
                StringContent content = new StringContent(JsonConvert.SerializeObject(contact), Encoding.UTF8, "application/json");
>>>>>>> fb3f0d99ccdc41457d78ae7d68293daf3b347d3d
                string endPoint = _configuration["WebApiBasedUrl"] + "Contact/AddContact";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "success";
                        return RedirectToAction("Index", "Home");
<<<<<<< HEAD
=======
                       
>>>>>>> fb3f0d99ccdc41457d78ae7d68293daf3b347d3d
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
