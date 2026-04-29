
namespace PersonalFinance.Api.Services.Auth;
using PersonalFinance.Api.Models.Users;

public interface IAuthServices
{
    public Task<User> RegisterUser(User user, string password);
}