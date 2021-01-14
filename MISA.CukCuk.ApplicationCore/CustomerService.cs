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
using MISA.CukCuk.ApplicationCore.Interfaces;

namespace MISA.CukCuk.ApplicationCore
{
    public class CustomerService : ICustomerService
    {
        ICustomerRepository _customerRepository;

        #region constructor
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        #endregion


        #region method
        //Lấy danh sách khách hàng
        /// <summary>
        /// Lấy danh sách khách hàng
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: LVTHO (12/01/2021)
        public IEnumerable<Customer> GetCustomers()
        {
            var customers = _customerRepository.GetCustomers();
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
            var customers = _customerRepository.GetCustomersByCode(customerCode);
            return customers;
        }

        //Thêm mới khách hàng
        /// <summary>
        /// Hàm thêm mới thông tin khách hàng
        /// </summary>
        /// <param name="customer">Object khách hàng</param>
        /// <returns></returns>
        /// CreatedBy: LVTHO (13/01/2021)
        public ServiceResult AddCustomer(Customer customer)
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

        public IEnumerable<Customer> GetCustomerById(Guid customerId)
        {
            throw new NotImplementedException();
        }




        #endregion
    }
}
