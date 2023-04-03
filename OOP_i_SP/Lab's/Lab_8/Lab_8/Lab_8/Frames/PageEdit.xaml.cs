using Lab_8.Classes;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Lab_8.Frames
{
    /// <summary>
    /// Логика взаимодействия для PageEdix.xaml
    /// </summary>
    public partial class PageEdit : Page
    {
        public DataTable table { get; set; }
        string query = "select p.ID, p.Type, p.Model, p.CountSeat,\r\np.YearOfIssue," +
               " p.CapacityLoad, p.DateOfTO,\r\nc.FIO, c.Position, c.Age, c.YearOfExp," +
               " i.Image\r\n\tfrom Planes p\r\n\tinner join CrewMembers c\r\n" +
               "\ton p.ID = c.ID \r\n\tinner join ImagePlane i\r\n\ton i.ID = c.ID\norder by p.ID";
        public PageEdit()
        {
            InitializeComponent();

            DataContext = this;
            mainFrame2.Navigate(new PageTbPlanes());
            
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            if (mainFrame2.Content is PageTbPlanes)
            {
                mainFrame2.Navigate(new PageTbImagePlane());
            }

            if (mainFrame2.Content is PageTbImagePlane)
            {
                mainFrame2.Navigate(new PageTbCrewMembers());
            }

            if (mainFrame2.Content is PageTbCrewMembers)
            {
                mainFrame2.Navigate(new PageTbPlanes());
            }
        }

        private void nextBtn_Click(object sender, RoutedEventArgs e)
        {
            if (mainFrame2.Content is PageTbPlanes)
            {
                mainFrame2.Navigate(new PageTbCrewMembers());
            }

            if (mainFrame2.Content is PageTbCrewMembers)
            {
                mainFrame2.Navigate(new PageTbImagePlane());
            }

            if (mainFrame2.Content is PageTbImagePlane)
            {
                mainFrame2.Navigate(new PageTbPlanes());
            }
        }
    }
}
