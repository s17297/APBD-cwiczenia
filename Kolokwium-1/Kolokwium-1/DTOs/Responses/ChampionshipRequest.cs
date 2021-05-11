using Kolokwium_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium_1.DTOs.Responses
{
    public class ChampionshipRequest
    {
        public int IdTeam { get; set; }
        public string TeamName { get; set; }
        public int MaxAge { get; set; }
        public float Score { get; set; }
    }
}
