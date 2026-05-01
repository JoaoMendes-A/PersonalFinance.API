using PersonalFinance.Api.Models.Users;

namespace PersonalFinance.Api.Services.Auth;

public interface IAuthServices
{
    public Task<User> RegisterUser(User user, string password);
    public Task<string?> Login(string email, string password);
    public Task<User?> GetUserById(int id);
}