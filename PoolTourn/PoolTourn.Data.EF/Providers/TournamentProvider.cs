using PoolTourn.Data.EF.Context;
using PoolTourn.Data.Result;
using PoolTourn.Data.Providers;
using PoolTourn.Domain.Models;
using System;
using System.Linq;

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

            return new ProviderResult<Tournament>() { Status = ProviderStatusCode.Ok, Value = tournament};
        }
        
        public ProviderResult<Tournament> GetTournamentInProgress()
        {
            using (TournContext db = new TournContext())
            {
                return new ProviderResult<Tournament>
                {
                    Status = ProviderStatusCode.Ok,
                    Value = db.Tournament.SingleOrDefault(x => x.InProgress == false)
                };
            }
        }
    }
}
