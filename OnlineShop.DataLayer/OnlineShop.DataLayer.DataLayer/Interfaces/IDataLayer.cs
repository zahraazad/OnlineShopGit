using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.DataLayer.DataLayer.Interfaces
{
    public interface IDataLayer
    {
        List<T> GetList<T>(string query, Dictionary<string, object> parameters);
        T GetItem<T>(string query, Dictionary<string, object> parameters);
        T AddItem<T>(string query, Dictionary<string, object> parameters);
        T UpdateItem<T>(string query, Dictionary<string, object> parameters);
        void DeleteItem(string query, Dictionary<string, object> parameters);
        T ExecuteScalar<T>(string query, Dictionary<string, object> parameters);
        void ExecuteQuery(string query, Dictionary<string, object> parameters);
    }
}
