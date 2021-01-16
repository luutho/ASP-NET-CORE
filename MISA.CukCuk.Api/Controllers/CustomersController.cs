using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using MISA.CukCuk.ApplicationCore;
using MISA.CukCuk.ApplicationCore.Entities;
using MISA.CukCuk.ApplicationCore.Interfaces;
using MISA.CukCuk.ApplicationCore.Enums;

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        ICustomerService _customerService;
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        

        /// <summary>
        /// Lấy dữ liệu khách hàng
        /// </summary>
        /// <returns></returns>
        /// CretedBy: LVTHO (08/01/2021)
        [HttpGet]
        public IActionResult GetCustomer()
        {
            var customers = _customerService.GetCustomers();
            return Ok(customers);
        }

        //#region
        ///// <summary>
        ///// Thêm dữ liệu khách hàng
        ///// </summary>
        ///// <returns></returns>
        ///// CreatedBy: LVTHO (08/01/2021)

        //[HttpGet("a")]
        //public IActionResult GetCustomer()
        //{

        //    var customers = new List<Customer>();
        //    for (int i = 0; i < 10; i++)
        //    {
        //        var customer = new Customer();
        //        customer.CustomerId = Guid.NewGuid();
        //        customer.FullName = $"Lưu Văn Thọ {i}";
        //        customer.DateOfBirth = null;
        //        customer.PhoneNumber = $"012345678{i}";
        //        customer.Address = $"Thái Bình {i}";
        //        customer.CompanyName = $"MISA {i}";
        //        customer.CustomerGroupId = Guid.NewGuid();
        //        customer.CustomerCode = $"MF662{i}";
        //        customer.Email = $"thomailso{i}@gmail.com";
        //        customers.Add(customer);
        //    }
        //    return Ok(customers);
        //}
        //#endregion

        /// <summary>
        /// Lấy danh sách khách hàng theo CustomerId
        /// </summary>
        /// <param name="id">Truyền vào Id khách hàng kiểu string</param>
        /// <returns></returns>
        /// CreatedBy: LVTHO(11/01/2021)
        [HttpGet("GetCustomerById/{id}")]
        public IActionResult GetCustomerById(Guid id)
        {
            var customers = _customerService.GetCustomerById(id);
            return Ok(customers);
        }

        /// <summary>
        /// Tìm kiếm khách hàng theo mã khách hàng
        /// </summary>
        /// <param name="code">Mã khách hàng</param>
        /// <returns></returns>
        /// CreatedBy: LVTHO (12/01/2021)
        [HttpGet("GetCustomerByCode/{code}")]
        public IActionResult GetCustomerByCode(string code)
        {
            var customers = _customerService.GetCustomerByCode(code);
            return Ok(customers);
        }

        //Code demo Get
        //#region
        ///// <summary>
        ///// Lấy thông tin khách hàng theo Id
        ///// </summary>
        ///// <param name="customerId">Id của khách hàng</param>
        ///// <returns></returns>
        ///// CreatedBy: LVTHO (08/01/2021)
        //[HttpGet("{customerId}")]
        //public IActionResult GetCustomer(Guid customerId)
        //{
        //    return Ok(new Customer());
        //}

        ///// <summary>
        ///// Lấy dữ liệu theo name, age
        ///// </summary>
        ///// <param name="name">Tên khách hàng</param>
        ///// <param name="age">Tuổi khách hàng</param>
        ///// <returns></returns>
        ///// CreatedBy: LVTHO (08/01/2021)
        //[HttpGet("b/{name},{age}")] //hoặc [HttpGet("b/{name}/{age}")]
        //public string GetCustomerB(string name, int? age) // dấu "?" chô phép age nhận giá trị null
        //{
        //    var nameString = name == null ? "null" : name;
        //    return $"GET B Name: {nameString}, Age: {age} ";
        //}

        ///// <summary>
        ///// Lấy dữ liệu bằng querystring theo name, age
        ///// </summary>
        ///// <param name="name">Tên khách hàng</param>
        ///// <param name="age">Tuổi khách hàng</param>
        ///// <returns></returns>
        ///// CreatedBy: LVTHO (08/01/2021)
        //[HttpGet("c")] //gửi dữ liệu bằng querystring . nhập dữ liệu trực tiếp trong đường dẫn
        //public string GetCustomerC(string name, int? age)
        //{
        //    var nameString = name == null ? "null" : name;
        //    return $"GET B Name: {nameString}, Age: {age} ";
        //}
        //#endregion

        /// <summary>
        /// Thêm 1 khách hàng
        /// </summary>
        /// <param name="customer">Truyền vào 1 object khách hàng</param>
        /// <returns></returns>
        /// CreatedBy: LVTHO (11/01/2021)
        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            var serviceResult = _customerService.AddCustomer(customer);

            if (serviceResult.MISACode == MISACode.NotValid)
            {
                return BadRequest(serviceResult.Data);
            }

            if (serviceResult.MISACode == MISACode.IsValid && (int)serviceResult.Data > 0)
            {
                return Created("", serviceResult);
            }
            else
            {
                return NoContent();
            }

        }

        /// <summary>
        /// Hàm update dữ liệu khách hàng
        /// </summary>
        /// <param name="customer">truyền vào 1 object khách hàng</param>
        /// <returns></returns>
        /// CreatedBy: LVTHO (11/01/2021)
        [HttpPut]
        public IActionResult PutCustomer(Customer customer)
        {
            var serviceResult = _customerService.UpdateCustomer(customer);
            if(serviceResult.MISACode == MISACode.NotValid)
            {
                return BadRequest(serviceResult.Data);
            }

            if(serviceResult.MISACode == MISACode.IsValid && (int)serviceResult.Data > 0)
            {
                return Created("", serviceResult);
            }
            else
            {
                return NoContent();
            }
        }


        

        /// <summary>
        /// Hàm xoá khách hàng theo Id
        /// </summary>
        /// <param name="id">Id khách hàng</param>
        /// <returns></returns>
        /// CreatedBy: LVTHO (11/01/2021)
        [HttpDelete("{customerCode}")]
        public IActionResult DeleteCustomer(string customerCode)
        {
            var serviceResult = _customerService.DeleteCustomer(customerCode);
            if(serviceResult.MISACode == MISACode.NotValid)
            {
                return BadRequest(serviceResult.Data);
            }

            if(serviceResult.MISACode == MISACode.IsValid && (int)serviceResult.Data > 0)
            {
                return Created("", customerCode);
            }
            else
            {
                return NoContent();
            }
        }

        //Code demo Post, Put, Delete
        //#region
        ///// <summary>
        ///// Thêm dữ liệu khách hàng
        ///// </summary>
        ///// <param name="customer">Nhập vào object khách hàng</param>
        ///// <returns></returns>
        ///// CreatedBy: LVTHO (08/01/2021)
        //[HttpPost]
        //public Customer PostCustomer([FromBody] Customer customer)
        //{
        //    customer.FullName = "Lưu Văn Thọ";
        //    return customer;
        //}


        ///// <summary>
        ///// Sửa dữ liệu khách hàng theo Id
        ///// </summary>
        ///// <param name="customerId">Id khách hàng</param>
        ///// <param name="customer">Object khách hàng</param>
        ///// <returns></returns>
        ///// CreatedBy: LVTHO (08/01/2021)
        //[HttpPut("{customerId}")]
        //public IActionResult PutCustomer( Guid customerId, Customer customer)
        //{

        //    return Ok(customer);

        //}

        ///// <summary>
        ///// Xóa khách hàng theo Id
        ///// </summary>
        ///// <param name="customerId">Id khách hàng</param>
        ///// <returns></returns>
        ///// CreatedBy: LVTHO (08/01/2021)
        //[HttpDelete("{customerId}")]
        //public IActionResult DeleteCustomer(Guid customerId)
        //{
        //    return Ok("delete tho");
        //}
        //#endregion
    }
}
