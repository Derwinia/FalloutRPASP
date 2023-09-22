using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FalloutRPDAL.Entities.CharacterClasses
{
    public class Attribute
    {
        public int Id { get; set; }
        public int Strength { get; set; }
        public int Perception { get; set; }
        public int Endurance { get; set; }
        public int Charisme { get; set; }
        public int Intelligence { get; set; }
        public int Agility { get; set; }
        public int Luck { get; set; }
        public int LuckPoints { get; set; }

        // Foreign Keys
        public int CharacterId { get; set; }
    }
}
