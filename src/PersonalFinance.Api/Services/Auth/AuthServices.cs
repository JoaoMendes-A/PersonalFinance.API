using BCrypt.Net;
using PersonalFinance.Api.Models.Users;
using PersonalFinance.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace PersonalFinance.Api.Services.Auth;

public class AuthServices : IAuthServices
{
    private readonly AppDbContext _context;
    public AuthServices(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Converete a senha em hash
    /// </summary>
    
    private string ConvertToHash(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    /// <summary>
    /// Registra novo usuario
    /// </summary>

    public async Task<User> RegisterUser(User user, string password)
    {
        user.HashPassword = ConvertToHash(password);
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return user;
    }

    /// <summary>
    /// Valida login de usuario 
    /// </summary>

    public async Task<User?> Login(string email, string password)
    {

    var user = await _context.Users
        .FirstOrDefaultAsync(u => u.Email == email);

    if (user == null)
    {
        return null;
    }

    bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, user.HashPassword);

    if (!isPasswordValid)
    {
        return null;
    }

    return user;
    }

    /// <summary>
    /// Retorna um usuario filtrada pelo ID
    /// </summary>

    public async Task<User?> GetUserById(int id)
    {
        return await _context.Users.FindAsync(id);
    }
}