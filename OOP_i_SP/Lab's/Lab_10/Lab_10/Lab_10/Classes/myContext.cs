using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Xml;

namespace Lab_10.Classes
{
    public class myContext : DbContext
    {
        public DbSet<Credit> credits { get; set; }
        public DbSet<People> peoples { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["myContext"].ConnectionString;
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Credit>().HasKey(e => e.ID);
            modelBuilder.Entity<People>().HasKey(e => e.ID);
        }

        public void SaveAll()
        {
            SaveChanges();
        }

        public void AddEl <T>(T obj) where T : class
        {
            Set<T>().Add(obj);
            SaveAll();
        }

        public void RemoveEl<T>(T obj) where T: class
        {
            Set<T>().Remove(obj);
            SaveAll();

        }
    }


}
