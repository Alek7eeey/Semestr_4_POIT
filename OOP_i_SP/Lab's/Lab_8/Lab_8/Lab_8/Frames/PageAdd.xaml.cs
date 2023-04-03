using Azure;
using Lab_8.Classes;
using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Numerics;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab_8.Frames
{
    /// <summary>
    /// Логика взаимодействия для PageAdd.xaml
    /// </summary>
    public partial class PageAdd : Page
    {
        Plane plane;
        public static List<CrewMembers> members = new List<CrewMembers>();
        public PageAdd()
        {
            InitializeComponent();
            plane = new Plane();
            plane.id = Airport.Planes.Count+1;
            TextWithInf.Text = plane.ToString(); 
        }

        private void ClickChooseImage(object sender, RoutedEventArgs e)
        {
            BitmapImage bitmap = new();
            var openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp";
            if (openFileDialog.ShowDialog() == true)
            {
                string imagePath = openFileDialog.FileName;
                bitmap = new BitmapImage(new Uri(imagePath));
            }
            imgField.Source = bitmap;
            plane.image = bitmap;
        }

        private void ClickAddCrewMember(object sender, RoutedEventArgs e)
        {
            Windows.WindowCrewMember wc = new();
            wc.Show();
        }

        private void ChangeType(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = typeInput.SelectedItem as ListBoxItem;
            plane.type = selectedItem.Content.ToString();

            TextWithInf.Text = plane.ToString();
        }

        private void ChangeModel(object sender, TextChangedEventArgs e)
        {
            plane.model = inputModel.Text;
            TextWithInf.Text = plane.ToString();
        }

        private void ChangeCountSeat(object sender, TextChangedEventArgs e)
        {
            if (IsInputValid(inputCountSeat.Text))
            {
                plane.countSeat = Convert.ToInt32(inputCountSeat.Text);
                TextWithInf.Text = plane.ToString();
            }
            else inputCountSeat.Text = "";
        }

        private bool IsInputValid(string input)
        {
            Regex regex = new Regex("^[0-9]+$");
            return regex.IsMatch(input);
        }

        private void ChangeYearOfIssue(object sender, TextChangedEventArgs e)
        {
           if (IsInputValid(inputYearOfIssue.Text))
            {
                plane.yearOfIssue = Convert.ToInt32(inputYearOfIssue.Text);
                TextWithInf.Text = plane.ToString();
            }
            else inputYearOfIssue.Text = "";
        }

        private void ChangeCapacity(object sender, TextChangedEventArgs e)
        {
            if (IsInputValid(InputCapacity.Text))
            {
                plane.capacityLoad = Convert.ToInt32(InputCapacity.Text);
                TextWithInf.Text = plane.ToString();
            }
            else InputCapacity.Text = "";
            
        }

        private void ChangeDate(object sender, SelectionChangedEventArgs e)
        {
            plane.dateOfTo = DateOnly.FromDateTime(Convert.ToDateTime(InputDate.Text));
            TextWithInf.Text = plane.ToString();
        }

        private void Refresh(object sender, MouseEventArgs e)
        {
            TextWithInf.Text = plane.ToString();

            foreach(var a in members)
            {
                TextWithInf.Text += a.ToString();
                TextWithInf.Text += '\n';
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            plane.addPersonal(members);
            Airport.Planes.Add(plane);

            foreach(var airport in Airport.Planes)
            {
                MessageBox.Show(airport.ToString());
            }
            addInfInDataBase();
            inputModel.Text = "";
            inputCountSeat.Text = string.Empty;
            inputYearOfIssue.Text = string.Empty;
            InputCapacity.Text = string.Empty;
            imgField.Source = null;

            plane = new Plane();
            plane.id = Airport.Planes.Count + 1;
        }

        public void addInfInDataBase()
        {
            string? str = Convert.ToString(plane.image);
           
            if(str.Contains("'"))
            {
                int index = str.IndexOf("'");
                StringBuilder sb = new StringBuilder(str);
                sb.Insert(index + 1, "'");
                str = sb.ToString();
            }


            string formattedDate = plane.dateOfTo.ToString("yyyy.MM.dd"); 
            // Uri uri = new Uri(str);
            //plane.image = new BitmapImage(uri);

            SqlConnection connection = null;
            

            using (connection = new SqlConnection(MainWindow.connectionString))
            {
                connection.Open();

                using(SqlCommand cmd = new())
                {
                    string myQuery = $"insert Planes(ID, Type, Model, CountSeat, YearOfIssue, CapacityLoad, DateOfTO)\r\n" +
                          $"values ({plane.id}, '{plane.type}', '{plane.model}', {plane.countSeat}, {plane.yearOfIssue}, {plane.capacityLoad}, '{formattedDate}');\r\n" +
                          $"insert ImagePlane(ID, Image)\r\n" +
                          $"values({plane.id},'{str}');\n\n" +
                          $"insert CrewMembers(ID, FIO, Position, Age, YearOfExp)\n\r";

                    if (members.Count != 0)
                    {
                        myQuery += $"values";
                        int i = 0;

                        foreach (var a in members)
                        {
                            i++;
                            if (i == members.Count)
                            {
                                myQuery += $"({plane.id}, '{a.name}', '{a.position}', {a.age}, {a.yearOfExp});\n\r";
                            }
                            else
                            {
                                myQuery += $"({plane.id}, '{a.name}', '{a.position}', {a.age}, {a.yearOfExp}),\n\r";
                            }
                        }
                    }

                    cmd.Connection = connection;
                    cmd.CommandText = myQuery;
                    cmd.ExecuteNonQuery();
                }
               
            }
        }
    }
}
