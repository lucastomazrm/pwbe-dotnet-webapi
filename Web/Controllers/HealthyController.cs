using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace PWBE.TeamAthlete.Web.Controllers
{
    public class HealthyController : Controller
    {
        [AllowAnonymous]
        public async Task<string> Index()
        {
            return "Ok";
        }
    }
}
