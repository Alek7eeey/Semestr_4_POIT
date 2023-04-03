using Microsoft.Data.SqlClient;
using System;
using System.Collections;
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
    /// Логика взаимодействия для PageTbPlanes.xaml
    /// </summary>
    public partial class PageTbPlanes : Page
    {
        public DataTable table { get; set; }
        string query = "select p.ID, p.Type, p.Model, p.CountSeat,\r\np.YearOfIssue," +
               " p.CapacityLoad, p.DateOfTO\n\tfrom Planes p\r\norder by p.ID";
        public PageTbPlanes()
        {
            InitializeComponent();

            SqlConnection connection = null;

            using (connection = new(MainWindow.connectionString))
            {
                connection.Open();

                using (SqlDataAdapter adapter = new(query, connection))
                {
                    table = new DataTable();
                    adapter.Fill(table);

                    // Установить DataTable как источник данных для DataGrid
                    dataGrid.ItemsSource = table.DefaultView;
                }

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // получаем измененные данные из DataGrid
            DataTable changes = ((DataView)dataGrid.ItemsSource).Table.GetChanges();

            // проверяем, что были внесены изменения
            if (changes == null)
                return;

            using (SqlConnection connection = new SqlConnection(MainWindow.connectionString))
            {
                connection.Open();

                // создаем команду для выполнения UPDATE-запроса
                SqlCommand command = new SqlCommand(
                    "UPDATE Planes SET Type = @Type, Model = @Model, CountSeat = @CountSeat, " +
                    "YearOfIssue = @YearOfIssue, CapacityLoad = @CapacityLoad, DateOfTO = @DateOfTO " +
                    "WHERE ID = @ID", connection);

                // создаем параметры для передачи измененных данных
                command.Parameters.Add("@ID", SqlDbType.Int, 0, "ID");
                command.Parameters.Add("@Type", SqlDbType.NVarChar, 50, "Type");
                command.Parameters.Add("@Model", SqlDbType.NVarChar, 50, "Model");
                command.Parameters.Add("@CountSeat", SqlDbType.Int, 0, "CountSeat");
                command.Parameters.Add("@YearOfIssue", SqlDbType.Int, 0, "YearOfIssue");
                command.Parameters.Add("@CapacityLoad", SqlDbType.Int, 0, "CapacityLoad");
                command.Parameters.Add("@DateOfTO", SqlDbType.Date, 0, "DateOfTO");

                // передаем измененные данные в команду
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.UpdateCommand = command;
                adapter.Update(changes);

                // сохраняем изменения в БД
                adapter.Update(changes);

                // применяем изменения к DataGrid
                DataView dataView = (DataView)dataGrid.ItemsSource;
                DataTable dataTable = dataView.ToTable();
                dataGrid.ItemsSource = dataTable.DefaultView;
                MessageBox.Show("Информация сохранена!");
            }
        }
    }
}
