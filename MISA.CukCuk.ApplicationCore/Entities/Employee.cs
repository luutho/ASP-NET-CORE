using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.ApplicationCore.Entities
{
    public class Employee
    {
        #region Declare

        #endregion

        #region Constructor

        #endregion

        #region Method

        #endregion

        #region property

        /// <summary>
        /// Id nhân viên
        /// </summary>
        /// CreatedBy: LVTHO (18/01/2021)
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Mã nhân viên
        /// </summary>
        /// CreatedBy: LVTHO (18/01/2021)
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Họ tên nhân viên
        /// </summary>
        /// CreatedBy: LVTHO (18/01/2021)
        public string FullName { get; set; }

        /// <summary>
        /// Số điện thoại nhân viên
        /// </summary>
        /// CreatedBy: LVTHO (18/01/2021)
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Ngày sinh nhân viên
        /// </summary>
        /// CreatedBy: LVTHO (18/01/2021)
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Email nhân viên
        /// </summary>
        /// CreatedBy: LVTHO (18/01/2021)
        public string Email { get; set; }


        /// <summary>
        /// Giới tính nhân viên
        /// </summary>
        /// CrestedBy: LVTHO (18/01/2021)
        public int? Gender { get; set; }

        /// <summary>
        /// Số căn cước công dân
        /// </summary>
        /// CreatedBy: LVTHO (18/01/2021)
        public string PeopleId { get; set; }

        /// <summary>
        /// Ngày cấp căn cước công dân
        /// </summary>
        /// CreatedBy: LVTHO (18/01/2021)
        public DateTime PeopleDate { get; set; }

        /// <summary>
        /// Noi cấp căn cước công dân
        /// </summary>
        /// CreatedBy: LVTHO (18/01/2021)
        public string PeopleIdBy { get; set; }

        /// <summary>
        /// Mã số thuế cá nhân
        /// </summary>
        /// CreatedBy: LVTHO (18/01/2021)
        public string PersonCompaxTaxCode { get; set; }

        /// <summary>
        /// Lương cơ bản
        /// </summary>
        /// CreatedBy: LVTHO (18/01/2021)
        public double SalaryBase { get; set; }

        /// <summary>
        /// Ngày vào công ty
        /// </summary>
        /// CreatedBy: LVTHO (18/01/2021)
        public DateTime JoinDate { get; set; }

        /// <summary>
        /// Id vị trí làm việc
        /// </summary>
        /// CreatedBy: LVTHO (18/01/2021)
        public Guid PositionId { get; set; }

        /// <summary>
        /// Id phòng ban
        /// </summary>
        /// CreatedBy: LVTHO (18/01/2021)
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// Trạng thái làm việc
        /// </summary>
        /// CreatedBy: LVTHO (18/01/2021)
        public int WorkStatus { get; set; }
        #endregion
    }
}
