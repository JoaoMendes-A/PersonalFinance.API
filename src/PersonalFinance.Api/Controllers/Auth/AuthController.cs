using PersonalFinance.Api.Data;
using PersonalFinance.Api.Services.Auth;
using PersonalFinance.Api.DTOs.User;
using PersonalFinance.Api.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace PersonalFinance.Api.Controllers.Auth;


[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthServices _authServices;
    private readonly AppDbContext _context;

    public AuthController(IAuthServices authServices, AppDbContext context)
    {
        _authServices = authServices;
        _context = context;
    }

    public async Task<IActionResult> RegisterUser(CreateUserDto dto)
    {
        var user = new User
        {
            UserName = dto.UserName,
            Email = dto.Email,
        };

        var registerUser = await _authServices.RegisterUser(user, dto.Password);
        return Created("", registerUser);
    }

    public async Task<IActionResult> Login(string email, string password)
    {
        var validateLogin = await _authServices.Login(email, password);

        if (validateLogin == null)
        return NotFound();

        return Ok();
    }

    public async Task<IActionResult> GetById(int id)
    {
        var user = _authServices.GetUserById(id);

        if (user == null)
            return NotFound();

        return Ok(user);
    }
}