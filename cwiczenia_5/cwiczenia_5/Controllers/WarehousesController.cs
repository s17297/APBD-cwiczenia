using cwiczenia_5.Models;
using cwiczenia_5.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cwiczenia_5.Controllers
{
    [ApiController]

    [Route("api/warehouses")]
    public class WarehousesController : ControllerBase
    {
        private readonly IWarehouseService _warehouseService;
        public WarehousesController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;

        }
        [HttpPost]
        public IActionResult AddOrder(Order order)
        {

            _warehouseService.CreateOrder(order);
            /* _sqlDbService.CreateOrder(order);*/

            return Ok();
        }
    }
}
