using PoolTourn.Domain.Models;
using System;
using System.Collections.Generic;
namespace PoolTourn.Services
{
    public interface IPlayerService
    {
        IEnumerable<Player> GetAll(int TournamentId);
    }
}
