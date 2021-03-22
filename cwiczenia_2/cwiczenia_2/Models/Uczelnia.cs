using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace cwiczenia_2.Models
{
    [Serializable]
    class Uczelnia
    {
        [JsonPropertyName("CreatedAt")]
        public string CreatedAt { get; set; }
        [JsonPropertyName("Author")]
        public string Author { get; set; }
        [JsonPropertyName("Students")]
        public List<Student> Students { get; set; }
       
    }
}
