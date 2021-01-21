using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.ApplicationCore.Entities
{
    /// <summary>
    /// Khách hàng
    /// </summary>
    /// CreatedBy: LVTHO (12/01/2021)
    public class Customer:BaseEntity
    {
        #region Declare

        #endregion

        #region Constructor

        #endregion

        #region Method

        #endregion

        #region property

        /// <summary>
        /// Id khách hàng - Khoá chính
        /// </summary>
        /// CrestedBy: LVTHO (07/01/2021)
        [PrimaryKey]
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Mã khách hàng
        /// </summary>
        /// CrestedBy: LVTHO (07/01/2021)
        [CheckDuplicate]
        [Required]
        [DisplayName("Mã khách hàng")]
        public string CustomerCode { get; set; }

        /// <summary>
        /// Họ tên khách hàng
        /// </summary>
        /// CrestedBy: LVTHO (07/01/2021)
        public string FullName { get; set; }

        /// <summary>
        /// SĐT khách hàng
        /// </summary>
        /// CrestedBy: LVTHO (07/01/2021)
        [DisplayName("Họ tên khách hàng")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Ngày sinh khách hàng
        /// </summary>
        /// CrestedBy: LVTHO (07/01/2021)
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Địa chỉ khách hàng
        /// </summary>
        /// CrestedBy: LVTHO (07/01/2021)
        public string Address { get; set; }

        /// <summary>
        /// Email khách hàng
        /// </summary>
        /// CrestedBy: LVTHO (07/01/2021)
        public string Email { get; set; }

        /// <summary>
        /// Id nhóm khách hàng
        /// </summary>
        /// CrestedBy: LVTHO (07/01/2021)
        public Guid? CustomerGroupId { get; set; }

        /// <summary>
        /// Tên công ty khách hàng
        /// </summary>
        /// CrestedBy: LVTHO (07/01/2021)
        public string CompanyName { get; set; }

        /// <summary>
        /// Giới tính khách hàng
        /// </summary>
        /// CrestedBy: LVTHO (07/01/2021)
        public int? Gender { get; set; }
        #endregion
    }
}
