using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FalloutRPDAL.Entities.CharacterClasses
{
    internal class Perk
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Rank { get; set; }
        public string Effect { get; set; } = string.Empty;

        // Foreign Keys
        public Character? Character { get; set; }
        public int CharacterId { get; set; }
    }
}
