using OnlineShop.DataLayer.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace OnlineShop.DataLayer.DataLayer.Services
{
    public class SQLConnectionFactory : ISQLConnectionFactory
    {
        private readonly string _connectionString = string.Empty;
        public SQLConnectionFactory(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentNullException("Connection string required!");
            }
            _connectionString = connectionString;
        }
        public SqlConnection Create()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
