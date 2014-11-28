using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoolTourn.Domain.Models
{
    public class Tournament
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool InProgress { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}
