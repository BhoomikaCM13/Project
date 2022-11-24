using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using OfficeEntity;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OfficeUI.Controllers
{
    public class CommentController : Controller
    {
        private IConfiguration configuration;
        Tasks task = new Tasks();
        Comment comment = new Comment();
        public CommentController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
       
        [HttpGet]
        public async Task<IActionResult> Index()
        {
          
            IEnumerable<Comment> result = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = configuration["WebApiBasedUrl"] + "Comment/GetComments";
                    using (var response = await client.GetAsync(endPoint))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var result1 = await response.Content.ReadAsStringAsync();
                            result = JsonConvert.DeserializeObject<IEnumerable<Comment>>(result1);
                        }
                    }
                }
                return View(result);
            }
        
        public IActionResult CreateComment()
        {
             
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(Comment comment)
        {
            int ProfileId = Convert.ToInt32(TempData["LoginID"]);
            TempData.Keep();
            comment.PId = ProfileId;
            comment.CreatedOn = DateTime.UtcNow;
            int taskId_ = Convert.ToInt32(TempData["TaskId"]);
            TempData.Keep();
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
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Oops!";
                    }
                }
            }
            return View();
        }
        public async Task<IActionResult> EditComment(int Id)
        {
            Comment comment = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = configuration["WebApiBasedUrl"] + "Comment/GetCommentById?commentId=" + Id;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        comment = JsonConvert.DeserializeObject<Comment>(result);

                        //Get temporary coomentid from  tempdata
                        int commentId = comment.Id;
                        TempData["_commentid"] = commentId;
                        TempData.Keep();


                    }
                }
            }
            return View(comment);
        }

        [HttpPost]
        public async Task<IActionResult> EditComment(Comment comment)
        {
            int ProfileId = Convert.ToInt32(TempData["LoginID"]);
            TempData.Keep();
            int commentid_ = Convert.ToInt32(TempData["_commentid"]);
            TempData.Keep();
            comment.PId = ProfileId;
            comment.CreatedOn = DateTime.UtcNow;
            comment.Id = commentid_;
            int taskId_ = Convert.ToInt32(TempData["TaskId"]);
            TempData.Keep();
            comment.taskId= taskId_;
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                
                    StringContent content = new StringContent(JsonConvert.SerializeObject(comment), Encoding.UTF8, "application/json");
                    string endPoint = configuration["WebApiBasedUrl"] + "Comment/UpdateComment";
                    using (var response = await client.PutAsync(endPoint, content))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            ViewBag.status = "Ok";
                            ViewBag.message = "Saved Successfully";
                        }
                        else
                        {
                            ViewBag.status = "Error";
                            ViewBag.message = "Oops";
                        }
                    }
                }
                return View();
            }
        
        //public async Task<IActionResult> DeleteComment(int Id)
        //{
        //    Comment comment = null;
        //    using (HttpClient client = new HttpClient())
        //    {
        //        string endPoint = configuration["WebApiBasedUrl"] + "Comment/GetCommentById?commentId=" + Id;
        //        using (var response = await client.GetAsync(endPoint))
        //        {
        //            if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //            {
        //                var result = await response.Content.ReadAsStringAsync();
        //                comment = JsonConvert.DeserializeObject<Comment>(result);
        //            }
        //        }
        //    }
        //    return View(comment);
        //}


    
        public async Task<IActionResult> DeleteComment(int commentid)
        {

            ViewBag.status = "";
            using (HttpClient client = new HttpClient())

            {
              
                    string endPoint = configuration["WebApiBasedUrl"] + "Comment/DeleteComment?commentId=" + commentid;
                    using (var response = await client.DeleteAsync(endPoint))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            ViewBag.status = "Ok";
                            ViewBag.message = "Done";
                            return RedirectToAction("Index", "Task");

                        }
                        else
                        {
                            ViewBag.status = "Error";
                            ViewBag.message = "wrong entries";
                        }
                    }
                }
                return View();
           }
        

        //[HttpGet]
        //public async Task<IActionResult> GetCommentsByTaskId(int taskId)
        //{ 
        //    IEnumerable<Comment> result = null;
        //    using (HttpClient client = new HttpClient())
        //    {


        //        if (task.Id == comment.TaskId)
        //        {
        //            string endPoint = configuration["WebApiBasedUrl"] + "Comment/GetCommentsByTaskId?taskId="+taskId;
        //            using (var response = await client.GetAsync(endPoint))
        //            {
        //                if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //                {
        //                    var result1 = await response.Content.ReadAsStringAsync();
        //                    result = JsonConvert.DeserializeObject<IEnumerable<Comment>>(result1);
        //                }
        //            }
        //        }
        //        return View(result);
        //    }



        }

    }

