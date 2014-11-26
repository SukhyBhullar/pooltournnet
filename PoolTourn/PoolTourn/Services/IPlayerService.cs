using PoolTourn.Domain.Models;
using System;
using System.Collections.Generic;
namespace PoolTourn.Services
{
    public interface IPlayerService
    {
        IEnumerable<PlayerModel> GetAll(int TournamentId);
    }
}
