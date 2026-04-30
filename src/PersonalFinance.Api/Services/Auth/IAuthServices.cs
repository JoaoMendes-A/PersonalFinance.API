
namespace PersonalFinance.Api.Services.Auth;
using PersonalFinance.Api.Models.Users;

public interface IAuthServices
{
    public Task<User> RegisterUser(User user, string password);
    public Task<User?> Login(string email, string password);
    public Task<User?> GetUserById(int id);
}