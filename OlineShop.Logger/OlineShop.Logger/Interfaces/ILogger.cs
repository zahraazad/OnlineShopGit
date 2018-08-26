using OlineShop.Logger.Enums;
using OlineShop.Logger.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OlineShop.Logger.Interfaces
{
    public interface ILogger
    {
        Log LogError(string sessionId, LogEvents eventId, string logMessage);
        Log LogInfo(string sessionId, LogEvents eventId, string logMessage);
    }
}
