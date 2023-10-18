using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FalloutRPDAL.Entities.CharacterClasses
{
    public class Weapon
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int TN { get; set; }
        public int DC { get; set; }
        public bool PhysicalDamage { get; set; }
        public bool EnergyDamage { get; set; }
        public bool RadiationDamage { get; set; }
        public bool PoisonDamage { get; set; }
        public string Effects { get; set; } = string.Empty;
        public string Proprieties { get; set; } = string.Empty;
        public int RateOfFire { get; set; }
        public int Range { get; set; }
        public int Ammo { get; set; }
        public float Weigth { get; set; }

        // Foreign Keys
        public int CharacterId { get; set; }
        public Character Character { get; set; }
    }
}
