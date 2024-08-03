using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace GessiWebApp.Web.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            public string Username { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Logica per l'autenticazione tramite l'API o il servizio di autenticazione.
            // Simulazione di autenticazione:
            var authenticated = await AuthenticateUser(Input.Username, Input.Password);
            if (!authenticated)
            {
                ModelState.AddModelError(string.Empty, "Tentativo di accesso non valido.");
                return Page();
            }

            return RedirectToPage(returnUrl ?? "/Index");
        }

        private Task<bool> AuthenticateUser(string username, string password)
        {
            // Implementare chiamata API per autenticazione qui
            return Task.FromResult(true);
        }
    }
}
