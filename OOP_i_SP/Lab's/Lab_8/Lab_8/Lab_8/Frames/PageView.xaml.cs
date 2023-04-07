using Lab_8.Classes;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Lab_8.Frames
{
    /// <summary>
    /// Логика взаимодействия для PageView.xaml
    /// </summary>
    public partial class PageView : Page
    {
        public PageView()
        {
            InitializeComponent();

            string query = "select p.ID, p.Type, p.Model, p.CountSeat,\r\np.YearOfIssue," +
                " p.CapacityLoad, p.DateOfTO,\r\nc.FIO, c.Position, c.Age, c.YearOfExp," +
                " i.Image\r\n\tfrom Planes p\r\n\tinner join CrewMembers c\r\n" +
                "\ton p.ID = c.ID \r\n\tinner join ImagePlane i\r\n\ton i.ID = c.ID\norder by p.ID";
            SqlConnection connection = null;

            // Создайте объект DataTable для хранения данных из базы данных.
            DataTable dataTable = new DataTable();

            using (connection = new SqlConnection(MainWindow.connectionString))
            {
                connection.Open();

                using (SqlDataAdapter adapter = new(query, connection))
                {
                    adapter.Fill(dataTable);
                    AddInfInClass(query, connection);
                }
            }
           
           GetFillTable(ref dataTable);
        }

        public void GetFillTable(ref DataTable dataTable)
        {
            // Получить индекс столбца ID в таблице данных.
            int idColumnIndex = dataTable.Columns["ID"].Ordinal;

            // Получить индекс столбца Type в таблице данных.
            int typeColumnIndex = dataTable.Columns["Type"].Ordinal;

            // Получить индекс столбца Model в таблице данных.
            int modelColumnIndex = dataTable.Columns["Model"].Ordinal;

            // Получить индекс столбца CountSeat в таблице данных.
            int countSeatColumnIndex = dataTable.Columns["CountSeat"].Ordinal;

            // Получить индекс столбца YearOfIssue в таблице данных.
            int yearOfIssueColumnIndex = dataTable.Columns["YearOfIssue"].Ordinal;

            // Получить индекс столбца CapacityLoad в таблице данных.
            int capacityLoadColumnIndex = dataTable.Columns["CapacityLoad"].Ordinal;

            // Получить индекс столбца DateOfTO в таблице данных.
            int dateOfTOColumnIndex = dataTable.Columns["DateOfTO"].Ordinal;

            // Получить индекс столбца FIO в таблице данных.
            int fioColumnIndex = dataTable.Columns["FIO"].Ordinal;

            // Получить индекс столбца Position в таблице данных.
            int positionColumnIndex = dataTable.Columns["Position"].Ordinal;

            // Получить индекс столбца Age в таблице данных.
            int ageColumnIndex = dataTable.Columns["Age"].Ordinal;

            // Получить индекс столбца YearOfExp в таблице данных.
            int yearOfExpColumnIndex = dataTable.Columns["YearOfExp"].Ordinal;

            // Получить индекс столбца Image в таблице данных.
            int imageColumnIndex = dataTable.Columns["Image"].Ordinal;

            // Считать данные из каждой строки таблицы данных и заполнить соответствующий столбец в DataGrid.
            foreach (DataRow row in dataTable.Rows)
            {
                string? id = row?.ItemArray[idColumnIndex]?.ToString();
                string? type = row?.ItemArray[typeColumnIndex]?.ToString();
                string? model = row?.ItemArray[modelColumnIndex]?.ToString();
                string? countSeat = row?.ItemArray[countSeatColumnIndex]?.ToString();
                string? yearOfIssue = row?.ItemArray[yearOfIssueColumnIndex]?.ToString();
                string? capacityLoad = row?.ItemArray[capacityLoadColumnIndex]?.ToString();
                string? dateOfTO = row?.ItemArray[dateOfTOColumnIndex]?.ToString();
                string? fio = row?.ItemArray[fioColumnIndex]?.ToString();
                string? position = row?.ItemArray[positionColumnIndex]?.ToString();
                string? age = row?.ItemArray[ageColumnIndex]?.ToString();
                string? yearOfExp = row?.ItemArray[yearOfExpColumnIndex]?.ToString();
                string? image = row?.ItemArray[imageColumnIndex]?.ToString();
                // Добавить новую строку в DataGrid.
                planeGrid.Items.Add(new { ID = id, Type = type, Model = model, CountSeat = countSeat, YearOfIssue = yearOfIssue, CapacityLoad = capacityLoad, DateOfTO = dateOfTO, FIO = fio, Position = position, Age = age, YearOfExp = yearOfExp, Image = image});
            }
        }
        public static void AddInfInClass(string query, SqlConnection connection)
        {
            Plane plane;
            bool prov = false;
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(reader.GetOrdinal("ID"));
                        foreach(var a in Airport.Planes)
                        {
                            if(a.id == id)
                            {
                                prov = true;
                            }
                        }

                        if (!prov)
                        {
                            string type = reader.GetString(reader.GetOrdinal("Type"));
                            string model = reader.GetString(reader.GetOrdinal("Model"));
                            int countSeat = reader.GetInt32(reader.GetOrdinal("CountSeat"));
                            int yearOfIssue = reader.GetInt32(reader.GetOrdinal("YearOfIssue"));
                            int capacityLoad = reader.GetInt32(reader.GetOrdinal("CapacityLoad"));
                            DateOnly dateOfTO = DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("DateOfTO")));
                            string URLImage = reader.GetString(reader.GetOrdinal("Image"));
                            Uri uri = new Uri(URLImage);
                            BitmapImage image = new BitmapImage(uri);
                            plane = new Plane(id, type, model, countSeat, yearOfIssue, capacityLoad, dateOfTO, image);
                            Airport.Planes.Add(plane);
                        }

                        prov = false;
                        string name = reader.GetString(reader.GetOrdinal("FIO"));
                        string position = reader.GetString(reader.GetOrdinal("Position"));
                        int age = reader.GetInt32(reader.GetOrdinal("Age"));
                        int yearOfExp = reader.GetInt32(reader.GetOrdinal("YearOfExp"));
                        CrewMembers crew = new CrewMembers(name,position,age,yearOfExp);
                        foreach(var a in Airport.Planes)
                        {
                            if(a.id == id)
                            {
                                a.addPersonal(crew); break;
                            }
                        }
                    }
                }
            }
        }

    }
}
