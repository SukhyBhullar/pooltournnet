using PoolTourn.Data.Result;
using PoolTourn.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoolTourn.Data.Providers
{
    public interface ITournamentProvider
    {
        ProviderResult<Tournament> Create(Tournament tournament);
        Tournament RetrieveOne(Func<Tournament, bool> Clause);
        
    }
}
