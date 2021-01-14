using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Entity.model
{
    class CustomerGroup
    {
        #region property

        /// <summary>
        /// Id nhóm khách hàng - Khoá chính
        /// </summary>
        /// CrestedBy: LVTHO (14/01/2021)
        public Guid CustomerGroupId { get; set; }

        /// <summary>
        /// Tên nhóm khách hàng
        /// </summary>
        /// CrestedBy: LVTHO (14/01/2021)
        public string CustomerGroupName { get; set; }

        /// <summary>
        /// Mô tả nhóm khách hàng
        /// </summary>
        /// CrestedBy: LVTHO (14/01/2021)
        public string Description { get; set; }
        #endregion
    }
}
