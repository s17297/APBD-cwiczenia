using cwiczenia_4.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace cwiczenia_4.Controllers
{
    [Route("api/animals")]
    [ApiController]
    public class AnimalController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetAnimals(string orderBy)
        {
            string qOrderBy = "name";
            if (orderBy != null)
            {
                qOrderBy = orderBy;
            }
            //Console.WriteLine(qOrderBy);
            SqlConnection con = new SqlConnection("Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s17297;Integrated Security=True");
            SqlCommand com = new SqlCommand();
            com.CommandText = ("Select * from Animal order by " + qOrderBy);
            com.Connection = con;

            con.Open();
            SqlDataReader dr = com.ExecuteReader();
            var animalsList = new List<Animal>();

            while (dr.Read())
            {
                animalsList.Add(new Animal
                {
                    Name = dr["Name"].ToString(),
                    Description = dr["Description"].ToString(),
                    Category = dr["Category"].ToString(),
                    Area = dr["Area"].ToString()

                });
            }
            con.Dispose();
            return Ok(animalsList);
        }
        [HttpPost]
        public IActionResult AddAnimal(Animal newAnimal)
        {
            Animal animal = newAnimal;
            SqlConnection con = new SqlConnection("Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s17297;Integrated Security=True");
            SqlCommand com = new SqlCommand();
            com.CommandText = ("insert into Animal values ('" + newAnimal.Name.ToString() + "', '" + newAnimal.Description.ToString() + "', '" + newAnimal.Category.ToString() + "', '" + newAnimal.Area.ToString() + "')");
            com.Connection = con;
            con.Open();
            com.ExecuteNonQuery();
            con.Dispose();
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAnimal(int id)
        {
            SqlConnection con = new SqlConnection("Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s17297;Integrated Security=True");
            SqlCommand com = new SqlCommand();
            com.CommandText = ("delete from Animal where idAnimal = " + id);
            com.Connection = con;
            con.Open();
            com.ExecuteNonQuery();
            con.Dispose();
            return Ok();
        }
    }
}
