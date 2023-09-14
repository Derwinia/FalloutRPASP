using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FalloutRPDAL.Entities.CharacterClasses
{
    internal class Reputation
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Rank { get; set; }

        // Foreign Keys
        public Character? Character { get; set; }
        public int CharacterId { get; set; }
    }
}
