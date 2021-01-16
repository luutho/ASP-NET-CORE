using MISA.CukCuk.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.ApplicationCore.Interfaces
{
    public interface ICustomerGroupService
    {
        /// <summary>
        /// Lấy danh sách nhóm khách hàng
        /// </summary>
        /// <returns>Danh sách nhóm khách hàng</returns>
        /// CreatedBy: LVTHO (16/01/2021)
        public IEnumerable<CustomerGroup> GetCustomerGroups();

        /// <summary>
        /// Lấy danh sách nhóm khách hàng theo Id nhóm khách hàng
        /// </summary>
        /// <param name="customerGroupId">Id nhóm khách hàng</param>
        /// <returns>Danh sách nhóm khách hàng</returns>
        /// CreatedBy: LVTHO (14/01/2021)
        IEnumerable<CustomerGroup> GetCustomerGroupById(Guid customerGroupId);

        /// <summary>
        /// Thêm mới nhóm khách hàng
        /// </summary>
        /// <param name="customerGroup">Object nhóm khách hàng</param>
        /// <returns></returns>
        /// CreatedBy: LVTHO (16/01/2021)
        ServiceResult AddCustomerGroup(CustomerGroup customerGroup);

        /// <summary>
        /// Sửa danh sách nhóm khách hàng
        /// </summary>
        /// <param name="customerGroup">Object nhóm khách hàng</param>
        /// <returns></returns>
        /// CreatedBy: LVTHO (16/01/2021)
        ServiceResult UpdateCustomerGroup(CustomerGroup customerGroup);

        /// <summary>
        /// Xoá danh sách nhóm khách hàng theo mã khách hàng
        /// </summary>
        /// <param name="customerGroupId">Id nhóm khách hàng</param>
        /// <returns></returns>
        /// Createdby: LVTHO (14/01/2021)
        ServiceResult DeleteCustomerGroup(Guid customerGroupId);
    }
}
