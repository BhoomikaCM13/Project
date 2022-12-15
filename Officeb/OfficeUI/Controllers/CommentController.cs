using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using OfficeDL.Repository;
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
        private CommentRepository commentRepository;
        public CommentController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }



        public async Task<IActionResult> EditComment(int id)
        {
            Comment comment = null;
            using (HttpClient client = new HttpClient())
            {
                //Edit Comment: To display the comments ie related to commentId
                string endPoint = configuration["WebApiBasedUrl"] + "Comment/GetCommentById?commentId=" + id;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        comment = JsonConvert.DeserializeObject<Comment>(result);

                        //Get temporary commentid from  tempdata
                        int commentId = comment.id;
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
            //For auto generating values using TempData:
            int ProfileId = Convert.ToInt32(TempData["LoginID"]);
            TempData.Keep();
            int commentid_ = Convert.ToInt32(TempData["_commentid"]);
            TempData.Keep();
            comment.profileId = ProfileId;
            comment.createdOn = DateTime.Now;
            comment.id = commentid_;
            int taskId_ = Convert.ToInt32(TempData["taskId_"]);
            TempData.Keep();
            comment.taskId = taskId_;
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                   //Editing the comment using PUT request 
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
        public async Task<IActionResult> DeleteComment(int commentid)
        {
            TempData.Keep();

            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                    //Fetching commentId to deleting the comment
                    string endPoint = configuration["WebApiBasedUrl"] + "Comment/DeleteComment?commentId=" + commentid;
                    using (var response = await client.DeleteAsync(endPoint))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            ViewBag.status = "Ok";
                            ViewBag.message = "Done";
                            return RedirectToAction("Index", "TaskBoard");
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
    }
}

