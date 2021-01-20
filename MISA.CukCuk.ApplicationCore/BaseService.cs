using MISA.CukCuk.ApplicationCore.Entities;
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

        public virtual ServiceResult Add(TEntity entity)
        {
            ServiceResult serviceResult = new ServiceResult();
            var isValidate = Validate(entity);
            if (isValidate == true)
            {
                serviceResult.Data = _baseRepository.Add(entity);
                serviceResult.MISACode = Enums.MISACode.IsValid;
                return serviceResult;
            }
            else
            {
                serviceResult.Data = _baseRepository.Add(entity);
                serviceResult.MISACode = Enums.MISACode.NotValid;
                return serviceResult;
            }
            
        }

        public ServiceResult Delete(Guid entityId)
        {
            ServiceResult serviceResult = new ServiceResult();
            serviceResult.Data = _baseRepository.Delete(entityId)
            serviceResult.MISACode = Enums.MISACode.IsValid;
            return serviceResult;
        }

        public IEnumerable<TEntity> GetEntities()
        {
            return _baseRepository.GetEntities();
        }

        public IEnumerable<TEntity> GetEntityById(Guid entityId)
        {
            return _baseRepository.GetEntityById(entityId);
        }

        public ServiceResult Update(TEntity entity)
        {
            return _baseRepository.Update(entity);
        }

        private bool Validate(TEntity entity)
        {
            var isValidate = true;
            // Đọc các property
            var properties = entity.GetType().GetProperties();
            foreach (var property in properties)
            {
                // Kiểm tra attribute có cần phải validate không:
                if (property.IsDefined(typeof(Required), false))
                {
                    // Check bắt buộc nhập
                    var propertyValue = property.GetValue(entity);
                    if (propertyValue == null)
                    {
                        isValidate = false;
                    }
                }

                if (property.IsDefined(typeof(CheckDuplicate), false))
                {
                    // Check trùng dữ liệu
                    var propertyName = property.Name;
                    var entityDuplicate = _baseRepository.GetEntityByProperty(propertyName, property.GetValue(entity));
                    if (entityDuplicate != null)
                    {
                        isValidate = false;
                    }
                }

            }

            return isValidate;
        }
    }
}
