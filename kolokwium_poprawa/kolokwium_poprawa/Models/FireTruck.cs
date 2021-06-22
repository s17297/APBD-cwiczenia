using System.Collections.Generic;

namespace kolokwium_poprawa.Models
{
    public class FireTruck
    {
        public string OperationalNumber { get; set; }
        public bool? SpecialEquipment { get; set; }
        public List<Action> Actions { get; set; }
    }
}
