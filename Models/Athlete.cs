using System;

namespace PWBE.TeamAthlete.Models
{
    public class Athlete
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public string Type { get; set; } // Modalidade
        public string Position { get; set; }
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
    }
}
