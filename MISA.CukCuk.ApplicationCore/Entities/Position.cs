using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.ApplicationCore.Entities
{
    public class Position
    {
        /// <summary>
        /// Id vị trí làm việc
        /// </summary>
        /// CreatedBy: LVTHO (18/01/2021)
        public Guid PositionId { get; set; }

        /// <summary>
        /// Tên vị trí làm việc
        /// </summary>
        /// CreatedBy: LVTHO (18/01/2021)
        public string PositionName { get; set; }

        /// <summary>
        /// Mô tả vị trí làm việc
        /// </summary>
        /// CreatedBy: LVTHO (18/01/2021)
        public string DescriptionPosition { get; set; }
    }
}
