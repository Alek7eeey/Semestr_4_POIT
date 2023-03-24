using ExCSS;
using Lab_4_5.AllCommands;
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
using System.Windows.Shapes;
using System.Xml.Linq;
using static Lab_4_5.Souvenirs;

namespace Lab_4_5
{
    /// <summary>
    /// Логика взаимодействия для InfoAboutProduct.xaml
    /// </summary>
    public partial class InfoAboutProduct : Window
    {
        private PullOfMethods newPull = new PullOfMethods();
        Command command;

        static Cursor C1 = new Cursor("D:\\studing\\4_semestr\\OOP_i_SP\\Lab's\\Lab_4_5\\Cursor\\Red Neon\\normal_select.cur");
        public int ID { get; set; }
        public string nameOfSouvenir { get; set; }
        public int price { get; set; }
        public BitmapImage Image { get; set; }
        public category Category { get; set; }
        public string CountryOfOrigin { get; set; }

        public int rate2;
        //wrapRate
        private void AddRating(int rate)
        { 
            for(int i = 0; i<rate; i++)
            {
                BitmapImage image;

                BitmapImage imagenew = new BitmapImage();
                imagenew.BeginInit();
                imagenew.UriSource = new Uri(@"D:\studing\4_semestr\OOP_i_SP\Lab's\Lab_4_5\Image\star.jpg"); // путь к файлу изображения
                imagenew.EndInit();
                image = imagenew;

                Image img = new Image();
                img.Source= image;
                img.Height = 15;
                img.Width = 15;
                wrapRate.Children.Add(img);
            }
        }
        public InfoAboutProduct(int id,string name_, int price, BitmapImage img, Souvenirs.category categor, string country, int rate)
        {
          InitializeComponent();

            command = new CommandMakeDefaultProducts(newPull);
            command.Execute();

            idForm.Text += ' ' + Convert.ToString(id);
            this.ID=id;

            name.Text += ' ' + name_;
            this.nameOfSouvenir = name_;

            costForm.Text += ' ' + Convert.ToString(price) + " BYN";
            this.price = price;

            ImageBlock.Source = img;
            this.Image= img;

            countryForm.Text += ' ' + country;
            this.CountryOfOrigin = country;

            categoryForm.Text += ' ' + categor.ToString();
            this.Category = categor;

            this.rate2 = rate;
            AddRating(rate);
            Cursor = C1;
        }
        public InfoAboutProduct()
        {
            InitializeComponent();
        }

        private void Correct_Button(object sender, RoutedEventArgs e)
        {
            Correct correc = new Correct(nameOfSouvenir, price, Image, Category, CountryOfOrigin, rate2);
            this.Close();
            correc.ShowDialog();
        }

        private void delete_click(object sender, RoutedEventArgs e)
        {
            command = new CommandDelete(newPull);
            command.Execute();
            this.Close();
        }

        private void CloseWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            PullOfMethods.actualID = 0;
        }
    }
}
