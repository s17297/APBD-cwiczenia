using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium_1.Models
{
    public class Championship
    {
        [Required]
        public int IdChampionship { get; set; }
        [Required]
        public string OfficialName { get; set; }
        [Required]
        public int Year { get; set; }
    }
}
