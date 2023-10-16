using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FalloutRPDAL.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // Foreign Keys
        public IEnumerable<Player> Players { get; set; } = new List<Player>();
        public IEnumerable<Data> Datas { get; set; } = new List<Data>();
    }
}
