using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium_1.Models
{
    public class Player_Team
    {
        [Required]
        public int IdPlayerTeam { get; set; }
        [Required]
        public Player Player { get; set; }
        [Required]
        public Team Team { get; set; }
        [Required]
        public int NumOnShirt { get; set; }
        public string Comment { get; set; }
    }
}
