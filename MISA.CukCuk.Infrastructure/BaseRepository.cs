using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.CukCuk.ApplicationCore.Entities;
using MISA.CukCuk.ApplicationCore.Enums;
using MISA.CukCuk.ApplicationCore.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MISA.CukCuk.Infrastructure
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        #region Declare
        IConfiguration _configuration;
        string _connectionString = string.Empty;
        IDbConnection _dbConnection = null;
        string _tableName;
        #endregion

        #region Constructor
        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("MISACukCukConnectionString");
            _dbConnection = new MySqlConnection(_connectionString);
            _tableName = typeof(TEntity).Name;
        }

        #endregion

        #region method
        public int Add(TEntity entity)
        {
            //Khởi tạo kết nối với Database
            var parameters = MappingDbType(entity);
            //Thực thi commandText
            var rowAffect = _dbConnection.Execute($"Proc_Insert{_tableName}", parameters, commandType: CommandType.StoredProcedure);
            //Trả về số bản ghi thêm mới được
            return rowAffect;
        }

        public int Delete(Guid entityId)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add($"@{_tableName}Id", entityId, DbType.String);
            var rowAffects = _dbConnection.Execute($"Proc_Delete{_tableName}ById", param, commandType: CommandType.StoredProcedure);
            return rowAffects;
        }

        public IEnumerable<TEntity> GetEntities()
        {
            //Khởi tạo các commandText
            var entities = _dbConnection.Query<TEntity>($"Proc_Get{_tableName}s", commandType: CommandType.StoredProcedure);
            return entities;
        }

        public IEnumerable<TEntity> GetEntityById(Guid entityId)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add($"@{_tableName}Id", entityId, DbType.String);
            var entity = _dbConnection.Query<TEntity>($"Proc_Get{_tableName}ById", param, commandType: CommandType.StoredProcedure);
            return entity;
        }

        public TEntity GetEntityByProperty(TEntity entity, PropertyInfo property)
        {
            var propertyName = property.Name;
            var propertyValue = property.GetValue(entity);
            var keyValue = entity.GetType().GetProperty($"{_tableName}Id").GetValue(entity);
            var query = string.Empty;
            if (entity.EntityState == EntityState.AddNew)
            {
                query = $"SELECT *FROM {_tableName} WHERE {propertyName} = '{propertyValue}'";
            }
            else
            {
                if(entity.EntityState == EntityState.Update)
                {
                    query = $"SELECT *FROM {_tableName} WHERE {propertyName} = '{propertyValue}' AND {_tableName}Id <> '{keyValue}'";
                }
                else
                {
                    return null;
                }
            }
           
            var entityReturn = _dbConnection.Query<TEntity>(query, commandType: CommandType.Text).FirstOrDefault();
            return entityReturn;
        }   

        public int Update(TEntity entity)
        {
            var parameters = MappingDbType(entity);
            var rowAffects = _dbConnection.Execute($"Proc_Update{_tableName}ById", parameters, commandType: CommandType.StoredProcedure);
            return rowAffects;
        }

        /// <summary>
        /// Mapping DB
        /// </summary>
        /// <typeparam name="TEntity">Kiểu dữ liệu bất kì</typeparam>
        /// <param name="entity">Kiểu dữ liệu bất kì</param>
        /// <returns></returns>
        /// CreatedBy: LVTHO (18/01/2021)
        private DynamicParameters MappingDbType(TEntity entity)
        {
            var properties = entity.GetType().GetProperties();
            var parameters = new DynamicParameters();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                var propertyType = property.PropertyType;
                if (propertyType == typeof(Guid) || propertyType == typeof(Guid?))
                {
                    parameters.Add($"@{propertyName}", propertyValue, DbType.String);
                }
                else
                {
                    parameters.Add($"@{propertyName}", propertyValue);
                }
            }

            return parameters;
        }

        #endregion
    }
}
