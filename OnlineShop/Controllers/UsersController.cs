using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Domains.Users.UserService.Interfaces;
using OnlineShop.Facade.Interfaces;
using OnlineShop.Facade.Models;

namespace OnlineShop.Controllers
{

    public class UsersController : Controller
    {
        private readonly IUsersFacade _userFacade;

        public UsersController(IUsersFacade userFacade)
        {
            _userFacade = userFacade;
        }

        [HttpPost]
        [Route("api/users/signIn")]
        public IActionResult SignIn(string email, string password)
        {
            string key = _userFacade.SignIn(email, password);
            return Ok(key);
        }

        [HttpPost]
        [Route("api/users/signOut")]
        public IActionResult SignOut(string key)
        {
            _userFacade.SignOut(key);
            return Ok();
        }

        [HttpPost]
        [Route("api/users/signUp")]
        public IActionResult SignUp(string firstName, string lastName, string password, string email, string phone, string address)
        {
            User user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Password = password,
                Email = email,
                Phone = phone,
                Address = address
            };

            return Ok(_userFacade.SignUp(user));
        }
        [HttpPost]
        [Route("api/users/validateUser")]
        public IActionResult validateKey(string key)
        {
            try
            {
                var result = _userFacade.ValidateKey(key);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}