using GessiWebApp.Web.Models;

namespace GessiWebApp.Web.Services
{
    public interface IAuthService
    {
        Task<AuthResult> Register(RegisterModel model);
        Task<AuthResult> Login(LoginModel model);
    }

    public class AuthResult
    {
        public bool Succeeded { get; set; }
        public string Token { get; set; }
        public string Message { get; set; }
    }
}