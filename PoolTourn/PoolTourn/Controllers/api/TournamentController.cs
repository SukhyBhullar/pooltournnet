using PoolTourn.Domain.Models;
using PoolTourn.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PoolTourn.Controllers.api
{
    public class TournamentController : ApiController
    {

        private ITournamentService _tournamentService;

        public TournamentController(ITournamentService tournamentService)
        {
            _tournamentService = tournamentService;
        }

        // GET: api/Tournament
        public Tournament Get()
        {
            return _tournamentService.GetTournamentInProgress();
        }

        // POST: api/Tournament
        public Tournament Post([FromBody]Tournament value)
        {
            return _tournamentService.CreateNewTournament(value);
        }

    }
}
