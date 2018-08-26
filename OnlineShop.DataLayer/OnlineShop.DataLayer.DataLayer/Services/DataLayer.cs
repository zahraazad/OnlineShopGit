using Dapper;
using OnlineShop.DataLayer.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace OnlineShop.DataLayer.DataLayer
{
    public class DataLayer : IDataLayer
    {
        private IDbConnection db;
        private readonly ISQLConnectionFactory _onnectionFactory;
        public DataLayer(ISQLConnectionFactory connectionFactory)
        {
            _onnectionFactory = connectionFactory;
        }
        public List<T> GetList<T>(string query, Dictionary<string, object> parameters)
        {
            db = _onnectionFactory.Create();
            DynamicParameters dynamicParameters = new DynamicParameters();

            foreach (var param in parameters)
            {
                dynamicParameters.Add(param.Key, param.Value);
            }
            using (db)
            {
                return db.Query<T>(query, parameters, null, true, null, CommandType.StoredProcedure).ToList();
            }
        }
        public T GetItem<T>(string query, Dictionary<string, object> parameters)
        {
            db = _onnectionFactory.Create();
            DynamicParameters dynamicParameters = new DynamicParameters();

            foreach (var param in parameters)
            {
                dynamicParameters.Add(param.Key, param.Value);
            }
            using (db)
            {
                return db.QueryFirstOrDefault<T>(query, dynamicParameters, null, null, CommandType.StoredProcedure);
            }
        }
        public T AddItem<T>(string query, Dictionary<string, object> parameters)
        {
            db = _onnectionFactory.Create();
            DynamicParameters dynamicParameters = new DynamicParameters();

            foreach (var param in parameters)
            {
                dynamicParameters.Add(param.Key, param.Value);
            }
            using (db)
            {
                return db.QueryFirstOrDefault<T>(query, dynamicParameters, null, null, CommandType.StoredProcedure);
            }
        }
        public T UpdateItem<T>(string query, Dictionary<string, object> parameters)
        {
            db = _onnectionFactory.Create();
            DynamicParameters dynamicParameters = new DynamicParameters();

            foreach (var param in parameters)
            {
                dynamicParameters.Add(param.Key, param.Value);
            }
            using (db)
            {
                return db.ExecuteScalar<T>(query, dynamicParameters, null, null, CommandType.StoredProcedure);
            }
        }
        public void DeleteItem(string query, Dictionary<string, object> parameters)
        {
            db = _onnectionFactory.Create();
            DynamicParameters dynamicParameters = new DynamicParameters();

            foreach (var param in parameters)
            {
                dynamicParameters.Add(param.Key, param.Value);
            }
            using (db)
            {
                db.Execute(query, dynamicParameters, null, null, CommandType.StoredProcedure);
            }
        }
        public T ExecuteScalar<T>(string query, Dictionary<string, object> parameters)
        {
            db = _onnectionFactory.Create();
            DynamicParameters dynamicParameters = new DynamicParameters();

            foreach (var param in parameters)
            {
                dynamicParameters.Add(param.Key, param.Value);
            }
            using (db)
            {
                return db.ExecuteScalar<T>(query, dynamicParameters, null, null, CommandType.StoredProcedure);
            }
        }
        public void ExecuteQuery(string query, Dictionary<string, object> parameters)
        {
            db = _onnectionFactory.Create();
            DynamicParameters dynamicParameters = new DynamicParameters();

            foreach (var param in parameters)
            {
                dynamicParameters.Add(param.Key, param.Value);
            }
            using (db)
            {
                db.Execute(query, dynamicParameters, null, null, CommandType.StoredProcedure);
            }
        }
    }
}
