using Lab_9.Classes;
using Lab_9.Pages;
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

namespace Lab_9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            mainFrame.Navigate(new PageEx1());
            btn1.BorderBrush = new SolidColorBrush(Color.FromRgb(0xDC, 0x14, 0x3c));
            btn1.BorderThickness = new Thickness(2);

            //var person = new InfoAboutPeople { Name = "BBAleksey", adress = "ул.Шаранговича", credits = new List<Credit>() };
            //person.credits.Add(new Credit { sumOfCredit = 550, date = DateTime.Now });
            //var rep = new AuthorRepository();
            //rep.AddPeople(person);
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            btn1.BorderBrush = new SolidColorBrush(Color.FromRgb(0xDC, 0x14,0x3c));
            btn1.BorderThickness = new Thickness(2);

            btn2.BorderBrush = null;
            btn2.BorderThickness = new Thickness(0);
            mainFrame.Navigate(new PageEx1());
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            btn2.BorderBrush = new SolidColorBrush(Color.FromRgb(0xDC, 0x14, 0x3c));
            btn2.BorderThickness = new Thickness(2);

            btn1.BorderBrush = null;
            btn1.BorderThickness = new Thickness(0);
            mainFrame.Navigate(new PageEx2());
        }
    }
}
