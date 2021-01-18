using MISA.CukCuk.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.ApplicationCore.Interfaces
{
    public interface ICustomerRepository
    {
        /// <summary>
        /// Lấy danh sách khách hàng
        /// </summary>
        /// <returns>Danh sách khách hàng</returns>
        /// CreatedBy: LVTHO (14/01/2021)
        IEnumerable<Customer> GetCustomers();

        /// <summary>
        /// Lấy danh sách khách hàng theo Id Khách hàng
        /// </summary>
        /// <param name="customerId">Id khách hàng</param>
        /// <returns>Danh sách khách hàng</returns>
        /// CreatedBy: LVTHO (12/01/2021)
        IEnumerable<Customer> GetCustomerById(Guid customerId);

        /// <summary>
        /// Lấy danh sách khách hàng theo mã khách hàng
        /// </summary>
        /// <param name="customerCode">Mã khách hàng</param>
        /// <returns>Danh sách khách hàng</returns>
        /// Createdby: LVTHO (14/01/2021)
        IEnumerable<Customer> GetCustomersByCode(string customerCode);

        /// <summary>
        /// Thêm mới khách hàng
        /// </summary>
        /// <param name="customer">Object khách hàng</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: LVTHO (14/01/2021)
        int AddCustomer(Customer customer);

        /// <summary>
        /// Sửa thông tin khách hàng
        /// </summary>
        /// <param name="customer">Object khách hàng</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: LVTHO (14/01/2021)
        int UpdateCustomer(Customer customer);

        /// <summary>
        /// Xoá thông tin khách hàng theo Id
        /// </summary>
        /// <param name="customerId">Id khách hàng</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: LVTHO (14/01/2021)
        int DeleteCustomerById(Guid customerId);

        /// <summary>
        /// Xoá thông tin khách hàng theo mã khách hàng
        /// </summary>
        /// <param name="customerCode">Mã khách hàng</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: LVTHO (14/01/2021)
        int DeleteCustomerByCode(string customerCode);
    }
}
