using Model.Model;
namespace Application.DaoInterfaces;


public abstract class IUserDao
{
    public abstract Task<User>  RegisterAsync(User user);
    public abstract Task<User?> GetByUsernameAsync(string userName);
}