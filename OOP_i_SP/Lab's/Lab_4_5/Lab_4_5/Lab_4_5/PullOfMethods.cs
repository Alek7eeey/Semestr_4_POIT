using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Data;
using Xceed.Wpf.Toolkit;
using static Lab_4_5.Souvenirs;
using System.Xml.Linq;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Lab_4_5
{
    public class PullOfMethods
    {
        #region BlockOfForm
        public static WrapPanel Products { get; set; }
        public static RangeSlider priceRangeSlider { get; set; }
        public static TextBlock minFilter { get; set; }
        public static TextBlock maxFilter { get; set; }
        public static TextBox searchInput { get; set; }
        public static TextBox InputCountry { get; set; }
        public static ComboBox SelectCategoryComboBox { get; set; }
        public static RadioButton BezFiltra_1 { get; set; }
        public static RadioButton BezFiltra_2 { get; set; }
        public static Frame frameWithInf { get; set; }
        public static int actualID {  get; set; }
        #endregion
        public void productWrap_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)//метод обработки нажатия на блок
        {
            WrapPanel productWrap = (WrapPanel)sender;
            TextBlock name = (TextBlock)((WrapPanel)productWrap.Children[1]).Children[0];

            foreach (var a in DataBase.souvenirsList)
            {
                if(a.nameOfSouvenir == name.Text)
                {
                    InfoAboutProduct info = new InfoAboutProduct(a.ID,a.nameOfSouvenir, a.price, a.Image, a.Category, a.CountryOfOrigin, a.rate);
                    actualID = a.ID;
                    info.ShowDialog();
                    break;
                }
            }
        }

        public void addProducts(Souvenirs souvenir)
        {
            // создаем WrapPanel для каждого товара
            WrapPanel productWrap = new WrapPanel();
            productWrap.Width = 180;
            productWrap.Orientation = Orientation.Vertical;
            productWrap.Margin = new Thickness(15, 0, 0, 15);
            productWrap.VerticalAlignment = VerticalAlignment.Top;

            // создаем WrapPanel для текстовых блоков
            WrapPanel textWrap = new WrapPanel();
            textWrap.Orientation = Orientation.Vertical;

            TextBlock name = new TextBlock();
            name.Text = souvenir.nameOfSouvenir;
            name.FontSize = 12;
            name.TextWrapping = TextWrapping.Wrap;

            TextBlock mark = new TextBlock();
            mark.Text = Convert.ToString(souvenir.price) + " BYN";
            mark.FontSize = 11;
            mark.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0xF6, 0x62, 0x3E));
            mark.TextWrapping = TextWrapping.Wrap;

            // добавляем текстовые блоки во внутренний WrapPanel
            textWrap.Children.Add(name);
            textWrap.Children.Add(mark);

            // задаем размеры картинки
            Image image = new Image();
            image.Source = souvenir.Image;
            //image.Margin= new Thickness(5);
            image.MaxWidth = 130;

            // Добавьте обработчик события нажатия
            productWrap.PreviewMouseLeftButtonDown += productWrap_PreviewMouseLeftButtonDown;
            productWrap.Cursor= MainWindow.C2;

            // добавляем внутренний WrapPanel и картинку в WrapPanel товара
            productWrap.Children.Add(image);
            productWrap.Children.Add(textWrap);

            // добавляем WrapPanel товара в общий WrapPanel
            Products.Children.Add(productWrap);
        }

        public void AddDefaultProducts()
        {
            Products.Children.Clear();

            if (DataBase.souvenirsList != null)
            {
                foreach (var a in DataBase.souvenirsList)
                {
                    addProducts(a);
                }
            }
        }

        public void CorrectSlider()
        {
            if (priceRangeSlider.LowerValue != 0)
            {
                minFilter.Text = Convert.ToString(Convert.ToInt32(priceRangeSlider.LowerValue));
            }

            if (priceRangeSlider.HigherValue != 0)
            {
                maxFilter.Text = Convert.ToString(Convert.ToInt32(priceRangeSlider.HigherValue));
            }
        }

        public void SearchForName()
        {
            // очищаем WrapPanel перед добавлением товаров, соответствующих поисковому запросу
            Products.Children.Clear();
            foreach (var a in DataBase.souvenirsList)
            {
                if (a.nameOfSouvenir.IndexOf(searchInput.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    addProducts(a);
                }
            }

            if (searchInput.Text == "")
            {
                AddDefaultProducts();
            }
        }

        public void SearchForCountry()
        {
            // очищаем WrapPanel перед добавлением товаров, соответствующих поисковому запросу
            Products.Children.Clear();
            foreach (var a in DataBase.souvenirsList)
            {
                if(a.CountryOfOrigin.IndexOf(InputCountry.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    addProducts(a);
                }
            }

            if (InputCountry.Text == "")
            {
                AddDefaultProducts();
            }
        }

        public void SearchForCost()
        {
            Products.Children.Clear();
            foreach (var a in DataBase.souvenirsList)
            {
                if(a.price >= Convert.ToInt32(minFilter.Text) && a.price <= Convert.ToInt32(maxFilter.Text))
                {
                    addProducts(a);
                }
            } 
            
            if(Convert.ToInt32(minFilter.Text) == 5 && Convert.ToInt32(maxFilter.Text) == 5)
            {
                AddDefaultProducts();
            }
        }

        public void SelectCategory()
        {
            string text = SelectCategoryComboBox.SelectedItem is ComboBoxItem selectedItem
            ? selectedItem.Content.ToString()
            : null;

            category categor = category.NULL;

            if (text == "Кружки" || text == "Гурток" || text == "Circle") categor = category.Кружки;
            if (text == "Майки" || text == "Майка" || text == "T - shirt") categor = category.Майки;
            if (text == "Брелки" || text== "Бірулька" || text == "Pendant") categor = category.Брелки;
            if (text == "Другое" || text == "Іншы варыянт" || text == "Another option") categor = category.Другое; 

            Products.Children.Clear();
            foreach (var a in DataBase.souvenirsList)
            {
                if(categor == a.Category)
                {
                    addProducts(a);
                }
            }

            if(categor == category.NULL)
            {
                AddDefaultProducts();
            }
        }

        public void SortByPrice(int a)
        {

            if (a == 1)
            {
                var newList = from i in DataBase.souvenirsList
                          orderby i.price
                          select i;

                Products.Children.Clear();

                if (newList != null)
                {
                    foreach (var c in newList)
                    {
                        addProducts(c);
                    }
                }

            }

            if( a == 0 )
            {
                var newList = from i in DataBase.souvenirsList
                              orderby i.price descending
                              select i;

                Products.Children.Clear();

                if (newList != null)
                {
                    foreach (var c in newList)
                    {
                        addProducts(c);
                    }
                }
            }

            if(a!= 0 && a!= 1)
            {
                AddDefaultProducts();
            }


        }

        public void SortByRating(int a)
        {
            if (a == 1)
            {
                var newList = from i in DataBase.souvenirsList
                              orderby i.rate
                              select i;

                Products.Children.Clear();

                if (newList != null)
                {
                    foreach (var c in newList)
                    {
                        addProducts(c);
                    }
                }

            }

            if (a == 0)
            {
                var newList = from i in DataBase.souvenirsList
                              orderby i.rate descending
                              select i;

                Products.Children.Clear();

                if (newList != null)
                {
                    foreach (var c in newList)
                    {
                        addProducts(c);
                    }
                }
            }

            if (a != 0 && a != 1)
            {
                AddDefaultProducts();
            }


        }

        public void DeleteProduct()
        {
            if (actualID != 0 && DataBase.souvenirsList.Count != 0)
            {
                var tempSouvenirsList = new List<Souvenirs>(DataBase.souvenirsList.Count);
                foreach (var a in DataBase.souvenirsList)
                {
                    if (a.ID != actualID)
                    {
                        tempSouvenirsList.Add(a);
                    }
                    else
                    {
                        Memento.BeforeStepStack.Push(a);
                    }
                }
                DataBase.souvenirsList = tempSouvenirsList;
            }
            AddDefaultProducts();
            actualID = 0;
        }
    }
}
