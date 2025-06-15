using System.ComponentModel.DataAnnotations;

using dummy_auth.idm.client;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dummy_auth.client1.Pages.Auth {
    public class LoginModel : PageModel {
        private readonly IdManagementApiClient _idmApiClient;
        private const string DEFAULT_RETURN_URL = "/Index";

        public class InputModel {
            [Required]
            public string Username { get; set; } = String.Empty;
            [Required]
            public string Password { get; set; } = String.Empty;
        }

        [BindProperty]
        public InputModel Input { get; set; } = new InputModel();

        public LoginModel(IdManagementApiClient idmApiClient) {
            _idmApiClient = idmApiClient;
        }


        public async Task<IActionResult> OnPost([FromQuery] string? returnUrl) {
            if (ModelState.IsValid) {
                var loginResult = await _idmApiClient.SigninAsync(new UserCredentials {
                    Username = Input.Username,
                    Password = Input.Password
                });
                if (loginResult.Success) {
                    
                    return RedirectToPage(returnUrl ?? DEFAULT_RETURN_URL);
                } else {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
                return RedirectToPage("/Index");
            } else {
                return Page();
            }
        }
    }
}
