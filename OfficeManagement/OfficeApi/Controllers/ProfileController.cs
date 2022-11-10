using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeBusiness.Service;
using OfficeEntity;

namespace OfficeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private ProfileService _profileservice;
        public ProfileController(ProfileService editprofileservice)
        {
            _profileservice = editprofileservice;
        }

        [HttpPut("UpdateProfile")]
        public IActionResult UpdateProfile([FromBody] Profile profile)
        {
            _profileservice.UpdateProfile(profile);
            return Ok("profile updated successfully");
        }
        [HttpPost("Register")]
        public IActionResult Register([FromBody] Profile profile)
        {
            _profileservice.Register(profile);
            return Ok("Register successfully!!");
        }
        [HttpPost("Login")]
        public IActionResult Login([FromBody] Profile profile)
        {
            Profile profiles = _profileservice.Login(profile);
            if (profiles != null)
                return Ok("Login success!!");
            else
                return NotFound();
        }
    }
}
