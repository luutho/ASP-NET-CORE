using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.ApplicationCore.Interfaces
{
    public interface IBaseRepository<TEntity>
    {
        /// <summary>
        /// Lấy toàn bộ danh sách
        /// </summary>
        /// <returns>Danh sách</returns>
        /// CreatedBy: LVTHO (18/01/2021)
        IEnumerable<TEntity> GetEntities();

        /// <summary>
        /// Lấy danh sách theo khoá chính
        /// </summary>
        /// <param name="entityId">Khoá chính</param>
        /// <returns>Danh sách</returns>
        /// CreatedBy: LVTHO (18/01/2021)
        IEnumerable<TEntity> GetEntityById(Guid entityId);

        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="entity">Object</param>
        /// <returns>Số bản ghi ảnh hưởng</returns>
        /// CreatedBy: LVTHO (18/01/2021)
        int Add(TEntity entity);

        /// <summary>
        /// Sửa bản ghi
        /// </summary>
        /// <param name="entity">Object</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: LVTHO (18/01/2021)
        int Update(TEntity entity);

        /// <summary>
        /// Xoá bản ghi
        /// </summary>
        /// <param name="entityId">Id bản ghi cần xoá</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: LVTHO (18/01/2021)
        int Delete(Guid entityId);
    }
}
