using kolokwium_poprawa.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium_poprawa.Services
{
    public interface IFireTruckService
    {
        public void UpdateEndTime(int id, DateTime endTime);
        public FireTruck GetFiretruckById(int id);
    }

    public class FireTruckService
    {
        private readonly string _connectionString;

        public FireTruckService(
            IConfiguration config
            )
        {
            _connectionString = config.GetConnectionString("FireDepartment");
        }

        public FireTruck GetFireTruckById(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);

            using DataTable dt1 = new DataTable();
            using SqlCommand command1 = new SqlCommand()
            {
                Connection = connection,
                CommandType = CommandType.Text,
                CommandText = @$"
                    select
                        ft.OperationalNumber,
                        ft.SpecialEquipment,
                    from FireTruck ft
                    where ft.IdFireTruck = {id}
                ",
                CommandTimeout = 5
            };

            using DataTable dt2 = new DataTable();
            using SqlCommand command2 = new SqlCommand()
            {
                Connection = connection,
                CommandType = CommandType.Text,
                CommandText = @$"
                    select
                        fta.AssignmentDate,
                        a.StartTime,
                        a.EndTime,
                        count(f.IdFirefighter) as FirefighterCount
                    from FireTruck_Action fta
                    join Action a on a.IdAction = fta.IdAction
                    join Firefighter_Action fa on fa.IdAction = a.IdAction
                    join Firefighter f on f.IdFirefighter = fa.IdFirefighter
                    where fta.IdFireTruck = {id}
                    group by
                        fta.AssignmentDate,
                        a.StartTime,
                        a.EndTime
                    order by a.EndTime desc;
                ",
                CommandTimeout = 5
            };


            connection.Open();
            dt1.Load(command1.ExecuteReader());
            dt2.Load(command2.ExecuteReader());

            FireTruck fireTruck = new FireTruck
            {
                OperationalNumber = dt1?.Rows?[0]?["OperationalNumber"]?.ToString(),
                SpecialEquipment = (bool?)(dt1?.Rows?[0]?["SpecialEquipment"]),
                Actions = new List<Models.Action>()
            };

            foreach (DataRow row in dt2.Rows)
                fireTruck.Actions.Add(new Models.Action {
                    StartTime = DateTime.Parse(row["StartTime"]?.ToString()),
                    EndTime = DateTime.Parse(row["EndTime"]?.ToString()),
                    AssignmentDate = DateTime.Parse(row["AssignmentDate"]?.ToString()),
                    FireFighterCount = (int?)row["FirefighterCount"]
                });

            return fireTruck;
        }
        public void UpdateEndTime(int id, DateTime endTime)
        {
            using var con = new SqlConnection(_connectionString);
            using var com = new SqlCommand("UpdateEndTime", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("IdAction", id);
            com.Parameters.AddWithValue("EndTime", endTime);
            con.Open();
            try
            {
                com.ExecuteNonQuery();
            }
            catch (SqlException )
            {
                throw new Exception();
            }
        }
    }
}
