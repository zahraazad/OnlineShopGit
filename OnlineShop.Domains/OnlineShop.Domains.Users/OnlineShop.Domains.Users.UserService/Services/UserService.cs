using OnlineShop.Domains.Users.UserService.Contracts;
using OnlineShop.Domains.Users.UserService.Interfaces;
using OnlineShop.Domains.Users.UsersModel;
using System;

namespace OnlineShop.Domains.Users.UserService.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly int _sessionDurationHours;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _sessionDurationHours = 2;
        }
        private User getUserInfo(string email, string password)
        {

            return _userRepository.getUserInfo(email, password);
        }
        public string SignIn(string email, string password)
        {
            try
            {
                User user = this.getUserInfo(email, password);
                if (user == null)
                    throw new Exception("Invalid Username or Password.");
                return _userRepository.createSession(user.Id, _sessionDurationHours);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void SignOut(string sessionid)
        {
            try
            {
                _userRepository.SignOut(sessionid);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string SignUp(User user)
        {
            try
            {
                return _userRepository.SignUp(user);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool ValidateKey(string sessionid)
        {
            try
            {
                if (sessionid == null)
                    return false;
                UserSession userSession = _userRepository.GetSessionInfo(Guid.Parse(sessionid));
                if (userSession == null)
                    return false;
                if (userSession.SessionEndDateTime != null || userSession.SessionExpireDateTime <= DateTime.Now)
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public int getLoggedOnUserId(string sessionid)
        {
            try
            {
                UserSession userSession = _userRepository.GetSessionInfo(Guid.Parse(sessionid));
                if (userSession == null)
                    throw new UnauthorizedAccessException();
                if (userSession.SessionEndDateTime != null || userSession.SessionExpireDateTime <= DateTime.Now)
                    throw new UnauthorizedAccessException();

                return userSession.UserId;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
