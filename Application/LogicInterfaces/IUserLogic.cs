using Model.DTOs;
using Model.Model;

namespace Application.LogicInterfaces;

public class IUserLogic
{
    Task<User> RegisterAsync(UserRegistrationDTO userToRegister)
    {
        throw new NotImplementedException();
    }

    Task<User> ValidateUserAsync(string username, string password)
    {
        throw new NotImplementedException();
    }
}