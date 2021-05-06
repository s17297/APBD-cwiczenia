using cwiczenia_5.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace cwiczenia_5.Services
{
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    [ApiController]
    public class SqlDbService : IWarehouseRequest
        
    {
        private const string connectionString = "Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s17297;Integrated Security=True";

        public IEnumerable<Order> CreateOrder()
        {   
            //Tworzenie połączenia i transakcji

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                using (SqlTransaction tr = cn.BeginTransaction())
                {
                    //jakis kod

                    //Commit transakcji
                    tr.Commit();
                    // Zamykamy połączenie
                    cn.Close();
                }
            }

            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetOrders()
        {
            throw new NotImplementedException();
        }
    }
}
