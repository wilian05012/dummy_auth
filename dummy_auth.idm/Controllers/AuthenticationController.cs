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
        [Produces(System.Net.Mime.MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SignManager.SignInResult))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(SignManager.SignInResult))]
        public ActionResult<SignManager.SignInResult> SignIn([FromBody] SystemUser.UserCredentials credentials) {
            if (credentials == null || string.IsNullOrEmpty(credentials.Username) || string.IsNullOrEmpty(credentials.Password)) {
                return BadRequest("Invalid credentials.");
            }

            var result = _signManager.SignIn(credentials);
            if (result.Success) {
                return Ok(result);
            } else {
                return Unauthorized(result);
            }
        }
    }
}
