using OlineShop.Logger.Enums;
using OlineShop.Logger.Interfaces;
using OlineShop.Logger.Models;
using OnlineShop.DataLayer.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OlineShop.Logger.Services
{
    public class SqlLogger : ILogger
    {
        private readonly IDataLayer _dataLayer;
        public SqlLogger(IDataLayer dataLayer)
        {
            _dataLayer = dataLayer;
        }

        public Log LogError(string sessionId, LogEvents eventId, string logMessage)
        {
            return AddLog(sessionId, eventId, logMessage, LogTypes.Error);
        }

        private Log AddLog(string sessionId, LogEvents eventId, string logMessage, LogTypes logType)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("EventId", eventId);
            parameters.Add("SessionId", sessionId);
            parameters.Add("Message", logMessage);
            parameters.Add("LogTypeId", logType);
            return _dataLayer.AddItem<Log>("sp_OnlineShop_Log", parameters);
        }

        public Log LogInfo(string sessionId, LogEvents eventId, string logMessage)
        {
            return AddLog(sessionId, eventId, logMessage, LogTypes.Info);

        }

    }
}
