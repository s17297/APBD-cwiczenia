using Kolokwium_1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ChampionshipController : ControllerBase
    {
        SqlDbService _sqlDbService;
        public ChampionshipController(SqlDbService service)
        {
            _sqlDbService = service;
        }
        [HttpGet]
        public IActionResult GetTeams(int idChampionship)
        {

            return Ok(_sqlDbService.GetTeams(idChampionship));
        }
        
    }
}
