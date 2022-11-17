using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Officeb.Services;
using OfficeEntity;
using System.Collections.Generic;

namespace ProfileAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private CommentService _commentservice;
        public CommentController(CommentService commentservice)
        {
            _commentservice = commentservice;
        }
        [HttpGet("GetComments")]
        public IEnumerable<Comment> GetComments()
        {
            return _commentservice.GetComments();
        }
        [HttpGet("GetCommentById")]
        public Comment GetCommentById(int commentId)
        {
            return _commentservice.GetCommentById(commentId);
        }
        [HttpPost("AddComment")]
        public IActionResult AddComment([FromBody] Comment comment)
        {
            _commentservice.AddComment(comment);
            return Ok("comment created successfully");
        }
        [HttpDelete("DeleteComment")]
        public IActionResult DeleteComment(int commentId)
        {
            _commentservice.DeleteComment(commentId);
            return Ok("Comment deleted successfully!!!");
        }
        [HttpPut("UpdateComment")]
        public IActionResult UpdateComment([FromBody] Comment comment)
        {
            _commentservice.UpdateComment(comment);
            return Ok("comment updated successfully");
        }

        [HttpGet("GetCommentsByTaskId")]
        public IEnumerable<Comment> GetCommentsByTaskId(int taskId)
        {
          return  _commentservice.GetCommentsByTaskId(taskId);
        }
    }
}



