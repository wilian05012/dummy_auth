using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dummy_auth.client1.Pages.Auth {
    public class LoginModel : PageModel {
        public class InputModel {
            [Required]
            public string Username { get; set; } = String.Empty;
            [Required]
            public string Password { get; set; } = String.Empty;
        }

        [BindProperty]
        public InputModel Input { get; set; } = new InputModel();

        public IActionResult OnPost() {
            if (ModelState.IsValid) {
                return RedirectToPage("/Index");
            } else {
                return Page();
            }
        }
    }
}
