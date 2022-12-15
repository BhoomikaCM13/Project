using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeBusiness.Services;
using OfficeEntity;
using System.Collections.Generic;

namespace OfficeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private MessageService _messageService;
        public MessageController(MessageService messageService)
        {
            _messageService = messageService;
        }
        [HttpGet("GetMessages")]
        public IEnumerable<Message> GetMessages()
        {

            #region Get Message
            return _messageService.GetMessages();
            #endregion
        }


                #region Get Message
                return _messageService.GetMessages();
                #endregion
            }
        

        [HttpGet("GetMessageById")]
        public Message GetMessageById(int messageId)
        {
            #region Get Message By Id:
            return _messageService.GetMessageById(messageId);
            #endregion
        }
        [HttpPost("AddMessage")]
        public IActionResult AddMessage([FromBody] Message message)
        {

            #region Add Message:
            _messageService.AddMessage(message);
            return Ok("Message created successfully");
            #endregion

            try
            {
                #region Add Message:
                _messageService.AddMessage(message);
                return Ok("Message created successfully");
                #endregion
            }
            catch
            {
                return BadRequest(400);
            }
>>>>>>> fb3f0d99ccdc41457d78ae7d68293daf3b347d3d
        }
        [HttpDelete("DeleteMessage")]
        public IActionResult DeleteMessage(int messageId)
        {

            #region Delete Message
            _messageService.DeleteMessage(messageId);
            return Ok("Message deleted successfully!!!");
            #endregion

            try
            {
                #region Delete Message
                _messageService.DeleteMessage(messageId);
                return Ok("Message deleted successfully!!!");
                #endregion
            }
            catch
            {
                return BadRequest(400);
            }

        }
        [HttpPut("UpdateMessage")]
        public IActionResult UpdateMessage([FromBody] Message message)
        {

            #region Edit Message
            _messageService.UpdateMessage(message);
            return Ok("Message updated successfully");
            #endregion

            try
            {
                #region Edit Message
                _messageService.UpdateMessage(message);
            return Ok("Message updated successfully");
                #endregion
            }
            catch
            {
                return BadRequest(400);
            }
        }


    }
}
