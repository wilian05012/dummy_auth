using dummy_auth.idm.Models;
using dummy_auth.idm.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dummy_auth.idm.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase {
        private readonly SignManager _signManager;

        public AuthenticationController(SignManager signManager) {
            _signManager = signManager;
        }


        [HttpPost("signin")]
        public IActionResult SignIn([FromBody] SystemUser.UserCredentials credentials) {
            if (credentials == null || string.IsNullOrEmpty(credentials.Username) || string.IsNullOrEmpty(credentials.Password)) {
                return BadRequest("Invalid credentials.");
            }

            var result = _signManager.SignIn(credentials);
            if (result.Success) {
                return Ok(_signManager.UserManager.GetUser(result.UserId!.Value));
            } else {
                return Unauthorized(result);
            }
        }
    }
}
