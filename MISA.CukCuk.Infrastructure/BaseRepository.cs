﻿using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.CukCuk.ApplicationCore.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.CukCuk.Infrastructure
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
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
            var rowAffects = _dbConnection.Execute($"Proc_Delete{_tableName}ById", new { EntityId = entityId }, commandType: CommandType.StoredProcedure);
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
            var entity = _dbConnection.Query<TEntity>($"Proc_Get{_tableName}ById", new { EntityId = entityId }, commandType: CommandType.StoredProcedure);
            return entity;
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