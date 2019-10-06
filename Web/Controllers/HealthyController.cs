using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace PWBE.TeamAthlete.Web.Controllers
{
    public class HealthyController : Controller
    {
        [AllowAnonymous]
        public IEnumerable<string> Index()
        {
            string dirPath = Directory.GetCurrentDirectory();
            List<string> files = new List<string>();
            DirectoryInfo dirInfo = new DirectoryInfo(dirPath);
            foreach (FileInfo fInfo in dirInfo.GetFiles())
            {
                files.Add(fInfo.Name);
            }
            return files.ToArray();
        }
    }
}
