using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeBusiness.Services;
using OfficeDL.Repository;
using OfficeEntity;
using System;
using System.Collections.Generic;

namespace OfficeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private CommentService _commentService;

        public CommentController(CommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("GetComments")]
        public IEnumerable<Comment> GetComments()
        {
            #region Get Comment :
            return _commentService.GetComments();
            #endregion
        }
        [HttpGet("GetCommentById")]
        public Comment GetCommentById(int commentId)
        {
            #region Get Comment By Id:
            return _commentService.GetCommentById(commentId);
            #endregion

        }
        [HttpPost("AddComment")]
        public IActionResult AddComment([FromBody] Comment comment)
        {
            #region Add Comment
            _commentService.AddComment(comment);
            return Ok("comment created successfully");
            #endregion
        }
        [HttpDelete("DeleteComment")]
        public IActionResult DeleteComment(int commentId)
        {
            #region Delete Comment
            _commentService.DeleteComment(commentId);
            return Ok("Comment deleted successfully!!!");
            #endregion
        }
        [HttpPut("UpdateComment")]
        public IActionResult UpdateComment([FromBody] Comment comment)
        {
            #region Edit comment 
            _commentService.UpdateComment(comment);
            return Ok("comment updated successfully");
            #endregion
        }
    }
}



