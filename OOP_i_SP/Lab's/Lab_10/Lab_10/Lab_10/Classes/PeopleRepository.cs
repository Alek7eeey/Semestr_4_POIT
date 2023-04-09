using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10.Classes
{
    public class PeopleRepository
    {
        public IEnumerable<People> GetAllPeoples()
        {
            var context = new myContext();
            return context.peoples.ToList();
        }

        public async void AddPeople(People a)
        {
            var context = new myContext();
            await Task.Run(() =>
            {
                Add(a);
            });
        }
        private void Add(People a)
        {
            var context = new myContext();
            context.Database.EnsureCreated(); // Создаем базу данных, если ее нет
            context.AddEl<People>(a);
            context.SaveAll();
        }

        public async void RemovePeople(People a)
        {
            var context = new myContext();
            await Task.Run(() =>
            {
                Remove(a);
            });
        }
        private void Remove(People a)
        {
            var context = new myContext();
            context.Database.EnsureCreated();
            context.RemoveEl(a);
            context.SaveAll();

        }

        private void update()
        {
            var context = new myContext();
            context.SaveAll();
        }

        public async void UpdatePerson()
        {
            await Task.Run(() => {

                update();

            });
        }
    }
}
