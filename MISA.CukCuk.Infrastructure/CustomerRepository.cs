using Dapper;
using MISA.Entity.model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.CukCuk.Infrastructure
{
    public class CustomerRepository : ICustomerRepository
    {
        #region Declare
        /// <summary>
        /// Kết nối Database
        /// </summary>
        /// CreatedBy: LVTHO (14/01/2021)

        // Khai báo thông tin kết nối
        string _connectionString = "User Id=nvmanh;" +
            "Host=103.124.92.43;" +
            "Port=3306;" +
            "Database=MISACukCuk-MF662-LVTHO;" +
            "Password=12345678;" +
            "Character Set=utf8";
        // Khởi tạo đối tượng kết nối
        IDbConnection dbConnection;
        #endregion

        #region Constructor
        public CustomerRepository()
        {
            dbConnection = new MySqlConnection(_connectionString);
        }
        #endregion

        public int AddCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public int DeleteCustomer(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerById(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetCustomers()
        {
            //Khởi tạo các commandText
            var customers = dbConnection.Query<Customer>("Proc_GetCusstomers", commandType: CommandType.StoredProcedure);
            return customers;
        }

        public IEnumerable<Customer> GetCustomersByCode(string customerCode)
        {
            throw new NotImplementedException();
        }

        public int UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
