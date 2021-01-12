using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Entity
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
}
