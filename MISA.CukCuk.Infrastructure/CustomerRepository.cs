using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.CukCuk.ApplicationCore.Entities;
using MISA.CukCuk.ApplicationCore.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MISA.CukCuk.Infrastructure
{
    public class CustomerRepository : ICustomerRepository
    {
        #region Declare
        IConfiguration _configuration;
        string _connectionString = string.Empty;
        IDbConnection _dbConnection = null;
        #endregion

        #region Constructor
        public CustomerRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("MISACukCukConnectionString");
            _dbConnection = new MySqlConnection(_connectionString);
        }
        #endregion

        #region Method
        public int AddCustomer(Customer customer)
        {
            //Khởi tạo kết nối với Database
            var parameters = MappingDbType(customer);
            //Thực thi commandText
            var rowAffect = _dbConnection.Execute("Proc_InsertCustomer", parameters, commandType: CommandType.StoredProcedure);
            //Trả về số bản ghi thêm mới được
            return rowAffect;
        }

        public int DeleteCustomerById(Guid customerId)
        {
            var rowAffects = _dbConnection.Execute("Proc_DeleteCustomerById", new { CustomerId = customerId.ToString() }, commandType: CommandType.StoredProcedure);
            return rowAffects;
        }

        public int UpdateCustomer(Customer customer)
        {
            //Khởi tạo kết nối với Database
            var parameters = MappingDbType(customer);
            //Thực thi commandText
            var rowAffects = _dbConnection.Execute("Proc_UpdateCustomerByCode", parameters, commandType: CommandType.StoredProcedure);
            //Trả về số bản ghi sửa được
            return rowAffects;
        }

        public int DeleteCustomerByCode(string customerCode)
        {
            var rowAffects = _dbConnection.Execute("Proc_DeleteCustomerByCode", new { CustomerCode = customerCode }, commandType: CommandType.StoredProcedure);
            return rowAffects;
        }

        public IEnumerable<Customer> GetCustomerById(Guid customerId)
        {
            var customer = _dbConnection.Query<Customer>("Proc_GetCustomerById", new { CustomerId = customerId.ToString() }, commandType: CommandType.StoredProcedure);
            return customer;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            //Khởi tạo các commandText
            var customers = _dbConnection.Query<Customer>("Proc_GetCustomers", commandType: CommandType.StoredProcedure);
            return customers;
        }

        public IEnumerable<Customer> GetCustomersByCode(string customerCode)
        {
            var res = _dbConnection.Query<Customer>("Proc_GetCustomerByCode", new { CustomerCode = customerCode }, commandType: CommandType.StoredProcedure);
            return res;
        }

        /// <summary>
        /// Mapping DB
        /// </summary>
        /// <typeparam name="TEntity">Kiểu dữ liệu bất kì</typeparam>
        /// <param name="entity">Kiểu dữ liệu bất kì</param>
        /// <returns></returns>
        /// CreatedBy: LVTHO (16/01/2021)
        private DynamicParameters MappingDbType<TEntity>(TEntity entity)
        {
            var properties = entity.GetType().GetProperties();
            var parameters = new DynamicParameters();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                var propertyType = property.PropertyType;
                if (propertyType == typeof(Guid) || propertyType == typeof(Guid?))
                {
                    parameters.Add($"@{propertyName}", propertyValue, DbType.String);
                }
                else
                {
                    parameters.Add($"@{propertyName}", propertyValue);
                }
            }

            return parameters;
        }

        #endregion

    }
}
