using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10.Classes
{
    public class CreditRepository
    {
        public IEnumerable<Credit> getAllCredits()
        {
            var context = new myContext();
            return context.credits.ToList();
        }

        public async void AddCredit(Credit a)
        {
            var context = new myContext();
            await Task.Run(() =>
            {
                Add(a);
            });
        }
        private void Add(Credit a)
        {
            var context = new myContext();
            context.Database.EnsureCreated(); // Создаем базу данных, если ее нет
            context.AddEl<Credit>(a);
            context.SaveAll();
        }

        public async void RemoveCredit(Credit a)
        {
            var context = new myContext();
            await Task.Run(() =>
            {
                Remove(a);
            });
        }
        private void Remove(Credit a)
        {
            var context = new myContext();
            context.Database.EnsureCreated();
            context.RemoveEl<Credit>(a);
            context.SaveAll();
        }

        private void update()
        {
            var context = new myContext();
            context.SaveAll();
        }

        public async void UpdateCredit()
        {
           await Task.Run(() => { 
            
                update();
            
            });
        }
    }
}
