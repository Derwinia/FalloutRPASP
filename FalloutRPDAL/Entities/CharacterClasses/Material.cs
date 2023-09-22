using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FalloutRPDAL.Entities.CharacterClasses
{
    public class Material
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Weight { get; set; }
        public int TotalWeight { get; set; }

        // Foreign Keys
        public int InventoryId { get; set; }
    }
}
