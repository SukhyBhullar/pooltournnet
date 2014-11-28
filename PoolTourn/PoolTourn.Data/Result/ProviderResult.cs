using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoolTourn.Data.Result
{

    public enum ProviderStatusCode
    {
        OK = 0,
        NotFound = 1,
        Conflict = 2
    }

    public class ProviderResult<T>
    {
 

        public ProviderStatusCode Status { get; set; }

        public T Value { get; set; }
    }
}
