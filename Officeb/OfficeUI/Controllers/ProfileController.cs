using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Text;
using System.Threading.Tasks;
using OfficeEntity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace OfficeUI.Controllers
{
    public class ProfileController : Controller
    {
        private IConfiguration _configuration;
        public ProfileController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        [HttpGet]
        public async Task<IActionResult> ShowAllProfiles()
        {
            Profile profile = null;
            using (HttpClient client = new HttpClient())
            {
                int Id = Convert.ToInt32(TempData["LoginID"]);
                TempData.Keep();
                string endpoint = _configuration["WebApiBasedUrl"] + "Profile/GetProfileById?profileId="+Id;
                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        profile = JsonConvert.DeserializeObject<Profile>(result);
                    }
                }
            }
            return View(profile);

        }
        public IActionResult Index2()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(Profile profile)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(profile), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBasedUrl"] + "Profile/Register";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Register successfully!";
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
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Profile profile)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(profile), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBasedUrl"] + "Profile/Login";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        int loginID = JsonConvert.DeserializeObject<int>(result);
                        if (loginID == -1)
                        {
                            ViewBag.status = "Error";
                            ViewBag.message = "Invalid credentials!!";
                        }
                        else
                        {
                            TempData["LoginID"] = loginID.ToString();
                            TempData.Keep();
                            return RedirectToAction("GetFullCount", "MessageCount");
                        }

                    }
                }
            }
            
            return View();
        }
        public async Task<IActionResult> EditOffice()
        {
            Profile profile = new Profile();
            using (HttpClient client = new HttpClient())
            {
                int Id = Convert.ToInt32(TempData["LoginID"]);
                TempData.Keep();
                string endpoint = _configuration["WebApiBasedUrl"] + "Profile/GetProfileById?profileId=" + Id;
                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        profile = JsonConvert.DeserializeObject<Profile>(result);
                    }
                }
            }
            return View(profile);

        }




        [HttpPost]
        public async Task<IActionResult> EditOffice(Profile profiles)
        {
            ViewBag.status = "";

            Profile profile=new Profile();
            using (HttpClient client = new HttpClient())
            {
                int Id = Convert.ToInt32(TempData["LoginID"]);
                TempData.Keep();
                string endpoint = _configuration["WebApiBasedUrl"] + "Profile/GetProfileById?profileId=" + Id;
                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        profile = JsonConvert.DeserializeObject<Profile>(result);
                    }
                }
            }
            profiles.Id = profile.Id;
            profiles.UserName = profile.UserName;
            profiles.Password = profile.Password;
            profiles.Email = profile.Email;
            


            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(profiles), Encoding.UTF8, "application/json");
                string endpoint = _configuration["WebApiBasedUrl"] + "Profile/UpdateProfile";
                
                using (var response = await client.PutAsync(endpoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Office details updated successfully";
                         
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "wrong entries";
                    }
                }
            }
            

            return View(profile);
        
        }
    }
}
