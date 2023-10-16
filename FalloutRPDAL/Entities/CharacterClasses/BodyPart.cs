using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FalloutRPDAL.Entities.CharacterClasses
{
    public class BodyPart
    {
        public int Id { get; set; }
        public int Part { get; set; }
        public int PhysicalResilience { get; set; }
        public int RadiationResilience { get; set; }
        public int EnergyResilience { get; set; }
        public int HealthResilience { get; set; }

        // Foreign Keys
        public int CharacterId { get; set; }
        public Character Character { get; set; }
    }
}
