using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace cwiczenia_2.Models
{
    [Serializable]
    public class Student
    {
        [JsonPropertyName("FirstName")]
        public string FirstName { get; set; }
        [JsonPropertyName("LastName")]
        public string LastName { get; set; }
        [JsonPropertyName("Index_number")]
        public string Index_number { get; set; }
        [JsonPropertyName("BirthDate")]
        public string BirthDate { get; set; }
        [JsonPropertyName("Email")]
        public string Email { get; set; }
        [JsonPropertyName("MothersName")]
        public string MothersName { get; set; }
        [JsonPropertyName("FathersName")]
        public string FathersName { get; set; }
        [JsonPropertyName("Studies")]
        public Studies Studies { get; set; }

        public override string ToString()
        {
            return (FirstName+ ","+LastName+","+Index_number+","+BirthDate+","+Studies.ToString()+","+Email+","+FathersName+","+MothersName+"\n");

        }
    }
}
