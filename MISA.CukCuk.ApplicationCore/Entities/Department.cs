using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.ApplicationCore.Entities
{
    public class Department
    {
        /// <summary>
        /// Id phòng ban
        /// </summary>
        /// CreatedBy: LVTHO (18/01/2021)
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// Tên phòng ban
        /// </summary>
        /// CreatedBy: LVTHO (18/01/2021)
        public string DepartmentName { get; set; }

        /// <summary>
        /// Mô tả phòng ban
        /// </summary>
        /// CreatedBy: LVTHO (18/01/2021)
        public string DescriptionDepartment { get; set; }

    }
}
