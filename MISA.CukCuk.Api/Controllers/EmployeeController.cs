using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.ApplicationCore.Entities;
using MISA.CukCuk.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Controllers
{
    public class EmployeeController : BaseController<Employee>
    {
        IBaseService<Employee> _baseService;
        public EmployeeController(IBaseService<Employee> baseService) : base(baseService)
        {
            _baseService = baseService;
        }
    }
}
