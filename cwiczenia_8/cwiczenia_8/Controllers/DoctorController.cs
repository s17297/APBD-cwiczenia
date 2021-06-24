using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cwiczenia_8.Models;
using Microsoft.AspNetCore.Mvc;

namespace cwiczenia_8.Models
{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private IDbService _context;
        public DoctorController(IDbService context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetDoctors()
        {
            var list = _context.GetDoctors();
            return Ok(list);
        }
        [HttpPost]
        public IActionResult AddDoctor(Doctor d)
        {
            if (_context.AddDoctor(d))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public IActionResult ModifyDoctor(Doctor d)
        {
            if (_context.ModifyDoctor(d))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        public IActionResult DeleteDoctor(Doctor d)
        {
            if (_context.DeleteDoctor(d))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}