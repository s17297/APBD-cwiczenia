using kolokwium_poprawa.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium_poprawa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirefighterController : ControllerBase
    {
        private readonly IFireTruckService _FireTruckService;
        public FirefighterController(IFireTruckService fireTruckService)
        {
            _FireTruckService = fireTruckService;
        }
        public IActionResult GetFireTruckById(int id)
        {
            var FireTruck = _FireTruckService.GetFiretruckById(id);

            return Ok(FireTruck);
        }
        public IActionResult UpdateEndTime(int id, DateTime dateTime)
        {
            _FireTruckService.UpdateEndTime(id, dateTime);
            return Ok();
        }
    }
}
