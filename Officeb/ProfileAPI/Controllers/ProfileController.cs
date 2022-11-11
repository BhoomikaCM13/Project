using Microsoft.AspNetCore.Mvc;
using Officeb.Services;
using OfficeEntity;
using System.Collections.Generic;

namespace ProfileAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private Profileser _editprofileservice;
        public ProfileController(Profileser editprofileservice)
        {
            _editprofileservice = editprofileservice;
        }
        [HttpPut("UpdateProfile")]
        public IActionResult UpdateProfile([FromBody] Profile profile)
        {
            _editprofileservice.UpdateProfile(profile);
            return Ok("profile updated successfully");
        }
        [HttpPost("Register")]
        public IActionResult Register([FromBody] Profile profile)
        {
            _editprofileservice.Register(profile);
            return Ok("Register successfully!!");
        }
        [HttpPost("Login")]
        public int Login([FromBody] Profile profile)
        {
            int profiles = _editprofileservice.Login(profile);
            return profiles;
/*            if (profiles != null)
                return Ok("Login success!!");
            else
                return NotFound();*/
        }
        [HttpGet("GetProfileById")]
        public Profile GetProfileById(int profileId)
        {
            return _editprofileservice.GetProfileById(profileId);
        }
        [HttpGet("GetProfiles")]
        public IEnumerable<Profile> GetProfiles()
        {
            return _editprofileservice.GetProfiles();
        }
    }
}
