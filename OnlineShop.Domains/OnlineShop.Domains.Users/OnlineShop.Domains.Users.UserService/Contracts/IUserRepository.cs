using OnlineShop.Domains.Users.UsersModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Domains.Users.UserService.Contracts
{
    public interface IUserRepository
    {
        string SignUp(User user);
        //string SignIn(string email, string password);
        void SignOut(string sessionid);
        UserSession GetSessionInfo(Guid sessionid);
        User getUserInfo(string email, string password);
        string createSession(int userId, int sessionDurationHours);
    }
}
