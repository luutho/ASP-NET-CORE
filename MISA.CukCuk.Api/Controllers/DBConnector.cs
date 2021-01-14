using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Controllers
{
    public class DBConnector
    {
        #region Declare
        /// <summary>
        /// Kết nối Database
        /// </summary>
        /// CreatedBy: LVTHO (14/01/2021)

        // Khai báo thông tin kết nối
        string _connectionString = "User Id=nvmanh;" +
            "Host=103.124.92.43;" +
            "Port=3306;" +
            "Database=MISACukCuk-MF662-LVTHO;" +
            "Password=12345678;" +
            "Character Set=utf8";
        // Khởi tạo đối tượng kết nối
        IDbConnection dbConnection;
        #endregion

        #region Constructor
        public DBConnector()
        {
            dbConnection = new MySqlConnection(_connectionString);
        }
        #endregion

        #region Method

        /// <summary>
        /// Lấy danh sách 
        /// </summary>
        /// <returns>Danh sách nhóm khách hàng</returns>
        /// CreatedBy: LVTHO (14/01/2021)
        //[HttpGet]
        //public IEnumerable<MISAEntity> Get<MISAEntity>(string name)
        //{
        //    return ;
        //}

        #endregion
    }
}
