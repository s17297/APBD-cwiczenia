using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium_poprawa.Models
{
    public class Firefighter
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Action> FirefighterAction { get; set; }
    }
}
