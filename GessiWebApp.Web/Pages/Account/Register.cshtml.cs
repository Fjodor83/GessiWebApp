using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace GessiWebApp.Web.Pages.Account
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            public string Username { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "Le password non corrispondono.")]
            public string ConfirmPassword { get; set; }

            [Required]
            public string Role { get; set; }
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Registrazione tramite API (simulazione per esempio)
            var registered = await RegisterUser(Input.Username, Input.Password, Input.Role);
            if (!registered)
            {
                ModelState.AddModelError(string.Empty, "Registrazione fallita.");
                return Page();
            }

            return RedirectToPage("/Index");
        }

        private Task<bool> RegisterUser(string username, string password, string role)
        {
            // Implementare chiamata API per registrazione qui
            return Task.FromResult(true);
        }
    }
}
