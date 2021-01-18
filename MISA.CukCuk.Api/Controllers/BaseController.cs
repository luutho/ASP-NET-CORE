using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.ApplicationCore.Enums;
using MISA.CukCuk.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TEntity> : ControllerBase
    {
        IBaseService<TEntity> _baseService;
        public BaseController(IBaseService<TEntity> baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public IActionResult GetEntities()
        {
            var customers = _baseService.GetEntities();
            return Ok(customers);
        }


        [HttpGet("GetEntityById/{id}")]
        public IActionResult GetEntityById(string id)
        {
            var entities = _baseService.GetEntityById(Guid.Parse(id));
            return Ok(entities);
        }


        [HttpPost]
        public IActionResult Add(TEntity entity)
        {
            var res = _baseService.Add(entity);
            return Ok(res);
            //if (serviceResult.MISACode == MISACode.NotValid)
            //{
            //    return BadRequest(serviceResult.Data);
            //}

            //if (serviceResult.MISACode == MISACode.IsValid && (int)serviceResult.Data > 0)
            //{
            //    return Created("", serviceResult);
            //}
            //else
            //{
            //    return NoContent();
            //}

        }


        [HttpPut]
        public IActionResult PutCustomer(TEntity entity)
        {
            var res = _baseService.Update(entity);
            return Ok(res);
            //if (serviceResult.MISACode == MISACode.NotValid)
            //{
            //    return BadRequest(serviceResult.Data);
            //}

            //if (serviceResult.MISACode == MISACode.IsValid && (int)serviceResult.Data > 0)
            //{
            //    return Created("", serviceResult);
            //}
            //else
            //{
            //    return NoContent();
            //}
        }


        [HttpDelete("DeleteById/{entityId}")]
        public IActionResult DeleteCustomerByCode(string entityId)
        {
            var res = _baseService.Delete(Guid.Parse(entityId));
            return Ok(res);

            //if (serviceResult.MISACode == MISACode.NotValid)
            //{
            //    return BadRequest(serviceResult.Data);
            //}

            //if (serviceResult.MISACode == MISACode.IsValid && (int)serviceResult.Data > 0)
            //{
            //    return Created("", customerId);
            //}
            //else
            //{
            //    return NoContent();
            //}
        }
    }
}
