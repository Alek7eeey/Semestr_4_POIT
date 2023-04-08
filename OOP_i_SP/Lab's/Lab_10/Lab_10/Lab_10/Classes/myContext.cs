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
    }

    public class Context
    {
        private myContext context = new myContext();
        private CreditRepository creditRepository;
        private PeopleRepository peopleRepository;

        public CreditRepository Credits
        {
            get
            {
                if(creditRepository == null) creditRepository = new CreditRepository();
                return creditRepository;
            }
        }

        public PeopleRepository Peoples
        {
            get
            {
                if (peopleRepository == null) peopleRepository = new PeopleRepository();
                return peopleRepository;
            }
        }

        public async void DisposeResource()
        {
            await Task.Run(() =>
            {
                Dispose();
            });
        }
        private void Dispose()
        {
            context.Dispose();
        }

        public async void SaveChanges()
        {
            await Task.Run(() =>
            {
                Save();
            });
        }

        private void Save()
        {
            context.SaveChanges();
        }
    }
}
