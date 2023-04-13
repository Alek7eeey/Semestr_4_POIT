using Lab_11.Model;
using Lab_11.View;
using Lab_11.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Lab_11
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        List<Consultation> consultations = new();
        private void OnStartup(object sender, StartupEventArgs e)
        {

            //List<Consultation> consultations = new()
            //{
            //    new Consultation("Пацей Н.В.", "ООП", "11:30", DateOnly.Parse("11.09.2023")),
            //    new Consultation("Барковский Е.В.", "КЯР", "19:00", DateOnly.Parse("01.05.2023")),
            //    new Consultation("Шиман Д.В.", "ПСП", "13:00", DateOnly.Parse("09.07.2023"))
            //};
            connectToDB();
            MainWindow window = new();
            MainViewModel viewModel = new(consultations);
            window.DataContext = viewModel;
            window.Show();
        }

        private void connectToDB()
        {
                string sql = "select * from consultation;";
                SqlConnection connection = null;
                // Создайте объект DataTable для хранения данных из базы данных.
                DataTable dataTable = new DataTable();
                string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            Consultation cons;

            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        string subject = reader.GetString(2);
                        string time = reader.GetString(3);
                        DateOnly date = DateOnly.FromDateTime(reader.GetDateTime(4));
                        cons = new(name, subject, time, date);
                        consultations.Add(cons);
                    }
                }

                reader.CloseAsync();
            }
        }
    }
}
