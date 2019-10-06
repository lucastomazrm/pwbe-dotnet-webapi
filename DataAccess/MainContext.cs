using System;
using Microsoft.EntityFrameworkCore;
using PWBE.TeamAthlete.Models;

namespace PWBE.TeamAthlete.DataAccess
{
    public partial class MainContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Athlete> Athletes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
            // string connectionString = "Server=db-pwbe.cqtjtpjk6ewi.us-east-2.rds.amazonaws.com;Database=pwbe;Uid=app_pwbe;Pwd=2019$Ibm;pooling = false; convert zero datetime=True";
            optionsBuilder.UseMySql(connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            TeamMap(modelBuilder);
            AthleteMap(modelBuilder);
        }
    }
}
