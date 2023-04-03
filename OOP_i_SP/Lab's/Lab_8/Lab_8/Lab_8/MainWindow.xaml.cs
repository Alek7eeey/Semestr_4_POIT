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
using System.Configuration;
using Lab_8.Frames;

namespace Lab_8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // DataBase dataBase = new DataBase();
        public static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlDataAdapter adapter;
        DataTable phonesTable;
        public MainWindow()
        {
            InitializeComponent();
            

            string query = "select p.ID, p.Type, p.Model, p.CountSeat,\r\np.YearOfIssue," +
                 " p.CapacityLoad, p.DateOfTO,\r\nc.FIO, c.Position, c.Age, c.YearOfExp," +
                 " i.Image\r\n\tfrom Planes p\r\n\tinner join CrewMembers c\r\n" +
                 "\ton p.ID = c.ID \r\n\tinner join ImagePlane i\r\n\ton i.ID = c.ID\norder by p.ID";

            MediaPlayer mediaPlayer = new MediaPlayer();
            mediaPlayer.Open(new Uri(@"D:\studing\4_semestr\OOP_i_SP\Lab's\Lab_8\music.mp3"));
            mediaPlayer.Volume = 0.1;
            mediaPlayer.Play();

            mainFrame.Navigate(new PageStart());

            SqlConnection connection = null;
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    PageView.AddInfInClass(query, connection);
                }



                //string query = "select * from Planes";

                //using (SqlConnection connection = dataBase.SqlConnect())
                //{
                //    connection.Open();

                //    using (SqlCommand command = new SqlCommand(query, connection))
                //    {
                //        SqlDataReader thisReader = command.ExecuteReader();

                //        while (thisReader.Read())
                //        {
                //            field.Text += thisReader.GetInt32(0).ToString() + thisReader.GetString(1) + 
                //                thisReader.GetString(2) + thisReader.GetInt32(3) + thisReader.GetInt32(4) +
                //                thisReader.GetInt32(5) + thisReader.GetDateTime(6) + '\n';
                //        }

                //        thisReader.Close();
                //    }
                //}

            }
        }

        private void ClickMenuView(object sender, MouseButtonEventArgs e)
        {
            mainFrame.Navigate(new PageView());
        }

        private void ClickMenuAdd(object sender, MouseButtonEventArgs e)
        {
            mainFrame.Navigate(new PageAdd());
        }

        private void ClickMenuDelete(object sender, MouseButtonEventArgs e)
        {
            mainFrame.Navigate(new PageDelete());
        }

        private void ClickMenuEdit(object sender, MouseButtonEventArgs e)
        {
            mainFrame.Navigate(new PageEdit());
        }
    }
}
