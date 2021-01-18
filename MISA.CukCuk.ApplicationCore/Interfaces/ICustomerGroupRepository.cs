using MISA.CukCuk.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.ApplicationCore.Interfaces
{
    public interface ICustomerGroupRepository
    {
        /// <summary>
        /// Lấy danh sách nhóm khách hàng
        /// </summary>
        /// <returns>Danh sách nhóm khách hàng</returns>
        /// CreatedBy: LVTHO (16/01/2021)
        IEnumerable<CustomerGroup> GetCustomerGroups();

        /// <summary>
        /// Lấy danh sách nhóm khách hàng theo Id Khách hàng
        /// </summary>
        /// <param name = "customerGroupId" > Id nhóm khách hàng</param>
        /// <returns>Danh sách khách hàng</returns>
        /// CreatedBy: LVTHO (16/01/2021)
        IEnumerable<CustomerGroup> GetCustomerGroupById(string customerGroupId);

        /// <summary>
        /// Thêm mới nhóm khách hàng
        /// </summary>
        /// <param name="customerGroup">Object nhóm khách hàng</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: LVTHO (16/01/2021)
        int AddCustomerGroup(CustomerGroup customerGroup);

        /// <summary>
        /// Sửa thông tin nhóm khách hàng
        /// </summary>
        /// <param name="customerGroup">Object nhóm khách hàng</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: LVTHO (16/01/2021)
        int UpdateCustomerGroup(CustomerGroup customerGroup);

        /// <summary>
        /// Xoá thông tin nhóm khách hàng theo Id
        /// </summary>
        /// <param name="customerGroupId">Id nhóm khách hàng</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: LVTHO (16/01/2021)
        int DeleteCustomerGroup(string customerGroupId);
    }
}
