using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
    /// Логика взаимодействия для PageTbImagePlane.xaml
    /// </summary>
    public partial class PageTbImagePlane : Page
    {
        public DataTable table { get; set; }
        string query = "select *\r\n\tfrom ImagePlane i\r\norder by i.ID";
        public PageTbImagePlane()
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
            DataTable changes = ((DataView)dataGrid.ItemsSource).Table.GetChanges();
            
            using (SqlConnection connection = new SqlConnection(MainWindow.connectionString))
            {
                connection.Open();

                // создаем команду для выполнения UPDATE-запроса
                SqlCommand command = new SqlCommand("UPDATE ImagePlane SET Image = @Image WHERE ID = @ID", connection);

                // создаем параметры для передачи измененных данных
                command.Parameters.Add("@ID", SqlDbType.Int, 0, "ID");
                command.Parameters.Add("@Image", SqlDbType.NVarChar, 0, "Image");

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
