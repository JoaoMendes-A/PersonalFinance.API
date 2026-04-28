using BCrypt.Net;
using PersonalFinance.Api.Models.User;
using PersonalFinance.Api.Data;

namespace PersonalFinance.Api.Services.Auth;

public class AuthServices : IAuthServices
{
    private readonly AppDbContext _context;
    public AuthServices(AppDbContext context)
    {
        _context = context;
    }

    public static string ConvertToHash(string password)
    {
        string hash = BCrypt.Net.BCrypt.HashPassword(password);

        return hash;
    }

    public async Task<User> AddUser(User user)
    {
        await _context.AddAsync(user);
        await _context.SaveChangesAsync();

        return user;
    }
}