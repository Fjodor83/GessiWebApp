using GessiWebApp.Api.Models;
using GessiWebApp.Api.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _authService.RegisterUser(model.Username, model.Email, model.Password);
        if (!result)
            return BadRequest("Username already exists");

        return Ok("User registered successfully");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var token = await _authService.Login(model.Username, model.Password);
        if (token == null)
            return Unauthorized("Invalid username or password");

        return Ok(new { Token = token });
    }
}