using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium_1.Models
{
    public class Team
    {
        [Required]
        public int IdTeam { get; set; }
        [Required]
        public string TeamName { get; set; }
        [Required]
        public int MaxAge { get; set; }
    }
}
