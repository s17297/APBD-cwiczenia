using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace cwiczenia_2.Models
{
    [Serializable]

    public class Studies
    {
        [JsonPropertyName("Course")]
        public string Course { get; set; }
        [JsonPropertyName("Mode")]
        public string Mode { get; set; }
    }
}
