using Microsoft.AspNetCore.Mvc;
using OfficeBusiness.Services;
using OfficeEntity;
using System.Collections.Generic;

namespace ProfileAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private Profileservice _editProfileService;
        public ProfileController(Profileservice editProfileService)
        {
            _editProfileService = editProfileService;
        }
        [HttpPut("UpdateProfile")]
        public IActionResult UpdateProfile([FromBody] Profile profile)
        {
            #region Edit Profile:
            _editProfileService.UpdateProfile(profile);
            return Ok("profile updated successfully");
            #endregion
        }
        [HttpPost("Register")]
        public IActionResult Register([FromBody] Profile profile)
        {
            #region Register
            _editProfileService.Register(profile);
            return Ok("Register successfully!!");
            #endregion
        }
        [HttpPost("Login")]
        public int Login([FromBody] Profile profile)
        {
            #region Login
            int profiles = _editProfileService.Login(profile);
            return profiles;
            #endregion
        }
        [HttpGet("GetProfileById")]
        public Profile GetProfileById(int profileId)
        {
            #region Get Profile By Id
            return _editProfileService.GetProfileById(profileId);
            #endregion
        }
        [HttpGet("GetProfiles")]
        public IEnumerable<Profile> GetProfiles()
        {
            #region Get Profile:
            return _editProfileService.GetProfiles();
            #endregion
        }
    }
}
