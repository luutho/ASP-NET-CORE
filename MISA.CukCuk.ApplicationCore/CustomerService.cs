using MISA.CukCuk.Infrastructure;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;
using System.Linq;
using MISA.CukCuk.ApplicationCore.Entities;
using MISA.Entity.model;
using MISA.Entity;

namespace MISA.CukCuk.ApplicationCore
{
    public class CustomerService
    {
        /// <summary>
        /// Tạo kết nối database
        /// </summary>
        /// <returns></returns>
        /// CretedBy: LVTHO (11/01/2021)
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
        //Lấy danh sách khách hàng
        /// <summary>
        /// Lấy danh sách khách hàng
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: LVTHO (12/01/2021)
        public IEnumerable<Customer> GetCustomers()
        {
            var customerContext = new CustomerContext();
            var customers = customerContext.GetCustomers();
            return customers;
        }

        //Lấy danh sách khách hàng theo mã khách hàng
        /// <summary>
        /// Hàm lấy danh sách khách hàng theo mã khách hàng
        /// </summary>
        /// <param name="customerCode">Mã khách hàng</param>
        /// <returns></returns>
        /// CreatedBy: LVTHO (12/01/2021)
        public IEnumerable<Customer> GetCustomerByCode(string customerCode)
        {
            var customerContext = new CustomerContext();
            var customers = customerContext.GetCustomersByCode(customerCode);
            return customers;
        }

        //Thêm mới khách hàng
        /// <summary>
        /// Hàm thêm mới thông tin khách hàng
        /// </summary>
        /// <param name="customer">Object khách hàng</param>
        /// <returns></returns>
        /// CreatedBy: LVTHO (13/01/2021)
        public ServiceResult InsertCustomer(Customer customer)
        {
            var serviceResult = new ServiceResult();
            var customerContext = new CustomerContext();

            //Check trường bắt buộc nhập:
            //Validate dữ liệu:
            var customerCode = customer.CustomerCode;
            if (string.IsNullOrEmpty(customerCode))
            {
                var msg = new
                {
                    devMsg = new { fieldName = "CustomerCode", msg = "Mã khách hàng k được để trống!" },
                    userMsg = "Mã khách hàng không được để trống!",
                    code = MISACode.NotValid,
                };
                serviceResult.MISACode = MISACode.NotValid;
                serviceResult.Messenger = "Mã khách hàng không được phép để trống!";
                serviceResult.Data = msg;
                return serviceResult; 
            }

            //Check trùng mã
            var res = customerContext.GetCustomerByCode(customerCode);
            if (res != null)
            {
                var msg = new
                {
                    devMsg = new { fieldName = "CustomerCode", msg = "Mã khách hàng không được trùng!" },
                    userMsg = "Mã khách hàng không được trùng!",
                    code = MISACode.NotValid,
                };
                serviceResult.MISACode = MISACode.NotValid;
                serviceResult.Messenger = "Mã khách hàng k được phép để trống!";
                serviceResult.Data = msg;
                return serviceResult;
            }

            var rowAffects = customerContext.InsertCustomer(customer);
            serviceResult.MISACode = MISACode.IsValid;
            serviceResult.Messenger = "Thêm thành công!";
            serviceResult.Data = rowAffects;
            return serviceResult;
        }


        //Sửa thông tin khách hàng
        /// <summary>
        /// Hàm sửa thông tin khách hàng
        /// </summary>
        /// <param name="customer">Object khách hàng</param>
        /// <returns></returns>
        /// CreatedBy: LVTHO (13/01/2021)
        public ServiceResult UpdateCustomer(Customer customer)
        {
            var serviceResult = new ServiceResult();
            var customerContext = new CustomerContext();

            //Check trường bắt buộc nhập:
            //Validate dữ liệu:
            var customerCode = customer.CustomerCode;
            if (string.IsNullOrEmpty(customerCode))
            {
                var msg = new
                {
                    devMsg = new { fieldName = "CustomerCode", msg = "Mã khách hàng không được để trống!" },
                    userMsg = "Mã khách hàng không được để trống!",
                    code = MISACode.NotValid,
                };
            serviceResult.MISACode = MISACode.NotValid;
            serviceResult.Messenger = "Mã khách hàng không được để trống!";
            serviceResult.Data = msg;
            return serviceResult;
            }

            var rowAffects = customerContext.UpdateCustomerByCode(customer);
            serviceResult.MISACode = MISACode.IsValid;
            serviceResult.Messenger = "Sửa thành công";
            serviceResult.Data = rowAffects;
            return serviceResult;
        }


        //Xoá thông tin khách hàng
        /// <summary>
        /// Hàm xoá thông tin khách hàng
        /// </summary>
        /// <param name="customerCode">Mã khách hàng</param>
        /// <returns></returns>
        /// CreatedBy: LVTHO (13/01/2021)
        public ServiceResult DeleteCustomer(string customerCode)
        {
            var serviceResult = new ServiceResult();
            var customerContext = new CustomerContext();
            //Check trường bắt buộc nhập:
            //Validate dữ liệu:
            if (string.IsNullOrEmpty(customerCode))
            {
                var msg = new
                {
                    devMsg = new { fieldName = "CustomerCode", msg = "Mã khách hàng không được để trống!" },
                    userMsg = "Mã khách hàng không được để trống!",
                    code = MISACode.NotValid,
                };
                serviceResult.MISACode = MISACode.NotValid;
                serviceResult.Messenger = "Mã khách hàng không được để trống!";
                serviceResult.Data = msg;
                return serviceResult;
            }

            var rowAffects = customerContext.DeleteCustomerByCode(customerCode);
            serviceResult.MISACode = MISACode.IsValid;
            serviceResult.Messenger = "Xoá thành công";
            serviceResult.Data = rowAffects;
            return serviceResult;
        }
        #endregion
    }
}
