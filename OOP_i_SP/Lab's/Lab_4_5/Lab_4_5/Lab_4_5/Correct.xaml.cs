using ExCSS;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Xml.Linq;
using static Lab_4_5.Souvenirs;
using static System.Net.Mime.MediaTypeNames;

namespace Lab_4_5
{
    /// <summary>
    /// Логика взаимодействия для Correct.xaml
    /// </summary>
    public partial class Correct : Window
    {
        string name2;
        BitmapImage im;
        static Cursor C1 = new Cursor("D:\\studing\\4_semestr\\OOP_i_SP\\Lab's\\Lab_4_5\\Cursor\\Red Neon\\normal_select.cur");
        public Correct(string name_, int price, BitmapImage img, Souvenirs.category categor, string country, int rate)
        {
            InitializeComponent();
            this.name2 = name_;
            im = img;

            inputName.Text = name_;
            inputCost.Text = Convert.ToString(price);
            ImageBlock.Source = img;
            inputCountry.Text = country;
            CategoryBox.Text = categor.ToString();
            inputRate.Text = Convert.ToString(rate);
            Cursor = C1;

        }
        public Correct()
        {
            InitializeComponent();
        }

        private void CorrectButton_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("DataBase.txt", false)) { }
                foreach (var a in DataBase.souvenirsList)
            {
                if(a.nameOfSouvenir == name2)
                {
                    a.price = Convert.ToInt32(inputCost.Text);
                    a.nameOfSouvenir = inputName.Text;
                    a.CountryOfOrigin = inputCountry.Text;
                    a.rate = Convert.ToInt32(inputRate.Text);
                    a.Image = im;

                    category categor = category.NULL;
                    if (CategoryBox.Text == "Кружки" || CategoryBox.Text == "Гурток" || CategoryBox.Text == "Circle") categor = category.Кружки;
                    if (CategoryBox.Text == "Майки" || CategoryBox.Text == "Майка" || CategoryBox.Text == "T - shirt") categor = category.Майки;
                    if (CategoryBox.Text == "Брелки" || CategoryBox.Text == "Бірулька" || CategoryBox.Text == "Pendant") categor = category.Брелки;
                    if (CategoryBox.Text == "Другое" || CategoryBox.Text == "Іншы варыянт" || CategoryBox.Text == "Another option") categor = category.Другое;
                    a.Category = categor;

                    PullOfMethods pull = new PullOfMethods();
                    pull.AddDefaultProducts();
                }
                using (StreamWriter sw = new StreamWriter("DataBase.txt", true)) 
                {
                    sw.WriteLine(a.ToString());
                }
            }

            this.Close();
        }
    }
}
