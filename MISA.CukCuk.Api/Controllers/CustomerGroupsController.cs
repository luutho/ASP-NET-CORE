using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.ApplicationCore.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerGroupsController : Controller
    {
        #region 
        ICustomerGroupService _customerGroupService;
        public CustomerGroupsController(ICustomerGroupService customerGroupService)
        {
            _customerGroupService = customerGroupService;
        }
        #endregion

        [HttpGet]
        public IActionResult GetCustomerGroups()
        {
            var customerGroup = _customerGroupService.GetCustomerGroups();
            return Ok(customerGroup);
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerGroupById()
        {
            return View();
        }

        [HttpPost]
        public IActionResult InsertCustomerGroup()
        {
            return View();
        }

        [HttpPut]
        public IActionResult UpdateCustomerGroupById()
        {
            return View();
        }

        [HttpDelete]
        public IActionResult DeleteCustomerGroup()
        {
            return View();
        }
    }
}
