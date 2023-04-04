using Lab_9.Classes;
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

namespace Lab_9.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageEx2.xaml
    /// </summary>
    public partial class PageEx2 : Page
    {
        public PageEx2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Field1.Text = string.Empty;

            if (ot.Text.Length > 0 || doo.Text.Length > 0) 
            {
                
                using (CodeFirstContext db = new())
                {
                    var results = from p in db.Credits
                                  where p.sumOfCredit > Convert.ToInt32(ot.Text) && p.sumOfCredit < Convert.ToInt32(doo.Text)
                                  select p;

                    foreach (var a in results)
                    {
                        Field1.Text += a.ToString();
                        Field1.Text += '\n';
                    }
                }

                ot.Text = string.Empty;
                doo.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Одно из полей пустое!");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Field2.Text = string.Empty;
            if (clientId.Text.Length > 0)
            {
                using (CodeFirstContext db = new())
                {
                    int results = (from p in db.Credits where p.personID == Convert.ToInt32(clientId.Text) select p).Count();

                    Field2.Text += "Количество кредитов: " + Convert.ToString(results);
                }
                clientId.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Вы ничего не ввели!");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            using (CodeFirstContext db = new())
            {
                int sumCredit = (from p in db.Credits select p.sumOfCredit).Sum();
                Field3.Text = "Сумма кредитов: " + Convert.ToString(sumCredit);
            }
            
        }
    }
}
