using Microsoft.EntityFrameworkCore;
using PWBE.TeamAthlete.Models;

namespace PWBE.TeamAthlete.DataAccess
{
    public partial class MainContext : DbContext
    {
        public static void TeamMap(ModelBuilder modelBuilder)
        {
            var map = modelBuilder.Entity<Team>().ToTable("tblTeam");

            // Primary Key
            map.HasKey(t => t.Id);

            map.Property(t => t.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            map.Property(t => t.Name).HasColumnName("Name");
            map.HasMany(x => x.Athletes)
                .WithOne(x => x.Team)
                .HasForeignKey(x => x.TeamId);

        }

    }
}
