using MISA.CukCuk.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.ApplicationCore
{
    public class BaseService<TEntity> : IBaseService<TEntity>
    {
        IBaseRepository<TEntity> _baseRepository;

        #region constructor
        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        #endregion

        public int Add(TEntity entity)
        {
            return _baseRepository.Add(entity);
        }

        public int Delete(Guid entityId)
        {
            return _baseRepository.Delete(entityId);
        }

        public IEnumerable<TEntity> GetEntities()
        {
            return _baseRepository.GetEntities();
        }

        public IEnumerable<TEntity> GetEntityById(Guid entityId)
        {
            return _baseRepository.GetEntityById(entityId);
        }

        public int Update(TEntity entity)
        {
            return _baseRepository.Update(entity);
        }
    }
}
