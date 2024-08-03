using GessiWebApp.Api.Models;

namespace GessiWebApp.Api.Services
{
    public interface IAuthService
    {
        Task<AuthResult> RegisterAsync(RegisterModel model);
        Task<AuthResult> LoginAsync(LoginModel model);
        Task<bool> RegisterUser(string username, string email, string password);
        Task<string> Login(string username, string password);
    }

    public class AuthResult
    {
        public bool Succeeded { get; set; }
        public string Token { get; set; }
        public string Message { get; set; }
    }
}