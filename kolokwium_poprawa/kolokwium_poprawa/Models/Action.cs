using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium_poprawa.Models
{
    public class Action
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int? FireFighterCount { get; set; }
        public DateTime AssignmentDate { get; set; }
    }
}
