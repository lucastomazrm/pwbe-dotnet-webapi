using System.Collections.Generic;

namespace PWBE.TeamAthlete.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Athlete> Athletes { get; set; }
    }
}
