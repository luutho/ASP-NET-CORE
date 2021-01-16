using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.ApplicationCore.Entities
{
    public class CustomerGroup
    {
        #region Declare

        #endregion

        #region Constructor

        #endregion

        #region Method

        #endregion

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
