using System;
using System.Collections.Generic;
using System.Text;

namespace OlineShop.Logger.Models
{
    public class Log
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int LogTypeId { get; set; }
        public string Message { get; set; }
        public string SessionKey { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}
