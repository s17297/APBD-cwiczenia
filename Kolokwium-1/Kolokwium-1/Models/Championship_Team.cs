using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium_1.Models
{
    public class Championship_Team
    {
        [Required]
        public int IdChampionshipTeam { get; set; }
        [Required]
        public Team Team { get; set; }
        [Required]
        public Championship Championship { get; set; }
        public float Score { get; set; }
    }
}
