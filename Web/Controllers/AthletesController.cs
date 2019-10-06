using PWBE.TeamAthlete.Models;
using Microsoft.AspNetCore.Mvc;
using PWBE.TeamAthlete.Services;
using System.Collections.Generic;

namespace PWBE.TeamAthlete.Web.Controllers
{
    [Route("api/[controller]")]
    public class AthletesController : Controller
    {

        protected AthleteService Service = new AthleteService();

        [HttpGet("{id}")]
        public Athlete Get(int id)
        {
            return Service.Get(id);
        }

        [HttpGet]
        public IEnumerable<Athlete> Get()
        {
            return this.Service.All();
        }

        [HttpPost]
        public Athlete Post([FromBody]Athlete model)
        {
            this.Service.Save(model);
            return model;
        }

        [HttpPut]
        public Athlete Put([FromBody]Athlete model)
        {
            this.Service.Update(model);
            return model;
        }

        [HttpDelete]
        public void Delete(long id)
        {
            this.Service.Delete(id);
        }
    }
}