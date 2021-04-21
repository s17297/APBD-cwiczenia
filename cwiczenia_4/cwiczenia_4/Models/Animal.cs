using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cwiczenia_4.Models
{
    public class Animal
    {
        [Required]
        [MaxLength(200, ErrorMessage ="Maks. 200 znakow")]
        public string Name { get; set; }
        [MaxLength(200, ErrorMessage = "Maks. 200 znakow")]
        public string Description { get; set; }
        [Required]
        [MaxLength(200, ErrorMessage = "Maks. 200 znakow")]
        public string Category { get; set; }
        [Required]
        [MaxLength(200, ErrorMessage = "Maks. 200 znakow")]
        public string Area { get; set; }

    }
}
