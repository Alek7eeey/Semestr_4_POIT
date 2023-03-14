using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Lab_4_5
{
    public class DataBase
    {
        public static List<Souvenirs> souvenirsList { get; set;} = new List<Souvenirs>();
  

        public static void AddToDataBase(Souvenirs souv)
        {
            souvenirsList.Add(souv);

            using(StreamWriter sw = new StreamWriter("DataBase.txt", true))
            {
                sw.WriteLine(souv.ToString());
            }
        }

        public static void RemoveSouvenir(Souvenirs souv)
        {
            souvenirsList.Remove(souv);
        }

        public static void ChangeSouvenir(int id, Souvenirs newSouv)
        {
            foreach(var a in souvenirsList)
            {
                if(a.ID == id)
                {
                    a.price = newSouv.price;
                    a.nameOfSouvenir = newSouv.nameOfSouvenir;
                    a.CountryOfOrigin = newSouv.CountryOfOrigin;
                    a.Category = newSouv.Category;
                    a.Image = newSouv.Image;
                }
            }
        }

        public static void dafaultInf()
        {
            BitmapImage image1 = new BitmapImage();
            image1.BeginInit();
            image1.UriSource = new Uri(@"D:\studing\4_semestr\OOP_i_SP\Lab's\Lab_4_5\Image\Maika.png"); // путь к файлу изображения
            image1.EndInit();

            BitmapImage image2 = new BitmapImage();
            image2.BeginInit();
            image2.UriSource = new Uri(@"D:\studing\4_semestr\OOP_i_SP\Lab's\Lab_4_5\Image\Kruzhka.png"); // путь к файлу изображения
            image2.EndInit();

            BitmapImage image3 = new BitmapImage();
            image3.BeginInit();
            image3.UriSource = new Uri(@"D:\studing\4_semestr\OOP_i_SP\Lab's\Lab_4_5\Image\Kukla.png"); // путь к файлу изображения
            image3.EndInit();

            BitmapImage image4 = new BitmapImage();
            image4.BeginInit();
            image4.UriSource = new Uri(@"D:\studing\4_semestr\OOP_i_SP\Lab's\Lab_4_5\Image\Tarelka.png"); // путь к файлу изображения
            image4.EndInit();

            AddToDataBase(new Souvenirs(++Souvenirs.COUNT,"Майка", 85, image1, Souvenirs.category.Майки, "Беларусь",3));
            AddToDataBase(new Souvenirs(++Souvenirs.COUNT, "Кружка с надписью \"Беларусь\"", 24, image2, Souvenirs.category.Кружки, "Румыния",4));
            AddToDataBase(new Souvenirs(++Souvenirs.COUNT, "Белорусская кукла", 54, image3, Souvenirs.category.Другое, "Беларусь",5));
            AddToDataBase(new Souvenirs(++Souvenirs.COUNT, "Тарелка с зубром", 44, image4, Souvenirs.category.Другое, "Польша",2));
            

        }
    }
}
