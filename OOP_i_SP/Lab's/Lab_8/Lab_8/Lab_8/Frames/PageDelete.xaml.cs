using Lab_8.Classes;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для PageDelete.xaml
    /// </summary>
    public partial class PageDelete : Page
    {
        public PageDelete()
        {
            InitializeComponent();
        }

        private bool IsInputValid(string input)
        {
            Regex regex = new Regex("^[0-9]+$");
            return regex.IsMatch(input);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool prov = false;
            foreach(var a in Airport.Planes)
            {
                if(a.id == Convert.ToInt32(inputDelIdPlane.Text))
                {
                    prov = true;
                    SqlConnection connection = null;

                    using(connection = new(MainWindow.connectionString))
                    {
                        connection.Open();

                        using(SqlCommand command = new SqlCommand())
                        {
                            command.Connection = connection;
                            command.CommandText = $"delete from Planes \r\nwhere ID like {Convert.ToInt32(inputDelIdPlane.Text)}\n\n" +
                                $"delete from CrewMembers \r\nwhere ID like {Convert.ToInt32(inputDelIdPlane.Text)}\n\n" +
                                $"delete from ImagePlane \r\nwhere ID like {Convert.ToInt32(inputDelIdPlane.Text)}\n";
                            command.ExecuteNonQuery();
                        }

                    }
                }
            }

            if(!prov)
            {
                MessageBox.Show("Рейс с таким id отсутствует!");
                inputDelIdPlane.Text = "";
            }
            else
            {
                for(int i = Airport.Planes.Count - 1; i >= 0; i--)
                {
                    if (Airport.Planes[i].id == Convert.ToInt32(inputDelIdPlane.Text))
                    {
                        Airport.Planes.RemoveAt(i);
                    }
                }
                MessageBox.Show("Самолёт удалён!");
                inputDelIdPlane.Text = "";
            }
        }

        private void ChangeID(object sender, TextChangedEventArgs e)
        {
            if(!IsInputValid(inputDelIdPlane.Text))
            {
                inputDelIdPlane.Text = string.Empty;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            bool prov = false;
            foreach (var a in Airport.Planes)
            {

                foreach(var b in a.crewers)
                {
                    if (b.name.Contains(inputDelNameMember.Text))
                    {
                        prov = true;
                        SqlConnection connection = null;

                        using (connection = new(MainWindow.connectionString))
                        {
                            connection.Open();

                            using (SqlCommand command = new SqlCommand())
                            {
                                command.Connection = connection;
                                command.CommandText = $"delete from CrewMembers \r\nwhere FIO like '%{inputDelNameMember.Text}%'\n\n";
                                command.ExecuteNonQuery();
                            }

                        }
                    }
                }
               
            }

            if (!prov)
            {
                MessageBox.Show("Член экипажа с таким именем отсутствует!");
                inputDelNameMember.Text = "";
            }
            else
            {
                for (int i = Airport.Planes.Count - 1; i >= 0; i--)
                {
                    for (int j = Airport.Planes[i].crewers.Count - 1; j >= 0; j--)
                    {
                        if (Airport.Planes[i].crewers[j].name.Contains(inputDelNameMember.Text))
                        {
                            Airport.Planes[i].crewers.RemoveAt(j);
                        }
                    }
                }
                MessageBox.Show("Член экипажа удалён!");
                inputDelNameMember.Text = "";
            }
        }

        private void ChangeDelMember(object sender, TextChangedEventArgs e)
        {

        }
    }
}
