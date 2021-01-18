using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.CukCuk.ApplicationCore.Entities;
using MISA.CukCuk.ApplicationCore.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.CukCuk.Infrastructure
{
    public class CustomerGroupRepository : ICustomerGroupRepository
    {
        #region Declare
        IConfiguration _configuration;
        string _connectionString = string.Empty;
        IDbConnection _dbConnection = null;
        #endregion

        #region Constructor
        public CustomerGroupRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("MISACukCukConnectionString");
            _dbConnection = new MySqlConnection(_connectionString);
        }
        #endregion

        public int AddCustomerGroup(CustomerGroup customerGroup)
        {
            throw new NotImplementedException();
        }

        public int DeleteCustomerGroup(string customerGroupId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerGroup> GetCustomerGroups()
        {
            var customerGroups = _dbConnection.Query<CustomerGroup>("Proc_GetCustomerGroup", commandType: CommandType.StoredProcedure);
            return customerGroups;
        }

        public int UpdateCustomerGroup(CustomerGroup customerGroup)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerGroup>  GetCustomerGroupById(string customerGroupId)
        {
            var customerGroups = _dbConnection.Query<CustomerGroup>("Proc_GetCustomerGroupById", new { CustomerGroupId = customerGroupId }, commandType: CommandType.StoredProcedure);
            return customerGroups;
        }
    }
}
