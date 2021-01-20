using MISA.CukCuk.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.ApplicationCore.Interfaces
{
    public interface IBaseService<TEntity>
    {
        /// <summary>
        /// Lấy toàn bộ danh sách
        /// </summary>
        /// <returns>Danh sách</returns>
        /// CreatedBy: LVTHO (18/01/2021)
        IEnumerable<TEntity> GetEntities();

        /// <summary>
        /// Lấy 1 bản ghi theo Id
        /// </summary>
        /// <returns>Thông tin 1 bản ghi</returns>
        /// CreatedBy: LVTHO (18/01/2021)
        IEnumerable<TEntity> GetEntityById(Guid entityId);

        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="entity">Object</param>
        /// <returns>Số bản ghi ảnh hưởng</returns>
        /// CreatedBy: LVTHO (18/01/2021)
        ServiceResult Add(TEntity entity);

        /// <summary>
        /// Sửa bản ghi
        /// </summary>
        /// <param name="entity">Object</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: LVTHO (18/01/2021)
        ServiceResult Update(TEntity entity);

        /// <summary>
        /// Xoá bản ghi
        /// </summary>
        /// <param name="entityId">Id bản ghi cần xoá</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: LVTHO (18/01/2021)
        ServiceResult Delete(Guid entityId);
    }
}
