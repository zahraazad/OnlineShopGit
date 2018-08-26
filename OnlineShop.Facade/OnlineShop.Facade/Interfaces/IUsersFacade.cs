using OnlineShop.Facade.Models;

namespace OnlineShop.Facade.Interfaces
{
    public interface IUsersFacade
    {
        string SignUp(User user);
        string SignIn(string email, string password);
        void SignOut(string key);
        bool ValidateKey(string key);
        int getLoggedOnUserId(string key);
    }
}
