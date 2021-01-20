using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using MISA.CukCuk.ApplicationCore.Entities;
using MISA.CukCuk.ApplicationCore.Interfaces;
using MISA.CukCuk.ApplicationCore.Enums;

namespace MISA.CukCuk.ApplicationCore
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        IBaseRepository<Customer> _baseRepository;
        ICustomerRepository _customerRepository;

        #region constructor
        public CustomerService(IBaseRepository<Customer> baseRepository, ICustomerRepository customerRepository):base(baseRepository)
        {
            _baseRepository = baseRepository;
            _customerRepository = customerRepository;
        }
        #endregion

        #region method
        //public override int Add(Customer entity)
        //{
        //    // Validate thông tin
        //    var isValid = true;
        //    // 1. Check trùng mã khách hàng
        //    var customerDuplicate = _customerRepository.GetCustomersByCode(entity.CustomerCode);
        //    if(customerDuplicate != null)
        //    {
        //        isValid = false;
        //    }
        //    //Logic validate
        //    if (isValid == true) {
        //        var res = _baseRepository.Add(entity);
        //        return res;
        //    }
        //    else
        //    {
        //        return 0;
        //    }
            
        //}

        public IEnumerable<Customer> GetCustomerPaging(int limit, int offset)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Lấy danh sách khách hàng theo nhóm khách hàng
        /// </summary>
        /// <param name="groupId">Id nhóm khách hàng</param>
        /// <returns></returns>
        /// CreatedBy: LVTHO (19/01/2021)
        public IEnumerable<Customer> GetCustomersByGroup(Guid groupId)
        {
            throw new NotImplementedException();
        }
        #endregion


        #region 
        //Lấy danh sách khách hàng
        /// <summary>
        /// Lấy danh sách khách hàng
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: LVTHO (12/01/2021)
        //public IEnumerable<Customer> GetCustomers()
        //{
        //    var customers = _baseRepository.GetEntities();
        //    return customers;
        //}

        ////Lấy danh sách khách hàng theo mã khách hàng
        ///// <summary>
        ///// Hàm lấy danh sách khách hàng theo mã khách hàng
        ///// </summary>
        ///// <param name="customerCode">Mã khách hàng</param>
        ///// <returns></returns>
        ///// CreatedBy: LVTHO (12/01/2021)
        ////public IEnumerable<Customer> GetCustomerByCode(string customerCode)
        ////{
        ////    var customers = _customerRepository.GetCustomersByCode(customerCode);
        ////    return customers;
        ////}

        ////Thêm mới khách hàng
        ///// <summary>
        ///// Hàm thêm mới thông tin khách hàng
        ///// </summary>
        ///// <param name="customer">Object khách hàng</param>
        ///// <returns></returns>
        ///// CreatedBy: LVTHO (13/01/2021)
        //public ServiceResult AddCustomer(Customer customer)
        //{
        //    var serviceResult = new ServiceResult();

        //    //Check trường bắt buộc nhập:
        //    //Validate dữ liệu:
        //    var customerCode = customer.CustomerCode;
        //    if (string.IsNullOrEmpty(customerCode))
        //    {
        //        var msg = new
        //        {
        //            devMsg = new { fieldName = "CustomerCode", msg = "Mã khách hàng k được để trống!" },
        //            userMsg = "Mã khách hàng không được để trống!",
        //            code = MISACode.NotValid,
        //        };
        //        serviceResult.MISACode = MISACode.NotValid;
        //        serviceResult.Messenger = "Mã khách hàng không được phép để trống!";
        //        serviceResult.Data = msg;
        //        return serviceResult; 
        //    }

        //    ////Check trùng mã
        //    //var res = _customerRepository.GetCustomersByCode(customerCode);
        //    //if (res.Count() > 0)
        //    //{
        //    //    var msg = new
        //    //    {
        //    //        devMsg = new { fieldName = "CustomerCode", msg = "Mã khách hàng không được trùng!" },
        //    //        userMsg = "Mã khách hàng không được trùng!",
        //    //        code = MISACode.NotValid,
        //    //    };
        //    //    serviceResult.MISACode = MISACode.NotValid;
        //    //    serviceResult.Messenger = "Mã khách hàng k được trùng!";
        //    //    serviceResult.Data = msg;
        //    //    return serviceResult;
        //    //}

        //    var rowAffects = _baseRepository.Add(customer);
        //    serviceResult.MISACode = MISACode.IsValid;
        //    serviceResult.Messenger = "Thêm thành công!";
        //    serviceResult.Data = rowAffects;
        //    return serviceResult;
        //}


        ////Sửa thông tin khách hàng
        ///// <summary>
        ///// Hàm sửa thông tin khách hàng
        ///// </summary>
        ///// <param name="customer">Object khách hàng</param>
        ///// <returns></returns>
        ///// CreatedBy: LVTHO (13/01/2021)
        //public ServiceResult UpdateCustomer(Customer customer)
        //{
        //    var serviceResult = new ServiceResult();

        //    //Check trường bắt buộc nhập:
        //    //Validate dữ liệu:
        //    var customerCode = customer.CustomerCode;
        //    if (string.IsNullOrEmpty(customerCode))
        //    {
        //        var msg = new
        //        {
        //            devMsg = new { fieldName = "CustomerCode", msg = "Mã khách hàng không được để trống!" },
        //            userMsg = "Mã khách hàng không được để trống!",
        //            code = MISACode.NotValid,
        //        };
        //    serviceResult.MISACode = MISACode.NotValid;
        //    serviceResult.Messenger = "Mã khách hàng không được để trống!";
        //    serviceResult.Data = msg;
        //    return serviceResult;
        //    }

        //    var rowAffects = _baseRepository.Update(customer);
        //    serviceResult.MISACode = MISACode.IsValid;
        //    serviceResult.Messenger = "Sửa thành công";
        //    serviceResult.Data = rowAffects;
        //    return serviceResult;
        //}
        #endregion


        //Xoá thông tin khách hàng
        /// <summary>
        /// Hàm xoá thông tin khách hàng
        /// </summary>
        /// <param name="customerCode">Mã khách hàng</param>
        /// <returns></returns>
        /// CreatedBy: LVTHO (13/01/2021)
        //public ServiceResult DeleteCustomerByCode(string customerCode)
        //{
        //    var serviceResult = new ServiceResult();
        //    //Check trường bắt buộc nhập:
        //    //Validate dữ liệu:
        //    if (string.IsNullOrEmpty(customerCode))
        //    {
        //        var msg = new
        //        {
        //            devMsg = new { fieldName = "CustomerCode", msg = "Mã khách hàng không được để trống!" },
        //            userMsg = "Mã khách hàng không được để trống!",
        //            code = MISACode.NotValid,
        //        };
        //        serviceResult.MISACode = MISACode.NotValid;
        //        serviceResult.Messenger = "Mã khách hàng không được để trống!";
        //        serviceResult.Data = msg;
        //        return serviceResult;
        //    }

        //    var rowAffects = _customerRepository.Delete(customerCode);
        //    serviceResult.MISACode = MISACode.IsValid;
        //    serviceResult.Messenger = "Xoá thành công";
        //    serviceResult.Data = rowAffects;
        //    return serviceResult;
        //}

        #region
        /// <summary>
        /// Xoá thông tin khách hàng theo Id khách hàng
        /// </summary>
        /// <param name="customerId">Id khách hàng</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: LVTHO (18/01/2021)
        //public ServiceResult DeleteCustomerById (Guid customerId)
        //{
        //    var serviceResult = new ServiceResult();
        //    //Check trường bắt buộc nhập:
        //    //Validate dữ liệu:
        //    if (customerId == Guid.Empty)
        //    {
        //        var msg = new
        //        {
        //            devMsg = new { fieldName = "CustomerId", msg = "Id khách hàng không được để trống!" },
        //            userMsg = "Id khách hàng không được để trống!",
        //            code = MISACode.NotValid,
        //        };
        //        serviceResult.MISACode = MISACode.NotValid;
        //        serviceResult.Messenger = "Id khách hàng không được để trống!";
        //        serviceResult.Data = msg;
        //        return serviceResult;
        //    }

        //    var rowAffects = _baseRepository.Delete(customerId);
        //    serviceResult.MISACode = MISACode.IsValid;
        //    serviceResult.Messenger = "Xoá thành công";
        //    serviceResult.Data = rowAffects;
        //    return serviceResult;
        //}

        /// <summary>
        /// Lấy thông tin khách hàng theo Id khách hàng
        /// </summary>
        /// <param name="customerId">Id khách hàng</param>
        /// <returns>Thông tin khách hàng</returns>
        /// CreatedBy: LVTHO (18/01/2021)
        //public IEnumerable<Customer> GetCustomerById(Guid customerId)
        //{
        //    var customer = _baseRepository.GetEntityById(customerId);
        //    return customer;
        //}
        #endregion


    }
}
