using MISA.CukCuk.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.ApplicationCore.Interfaces
{
    public interface ICustomerService: IBaseService<Customer>
    {
        /// <summary>
        /// Lấy dữ liệu phân trang
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        /// CreatedBy: LVTHO (19/01/2021)
        IEnumerable<Customer> GetCustomerPaging(int limit, int offset);

        /// <summary>
        /// Lấy danh sách khách hàng theo nhóm khách hàng
        /// </summary>
        /// <param name="groupId">Id nhóm khách hàng</param>
        /// <returns>Danh sách khách hàng</returns>
        /// CreatedBy: LVTHO (19/01/2021)
        IEnumerable<Customer> GetCustomersByGroup(Guid groupId);

        #region
        ///// <summary>
        ///// Lấy danh sách khách hàng
        ///// </summary>
        ///// <returns>Danh sách khách hàng</returns>
        ///// CreatedBy: LVTHO (14/01/2021)
        //IEnumerable<Customer> GetCustomers();

        ///// <summary>
        ///// Lấy danh sách khách hàng theo mã khách hàng
        ///// </summary>
        ///// <param name="customerCode">Mã khách hàng</param>
        ///// <returns>Danh sách khách hàng</returns>
        ///// CreatedBy: LVTHO (14/01/2021)
        //IEnumerable<Customer> GetCustomerByCode(string customerCode);

        ///// <summary>
        ///// Lấy danh sách khách hàng theo Id khách hàng
        ///// </summary>
        ///// <param name="customerId">Id khách hàng</param>
        ///// <returns>Danh sách khách hàng</returns>
        ///// CreatedBy: LVTHO (14/01/2021)
        //IEnumerable<Customer> GetCustomerById(Guid customerId);

        ///// <summary>
        ///// Thêm mới khách hàng
        ///// </summary>
        ///// <param name="customer">Object khách hàng</param>
        ///// <returns></returns>
        ///// CreatedBy: LVTHO (14/01/2021)
        //ServiceResult AddCustomer(Customer customer);

        ///// <summary>
        ///// Sửa danh sách khách hàng
        ///// </summary>
        ///// <param name="customer">Object khách hàng</param>
        ///// <returns></returns>
        ///// CreatedBy: LVTHO (14/01/2021)
        //ServiceResult UpdateCustomer(Customer customer);

        ///// <summary>
        ///// Xoá danh sách khách hàng theo mã khách hàng
        ///// </summary>
        ///// <param name="customerCode">Mã khách hàng</param>
        ///// <returns></returns>
        ///// Createdby: LVTHO (14/01/2021)
        //ServiceResult DeleteCustomerByCode(string customerCode);

        ///// <summary>
        ///// Xoá thông tin khách hàng theo Id khách hàng
        ///// </summary>
        ///// <param name="customerId">Id khách hàng</param>
        ///// <returns>Số bản ghi bị ảnh hưởng</returns>
        ///// CreatedBy: LVTHO(18/01/2021)
        //ServiceResult DeleteCustomerById(Guid customerId);
        #endregion

    }
}
