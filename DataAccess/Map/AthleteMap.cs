using Microsoft.EntityFrameworkCore;
using PWBE.TeamAthlete.Models;

namespace PWBE.TeamAthlete.DataAccess
{
    public partial class MainContext : DbContext
    {
        public static void AthleteMap(ModelBuilder modelBuilder)
        {
            var map = modelBuilder.Entity<Athlete>().ToTable("tblAthlete");

            // Primary Key
            map.HasKey(t => t.Id);

            map.Property(t => t.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            map.Property(t => t.Name).HasColumnName("Name");
            map.Property(t => t.Birthdate).HasColumnName("Birthdate");
            map.Property(t => t.Position).HasColumnName("Position");
            map.Property(t => t.Type).HasColumnName("Type");
            map.Property(t => t.TeamId).HasColumnName("TeamId");
        }

    }
}
