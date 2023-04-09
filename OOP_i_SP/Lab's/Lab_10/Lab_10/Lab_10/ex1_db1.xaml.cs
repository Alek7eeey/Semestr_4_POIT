using Lab_10.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab_10
{
    /// <summary>
    /// Логика взаимодействия для ex1_db1.xaml
    /// </summary>
    public partial class ex1_db1 : Page
    {
        private readonly myContext db;
        public ex1_db1()
        {
            InitializeComponent();
            var context = new myContext();
            context.Database.EnsureCreated(); // Создаем базу данных, если ее нет

            db = new myContext();
            db.peoples.Load();
            peopleGrid.ItemsSource = db.peoples.Local.ToBindingList(); // устанавливаем привязку к кэшу
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            db.SaveAll();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (peopleGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < peopleGrid.SelectedItems.Count; i++)
                {
                    People per = peopleGrid.SelectedItems[i] as People;
                    if (per != null)
                    {
                        db.RemoveEl<People>(per);
                    }
                }
            }
            db.SaveAll();
        }
    }
}
