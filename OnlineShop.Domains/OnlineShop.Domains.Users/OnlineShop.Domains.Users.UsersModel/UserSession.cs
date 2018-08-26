using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Domains.Users.UsersModel
{
    public class UserSession
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public Guid SessionId { get; set; }
        public DateTime SessionCreateDateTime { get; set; }
        public DateTime? SessionEndDateTime { get; set; }
        public DateTime SessionExpireDateTime { get; set; }
    }
}
