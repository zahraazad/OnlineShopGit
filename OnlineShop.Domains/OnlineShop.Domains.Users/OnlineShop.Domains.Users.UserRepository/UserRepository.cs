using OnlineShop.DataLayer.DataLayer.Interfaces;
using OnlineShop.Domains.Users.UserService.Contracts;
using OnlineShop.Domains.Users.UsersModel;
using System;
using System.Collections.Generic;

namespace OnlineShop.Domains.Users.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly IDataLayer _dataLayer;
        public UserRepository(IDataLayer dataLayer)
        {
            _dataLayer = dataLayer;
        }

        public UserSession GetSessionInfo(Guid sessionid)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("SessionId", sessionid);
            return _dataLayer.GetItem<UserSession>("sp_OnlineShop_GetUserSessionInfo", parameters);
        }

        public User getUserInfo(string email, string password)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("Email", email);
            parameters.Add("Password", password);
            return _dataLayer.GetItem<User>("sp_OnlineShop_GetUserInfo", parameters);
        }

        public string createSession(int userId, int sessionDurationHours)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("userId", userId);
            parameters.Add("sessionDurationHours", sessionDurationHours);
            var result = _dataLayer.ExecuteScalar<string>("sp_OnlineShop_CreateNewUserSession", parameters);

            return result?.ToString();
        }

        public void SignOut(string sessionid)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("SessionId", sessionid);
            _dataLayer.ExecuteQuery("sp_OnlineShop_EndUserSessionBySessionId", parameters);
        }

        public string SignUp(User user)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            foreach (var prop in user.GetType().GetProperties())
            {
                if (prop.Name != "Id")
                    parameters.Add(prop.Name, prop.GetValue(user));
            }
            return _dataLayer.AddItem<string>("sp_OnlineShop_AddNewUser", parameters);
        }
    }
}
