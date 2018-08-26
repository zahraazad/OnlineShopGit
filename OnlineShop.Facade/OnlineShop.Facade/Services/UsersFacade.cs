using AutoMapper;
using OnlineShop.Domains.Users.UserService.Interfaces;
using OnlineShop.Domains.Users.UsersModel;
using OnlineShop.Facade.Interfaces;

namespace OnlineShop.Facade.Services
{
    public class UsersFacade : IUsersFacade
    {
        private readonly IUserService _userService;
        public UsersFacade(IUserService userService)
        {
            _userService = userService;
        }
        public string SignIn(string email, string password)
        {
            return _userService.SignIn(email, password);
        }

        public void SignOut(string key)
        {
            _userService.SignOut(key);
        }

        public string SignUp(Models.User user)
        {
            User usersModel = Mapper.Map<Models.User, User>(user);
            return _userService.SignUp(usersModel);
        }

        public bool ValidateKey(string key)
        {
            return _userService.ValidateKey(key);
        }
        public int getLoggedOnUserId(string key)
        {
            return _userService.getLoggedOnUserId(key);
        }
    }
}
