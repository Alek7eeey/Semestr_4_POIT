using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_9.Classes
{
    public class AuthorRepository
    {
        public IEnumerable<InfoAboutPeople> GetAllPeoples()
        {
            var context = new CodeFirstContext();
            return context.Peoples.Include("Credits").ToList();
        }

        public async void AddPeople(InfoAboutPeople a)
        {
            var context = new CodeFirstContext();
            await Task.Run(() =>
            {
                Add(a);
            });
        }
        private void Add(InfoAboutPeople a)
        {
            var context = new CodeFirstContext();
            context.Database.EnsureCreated(); // Создаем базу данных, если ее нет
            context.Peoples.Add(a);
            context.SaveChanges();
        }
    }
}
