using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeBusiness.Services;
using OfficeEntity;
<<<<<<< HEAD
=======
using System.Collections.Generic;
>>>>>>> fb3f0d99ccdc41457d78ae7d68293daf3b347d3d

namespace OfficeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private ContactService _contactService;
        public ContactController(ContactService contactService)
        {
            _contactService = contactService;
        }
        [HttpPost("AddContact")]
        public IActionResult AddContact([FromBody] Contactus contact)
        {
            #region Add contact
            _contactService.AddContact(contact);
            return Ok("Thank you for your Response.we will get back soon");
            #endregion
        }
<<<<<<< HEAD
=======

        [HttpGet("GetContacts")]
        public IEnumerable<Contactus> GetContacts()
        {
            #region Get Contact :
            return _contactService.GetContacts();
            #endregion
        }
>>>>>>> fb3f0d99ccdc41457d78ae7d68293daf3b347d3d
    }
}
