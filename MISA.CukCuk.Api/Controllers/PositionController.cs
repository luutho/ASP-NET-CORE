using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.ApplicationCore.Entities;
using MISA.CukCuk.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Controllers
{
    public class PositionController : BaseController<Position>
    {
        IBaseService<Position> _baseService;
        public PositionController(IBaseService<Position> baseService) : base(baseService)
        {
            _baseService = baseService;
        }
    }
}
