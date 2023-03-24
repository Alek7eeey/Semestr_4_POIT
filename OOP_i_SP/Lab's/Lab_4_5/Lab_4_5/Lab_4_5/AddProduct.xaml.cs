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
using static Lab_4_5.Souvenirs;

namespace Lab_4_5
{
    /// <summary>
    /// Логика взаимодействия для AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        static Cursor C1 = new Cursor("D:\\studing\\4_semestr\\OOP_i_SP\\Lab's\\Lab_4_5\\Cursor\\Red Neon\\normal_select.cur");
        public AddProduct()
        {
            InitializeComponent();
            Cursor = C1;
        }
        public BitmapImage bitmap;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp";
            if (openFileDialog.ShowDialog() == true)
            {
                string imagePath = openFileDialog.FileName;
                bitmap = new BitmapImage(new Uri(imagePath));
                ImageBlock.Source = bitmap;
            }
        }

        private void CorrectButton_Click(object sender, RoutedEventArgs e)
        {
            category categor = category.NULL;
            if (CategoryBox.Text == "Кружки" || CategoryBox.Text == "Гурток" || CategoryBox.Text == "Circle") categor = category.Кружки;
            if (CategoryBox.Text == "Майки" || CategoryBox.Text == "Майка" || CategoryBox.Text == "T - shirt") categor = category.Майки;
            if (CategoryBox.Text == "Брелки" || CategoryBox.Text == "Бірулька" || CategoryBox.Text == "Pendant") categor = category.Брелки;
            if (CategoryBox.Text == "Другое" || CategoryBox.Text == "Іншы варыянт" || CategoryBox.Text == "Another option") categor = category.Другое;

            if (inputName.Text == "" || inputCost.Text == "" || bitmap == null || categor == category.NULL || inputCountry.Text == "" || inputRate.Text == "")
            {
                MessageBox.Show("Заполните все поля!", "Ошибка");
            }
            else
            {
                Souvenirs newSouvenir = new Souvenirs(++Souvenirs.COUNT, inputName.Text, Convert.ToInt32(inputCost.Text), bitmap, categor, inputCountry.Text, Convert.ToInt32(inputRate.Text));
                DataBase.AddToDataBase(newSouvenir);
                Memento.BeforeStepStack.Push(newSouvenir);
                PullOfMethods pull = new PullOfMethods();
                pull.AddDefaultProducts();
                this.Close();
            }
        }
    }
}
