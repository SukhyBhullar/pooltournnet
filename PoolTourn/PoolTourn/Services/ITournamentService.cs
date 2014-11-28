using PoolTourn.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoolTourn.Services
{
    public interface ITournamentService
    {
        Tournament GetTournamentInProgress();
        Tournament CreateNewTournament(Tournament NewTournament);
    }
}
