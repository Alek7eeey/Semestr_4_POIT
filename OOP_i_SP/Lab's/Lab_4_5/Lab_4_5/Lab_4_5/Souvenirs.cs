using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Lab_4_5
{
    public class Souvenirs
    {
        static public int COUNT = 0;
        public int ID { get; set; }
        public string nameOfSouvenir { get; set; }
        public int price { get; set; }
        public BitmapImage Image { get; set; }
        public category Category { get; set; }
        public string CountryOfOrigin { get; set; }
        public enum category {Кружки, Майки, Брелки, Другое, NULL}
        public int rate;
        public Souvenirs(int id, string nameOfSouvenir, int price, BitmapImage image, category category, string countryOfOrigin, int rate)
        {
            this.ID = id;
            this.nameOfSouvenir = nameOfSouvenir;
            this.price = price;
            Image = image;
            Category = category;
            CountryOfOrigin = countryOfOrigin;
            this.rate = rate;
        }

        public override string ToString()
        {
            return $"ID: {ID}, \nName: {nameOfSouvenir}, \nPrice: {price}, \nCategory: {Category}, \nCountry of origin: {CountryOfOrigin}, \nRate: {rate} \n---------------------------------";
        }
    }
}
