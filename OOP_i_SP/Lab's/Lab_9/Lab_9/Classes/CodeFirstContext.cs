using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Xml;

namespace Lab_9.Classes
{
    public class CodeFirstContext : DbContext
    {
        public DbSet<Credit> Credits { get; set; }
        public DbSet<InfoAboutPeople> Peoples { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["CodeFirstContext"].ConnectionString;
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Credit>().HasKey(e => e.ID);
            modelBuilder.Entity<InfoAboutPeople>().HasKey(e => e.ID);
        }
    }
}
