using PoolTourn.Data.Providers;
using PoolTourn.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoolTourn.Services
{
    public class TournamentService : ITournamentService
    {
        ITournamentProvider _tournamentProvider;

        public TournamentService(ITournamentProvider tournamentProvider)
        {
            _tournamentProvider = tournamentProvider;
        }

        public Tournament GetTournamentInProgress()
        {
            return _tournamentProvider.GetTournamentInProgress().Value;
        }

        public Tournament CreateNewTournament(Tournament NewTournament)
        {
            if (GetTournamentInProgress() == null)
            {

                NewTournament.InProgress = true;

                var result = _tournamentProvider.Create(NewTournament);
                if (result.Status == Data.Result.ProviderStatusCode.Ok)
                {
                    return result.Value;
                }
                return null;
            }
            return null;
        }
    }
}