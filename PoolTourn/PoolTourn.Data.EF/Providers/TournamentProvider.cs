using PoolTourn.Data.EF.Context;
using PoolTourn.Data.Result;
using PoolTourn.Data.Providers;
using PoolTourn.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoolTourn.Data.EF.Providers
{
    public class TournamentProvider : ITournamentProvider
    {

        public ProviderResult<Tournament> Create(Tournament tournament)
        {
            using (TournContext db = new TournContext())
            {
                db.Tournament.Add(tournament);
                db.SaveChanges();
            }

            return new ProviderResult<Tournament>() { Status = ProviderStatusCode.OK, Value = tournament};
        }
        
        public Tournament RetrieveOne(Func<Tournament, bool> Clause)
        {
            using (TournContext db = new TournContext())
            {
                return db.Tournament.SingleOrDefault(Clause);
            }
        }
    }
}
