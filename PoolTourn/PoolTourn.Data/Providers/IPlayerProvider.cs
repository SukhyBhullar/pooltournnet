using PoolTourn.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoolTourn.Data.Providers
{
    public interface IPlayerProvider
    {
        IEnumerable<PlayerModel> Retrieve(int TournamentID);
    }
}
