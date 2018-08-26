using OnlineShop.Domains.Users.UsersModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Domains.Users.UserService.Interfaces
{
    public interface IUserService
    {
        string SignUp(User user);
        string SignIn(string email, string password);
        void SignOut(string sessionid);
        bool ValidateKey(string sessionid);
        int getLoggedOnUserId(string sessionid);
    }
}
