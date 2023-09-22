using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FalloutRPDAL.Entities.CharacterClasses
{
    public class Inventory
    {
        public int Id { get; set; }

        // Foreign Keys
        public ICollection<Ammo>? Ammos { get; set; }
        public ICollection<Material>? Materials { get; set; }
        public ICollection<Drink>? Drinks { get; set; }
        public ICollection<Food>? Foods { get; set; }
        public ICollection<Chemical>? Chemicals { get; set; }
        public ICollection<Equipement>? Equipements { get; set; }
        public int CharacterId { get; set; }
    }
}
