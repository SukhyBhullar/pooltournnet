using PoolTourn.Data.Providers;
using PoolTourn.Domain.Models;
using PoolTourn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoolTourn.Services
{
    public class PlayerService : PoolTourn.Services.IPlayerService
    {
        IPlayerProvider _playerprovider;

        public PlayerService(IPlayerProvider playerprovider)
        {
            _playerprovider = playerprovider;
        }

        public IEnumerable<Player> GetAll(int TournamentId)
        {
            return _playerprovider.RetrieveByTournament(TournamentId);
        }
    }
}