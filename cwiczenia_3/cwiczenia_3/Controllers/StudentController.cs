using cwiczenia_2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace cwiczenia_3.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        /*public List<Student> _studentsList { get; set; }
        public List<Student> readDataa()
        {
            List<Student> studentsList = new List<Student>();
            string[] source = System.IO.File.ReadAllLines(@".\Data\students.csv");
            foreach (string x in source)
            {
                string[] str = x.Split(",");
                Student tmp = new Student
                {
                    FirstName = str[0].ToString(),
                    LastName = str[1].ToString(),
                    Index_number = str[2].ToString(),
                    BirthDate = str[3].ToString(),
                    Email = str[6].ToString(),

                    MothersName = str[8].ToString(),
                    FathersName = str[7].ToString(),
                    Studies = new Studies { Course = str[4].ToString(), Mode = str[5].ToString() }
                };
                studentsList.Add(tmp);

            };
            return studentsList;

        }*/
        public StudentController()
        {
            //readData();
        }
        
        [HttpGet]
        public async Task<IActionResult> GetStudent()
        {


            List<Student> studentsList = new List<Student>();
            string[] source = await System.IO.File.ReadAllLinesAsync(@".\Data\students.csv");
            foreach (string x in source)
            {
                string[] str = x.Split(",");
                Student tmp = new Student
                {
                    FirstName = str[0].ToString(),
                    LastName = str[1].ToString(),
                    Index_number = str[2].ToString(),
                    BirthDate = str[3].ToString(),
                    Email = str[6].ToString(),

                    MothersName = str[8].ToString(),
                    FathersName = str[7].ToString(),
                    Studies = new Studies { Course = str[4].ToString(), Mode = str[5].ToString() }
                };
                studentsList.Add(tmp);

            };
            return Ok(studentsList);
        }
        [HttpGet("{indexNumber}")]
        public async Task<IActionResult> GetStudent(string indexNumber)
        {
            List<Student> studentsList = new List<Student>();
            string[] source = await System.IO.File.ReadAllLinesAsync(@".\Data\students.csv");
            foreach (string x in source)
            {
                string[] str = x.Split(",");
                Student tmp = new Student
                {
                    FirstName = str[0].ToString(),
                    LastName = str[1].ToString(),
                    Index_number = str[2].ToString(),
                    BirthDate = str[3].ToString(),
                    Email = str[6].ToString(),

                    MothersName = str[8].ToString(),
                    FathersName = str[7].ToString(),
                    Studies = new Studies { Course = str[4].ToString(), Mode = str[5].ToString() }
                };
                studentsList.Add(tmp);

            };
            //studentsList = studentsList;
            foreach (Student st in studentsList)
            {
                if (st.Index_number ==indexNumber)
                {
                    return Ok(st);
                }
            }
            return NotFound("No student with such index number");
        }
        [HttpPost]
        public async Task<IActionResult> CreateStudent(Student student)
        {
            using(StreamWriter sw = System.IO.File.AppendText(@".\Data\students.csv"))
            {
                sw.WriteLineAsync(student.ToString());
            }
            return Ok();

        }
    }
}
