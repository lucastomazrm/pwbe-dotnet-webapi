using PWBE.TeamAthlete.Models;
using Microsoft.AspNetCore.Mvc;
using PWBE.TeamAthlete.Services;
using System.Collections.Generic;

namespace PWBE.TeamAthlete.Web.Controllers
{
    [Route("api/[controller]")]
    public class TeamsController : Controller
    {
        protected TeamService Service = new TeamService();

        [HttpGet("{id}")]
        public Team Get(int id)
        {
            return Service.Get(id);
        }

        [HttpGet]
        public IEnumerable<Team> Get()
        {
            return this.Service.All();
        }

        [HttpPost]
        public Team Post([FromBody]Team model)
        {
            this.Service.Save(model);
            return model;
        }

        [HttpPut]
        public Team Put([FromBody]Team model)
        {
            this.Service.Update(model);
            return model;
        }

        [HttpDelete]
        public void Delete(int id)
        {
            this.Service.Delete(id);
        }
    }
}