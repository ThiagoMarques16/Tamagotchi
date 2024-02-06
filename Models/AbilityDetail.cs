using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _7DaysOfCodeTamagotchi.Models
{
    public class AbilityDetail
    {
        public Ability Ability { get; set; }
        public bool IsHidden { get; set; }
        public int Slot { get; set; }
    }
}