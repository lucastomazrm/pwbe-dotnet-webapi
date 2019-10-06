using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace PWBE.TeamAthlete.Web.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View("index");
        }
    }
}
