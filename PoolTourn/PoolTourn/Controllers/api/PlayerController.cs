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
    public class PlayerController : ApiController
    {

        IPlayerService _playerservice;
        public PlayerController(IPlayerService playerservice)
        {
            _playerservice = playerservice;
        }

        // GET: api/Player
        public IEnumerable<Player> Get()
        {
            return _playerservice.GetAll(1);
        }

        // GET: api/Player/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Player
        public void Post([FromBody]Player value)
        {
        }

        // PUT: api/Player/5
        public void Put(int id, [FromBody]Player value)
        {
        }

        // DELETE: api/Player/5
        public void Delete(int id)
        {
        }
    }
}
