using Dapper;
using MISA.Entity.model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MISA.CukCuk.Infrastructure
{
    public class CustomerContext
    {
        /// <summary>
        /// Hàm kết nối cơ sở dữ liệu
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: LVTHO (12/01/2021)
        public IDbConnection connectDatabase()
        {
            // Kết nối database
            var connectionString = "User Id=nvmanh;" +
                "Host=103.124.92.43;" +
                "Port=3306;" +
                "Database=MISACukCuk-MF662-LVTHO;" +
                "Password=12345678;" +
                "Character Set=utf8";
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            return dbConnection;
        }

        #region method
        //Lấy toàn bộ danh sách khách hàng:
        /// <summary>
        /// Hàm lấy dữ liệu khách hàng
        /// </summary>
        /// <returns>Danh sách khách hàng</returns>
        /// CreatedBy: LVTHO (12/01/2021)
        public IEnumerable<Customer> GetCustomers()
        {
            //Khởi tạo các commandText
            var customers = connectDatabase().Query<Customer>("Proc_GetCusstomers", commandType: CommandType.StoredProcedure);
            return customers;
        }

        //Lấy thông tin khách hàng theo mã khách hàng:
        /// <summary>
        /// Lấy thông tin khách hàng theo mã khách hàng
        /// </summary>
        /// <param name="customerCode">Mã khách hàng</param>
        /// <returns>Thông tin 1 khách hàng</returns>
        /// CreatedBy: LVTHO (12/01/2021)
        public IEnumerable<Customer> GetCustomersByCode(string customerCode)
        {
            //Khởi tạo với commandText
            var customers = connectDatabase().Query<Customer>("Proc_GetCustomerByCode", new { CustomerCode = customerCode }, commandType: CommandType.StoredProcedure);
            return customers;
        }

        //Thêm mới khách hàng:
        /// <summary>
        /// Thêm mới khách hàng
        /// </summary>
        /// <param name="customer">Object khách hàng</param>
        /// <returns>Số bản ghi thêm mới được</returns>
        /// CreatedBy: LVTHO (12/01/20211)
        public int InsertCustomer(Customer customer)
        {
            var properties = customer.GetType().GetProperties();
            var parameters = new DynamicParameters();
            
            //Xử lý các kiểu dữ liệu (Mapping dataType):
            foreach(var property in properties)
            {
                var propertyName = property.Name;
                var propertyType = property.PropertyType;
                var propertyValue = property.GetValue(customer);
                if(propertyType == typeof(Guid) || propertyType == typeof(Guid?))
                {
                    parameters.Add($"@{propertyName}", propertyValue, DbType.String);
                }
                else
                {
                    parameters.Add($"@{propertyName}", propertyValue);
                }
            }

            //Thực thi commandText
            var rowAffect = connectDatabase().Execute("Proc_InsertCustomer", parameters, commandType: CommandType.StoredProcedure);
            //Trả về số bản ghi thêm mới được
            return rowAffect;
        }

        /// <summary>
        /// Lấy khách hàng theo mã khách hàng
        /// </summary>
        /// <param name="customerCode">Mã khách hàng</param>
        /// <returns>Object khách hàng</returns>
        /// CreatedBy: LVTHO (12/01/2021)
        public Customer GetCustomerByCode(string customerCode)
        {
            var res = connectDatabase().Query<Customer>("Proc_GetCustomerByCode", new { CustomerCode = customerCode }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return res;
        }


        //Sửa thông tin khách hàng:
        /// <summary>
        /// Hàm sửa thông tin khách hàng
        /// </summary>
        /// <param name="customer">Object khách hàng</param>
        /// <returns>Số bản ghi update được</returns>
        /// CreatedBy: LVTHO (13/01/2021)
        public int UpdateCustomerByCode(Customer customer)
        {
            var properties = customer.GetType().GetProperties();
            var parameters = new DynamicParameters();
            //Xử lý các kiểu dữ liệu
            foreach(var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(customer);
                var propertyType = property.PropertyType;
                if(propertyType == typeof(Guid) || propertyType == typeof(Guid?))
                {
                    parameters.Add($"@{propertyName}", propertyValue, DbType.String);
                }
                else
                {
                    parameters.Add($"@{propertyName}", propertyValue);
                }
            }
            //Thực thi commandText
            var rowAffects = connectDatabase().Execute("Proc_UpdateCustomerByCode", parameters, commandType: CommandType.StoredProcedure);
            //Trả về số bản ghi sửa được
            return rowAffects;
        }


        //Xoá thông tin khách hàng theo mã khách hàng:
        /// <summary>
        /// Hàm xoá thông tin khách hàng
        /// </summary>
        /// <param name="customerCode">Mã khách hàng</param>
        /// <returns>Số bản ghi bị ảnh hưởng (bị xoá)</returns>
        /// CreatedBy: LVTHO (13/01/2021)
        public int DeleteCustomerByCode(string customerCode)
        {
            var rowAffects = connectDatabase().Execute("Proc_DeleteCustomerByCode", customerCode, commandType: CommandType.StoredProcedure);
            return rowAffects;
        }

        #endregion
    }
}
