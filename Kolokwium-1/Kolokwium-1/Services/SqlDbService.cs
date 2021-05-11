using Kolokwium_1.DTOs.Responses;
using Kolokwium_1.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium_1.Services
{ 
    public interface IDatabaseService
    {
    IEnumerable<ChampionshipRequest> GetTeams(int idChampionship);
    }

    public class SqlDbService : IDatabaseService
    {
        
        private const string connectionString = "Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog = s17297; Integrated Security = True";


        
        

  

public IEnumerable<ChampionshipRequest> GetTeams(int idChampionship)
    {
            using var con = new SqlConnection("ConnectionString");
            using var com = new SqlCommand("Select t.IdTeam, t.TeamName, t.MaxAge, ct.Score from Team t inner join Championship_Team ct on t.IdTeam = ct.IdTeam where ct.IdChampionship = @IdChampionship", con);
            com.Parameters.AddWithValue("@IdChampionship", idChampionship);
            con.Open();
            var dr = com.ExecuteReader();
            var result = new List<ChampionshipRequest>();
            while (dr.Read())
            {
                result.Add(new ChampionshipRequest
                { 
                    IdTeam = (int)dr["IdTeam"],
                    TeamName = dr["TeamName"].ToString(),
                    MaxAge = (int)dr["MaxAge"],
                    Score = (float)dr["Score"]
                    });

            }


            throw new NotImplementedException();
    }
}
          
        



    }
}
