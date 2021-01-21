using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.ApplicationCore.Enums
{
    /// <summary>
    /// MISACode để xác định trạng thái của validate
    /// </summary>
    /// CreatedBy: LVTHO (12/01/2021)
    public enum MISACode
    {
        /// <summary>
        /// Dữ liệu hợp lệ
        /// </summary>
        IsValid = 100,

        /// <summary>
        /// Dữ liệu không hợp lệ
        /// </summary>
        NotValid = 100,

        /// <summary>
        /// Thành công
        /// </summary>
        Success = 200
    }

    /// <summary>
    /// Xác định trạng thái của object
    /// </summary>
    /// CreatedBy: LVTHO (21/01/2021)
    public enum EntityState
    {
        AddNew = 1,
        Update = 2,
        Delete = 3,
    }
}
