using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.ApplicationCore.Entities;
using MISA.CukCuk.ApplicationCore.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Controllers
{
    /// <summary>
    /// Danh mục nhóm khách hàng
    /// </summary>
    /// CreatedBy: LVTHO (18/01/2021)
    public class CustomerGroupsController : BaseController<CustomerGroup>
    {
        IBaseService<CustomerGroup> _baseService;
        public CustomerGroupsController(IBaseService<CustomerGroup> baseService) : base(baseService)
        {
            _baseService = baseService;
        }

        #region
        //#region 
        //ICustomerGroupService _customerGroupService;
        //public CustomerGroupsController(ICustomerGroupService customerGroupService)
        //{
        //    _customerGroupService = customerGroupService;
        //}
        //#endregion

        ///// <summary>
        ///// Lấy danh sách nhóm khách hàng
        ///// </summary>
        ///// <returns>Danh sách nhóm khách hàng</returns>
        ///// CreatedBy: LVTHO (16/01/2021)
        //[HttpGet]
        //public IActionResult GetCustomerGroups()
        //{
        //    var customerGroups = _customerGroupService.GetCustomerGroups();
        //    return Ok(customerGroups);
        //}

        //[HttpGet("{id}")]
        //public IActionResult GetCustomerGroupById(string id)
        //{
        //    var customerGroup = _customerGroupService.GetCustomerGroupById(id);
        //    return Ok(customerGroup);
        //}

        //[HttpPost]
        //public IActionResult InsertCustomerGroup()
        //{
        //    return Ok();
        //}

        //[HttpPut]
        //public IActionResult UpdateCustomerGroupById()
        //{
        //    return Ok();
        //}

        //[HttpDelete]
        //public IActionResult DeleteCustomerGroup()
        //{
        //    return Ok();
        //}
        #endregion
    }
}
