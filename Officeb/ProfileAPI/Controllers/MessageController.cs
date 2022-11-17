using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Officeb.Services;
using OfficeEntity;
using System.Collections.Generic;

namespace ProfileAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private MessageService _Messageservice;
        public MessageController(MessageService Messageservice)
        {
            _Messageservice = Messageservice;
        }
        [HttpGet("GetMessages")]
        public IEnumerable<Message> GetMessages()
        {
            return _Messageservice.GetMessages();
        }
        [HttpGet("GetMessageById")]
        public Message GetMessageById(int MessageId)
        {
            return _Messageservice.GetMessageById(MessageId);
        }
        [HttpPost("AddMessage")]
        public IActionResult AddMessage([FromBody] Message Message)
        {
            _Messageservice.AddMessage(Message);
            return Ok("Message created successfully");
        }
        [HttpDelete("DeleteMessage")]
        public IActionResult DeleteMessage(int MessageId)
        {
            _Messageservice.DeleteMessage(MessageId);
            return Ok("Message deleted successfully!!!");
        }
        [HttpPut("UpdateMessage")]
        public IActionResult UpdateMessage([FromBody] Message Message)
        {
            _Messageservice.UpdateMessage(Message);
            return Ok("Message updated successfully");
        }

        
    }
}
