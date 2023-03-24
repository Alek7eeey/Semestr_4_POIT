using ExCSS;
using Lab_4_5.AllCommands;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using static System.Net.Mime.MediaTypeNames;
using Application = System.Windows.Application;
using Colors = System.Windows.Media.Colors;

namespace Lab_4_5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PullOfMethods newPull = new PullOfMethods();
        Command command;
        static Cursor C1 = new Cursor("D:\\studing\\4_semestr\\OOP_i_SP\\Lab's\\Lab_4_5\\Cursor\\Red Neon\\normal_select.cur");
        public static Cursor C2 = new Cursor("D:\\studing\\4_semestr\\OOP_i_SP\\Lab's\\Lab_4_5\\Cursor\\Red Neon\\link_select.cur");
        private static string theme = "white";
        private Memento memento;

        public MainWindow()
        {
            InitializeComponent();
            using (StreamWriter sw = new StreamWriter("DataBase.txt", false)) { }

            DataBase.dafaultInf();

            PullOfMethods.Products = Products;

            command = new CommandMakeDefaultProducts(newPull);
            command.Execute();
            removeAllFilters("");
            Cursor = C1;
            memento = new Memento();
        }

        public void removeAllFilters(string str)
        {
            if (str != "slider")
            {
                priceRangeSlider.LowerValue = 5;
                priceRangeSlider.HigherValue = 5;
            }

            if (str != "name")
            {
                searchInput.Text = "";
            }

            if (str != "country") 
            { 
                InputCountry.Text = "";
            }

            if (str != "category")
            {
                SelectCategoryComboBox.SelectedIndex = 4;
            }

            if (str != "bezFilter1")
            {
                BezFiltra_1.IsChecked = true;
            }

            if (str != "bezFilter2")
            {
                BezFiltra_2.IsChecked = true;
            }
        }

        private void SliderCorrect(object sender, RoutedEventArgs e)
        {
            PullOfMethods.priceRangeSlider = priceRangeSlider;
            PullOfMethods.maxFilter = maxFilter;
            PullOfMethods.minFilter = minFilter;
            command = new CommandNumberInSlider(newPull);
            command.Execute();

            //////////////////
            removeAllFilters("slider");
            command = new CommandSearchCost(newPull);
            command.Execute();
        }
           
        private void SearchForName(object sender, TextChangedEventArgs e)
        {
            removeAllFilters("name");
            PullOfMethods.searchInput = searchInput;
            command = new CommandSearchName(newPull);
            command.Execute();

            if(searchInput.Text.Contains("admin"))
            {
                searchInput.Foreground = new SolidColorBrush(Colors.Blue);
            }
            else
            {
                searchInput.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void TextChanged_CountryInput(object sender, TextChangedEventArgs e)
        {
            removeAllFilters("country");
            PullOfMethods.InputCountry = InputCountry;
            command = new CommandSearchCountry(newPull);
            command.Execute();
        }

        private void SelectCategory(object sender, SelectionChangedEventArgs e)
        {
            removeAllFilters("category");
            PullOfMethods.SelectCategoryComboBox = SelectCategoryComboBox;
            command = new CommandSelectCategory(newPull);
            command.Execute();
        }
        

        private void RadioButtonMarkGrow_Checked(object sender, RoutedEventArgs e)
        {
            removeAllFilters("bezFilter2");
            PullOfMethods.BezFiltra_1 = BezFiltra_1;
            command = new CommandSortByPrice(newPull, 1);
            command.Execute();
        }

        private void RadioButtonMarkWane_Checked(object sender, RoutedEventArgs e)
        {
            removeAllFilters("bezFilter2");
            command = new CommandSortByPrice(newPull, 0);
            command.Execute();
        }

        private void RadioButtonMarkNone_Checked(object sender, RoutedEventArgs e)
        {
            removeAllFilters("bezFilter2");
            command = new CommandSortByRate(newPull, -1);
            command.Execute();
        }

        private void RadioButtonRateGrow_Checked(object sender, RoutedEventArgs e)
        {
            removeAllFilters("bezFilter1");
            PullOfMethods.BezFiltra_2 = BezFiltra_2;
            command = new CommandSortByRate(newPull, 1);
            command.Execute();
        }

        private void RadioButtonRateWane_Checked(object sender, RoutedEventArgs e)
        {
            removeAllFilters("bezFilter1");
            command = new CommandSortByRate(newPull, 0);
            command.Execute();
        }

        private void RadioButtonRateNone_Checked(object sender, RoutedEventArgs e)
        {
            removeAllFilters("bezFilter1");
            command = new CommandSortByRate(newPull, -1);
            command.Execute();
        }

        private void AddProdutc_KeyDown(object sender, MouseButtonEventArgs e)
        {
            AddProduct newPr = new AddProduct();
            newPr.ShowDialog();
        }

        private void GoToMainPage(object sender, MouseButtonEventArgs e)
        {
            this.Focus();
        }

        private void ChangeLanguage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var uri = new Uri("Lab_4_5;component/Eng.xaml", UriKind.Relative);
            ResourceDictionary res = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(res);
            this.UpdateLayout(); // явное обновление макета формы
        }

        private void ChangeLanguage(object sender, MouseButtonEventArgs e)
        {
            var uri = new Uri("/Lab_4_5;component/By.xaml", UriKind.Relative);
            ResourceDictionary res = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(res);
            this.UpdateLayout(); // явное обновление макета формы
        }

        private void ChangeLanguageUkr(object sender, MouseButtonEventArgs e)
        {
            var uri = new Uri("/Lab_4_5;component/Ukr.xaml", UriKind.Relative);
            ResourceDictionary res = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(res);
            this.UpdateLayout(); // явное обновление макета формы
        }

        private void Click(object sender, MouseButtonEventArgs e)
        {
            if(theme == "white")
            {
                var uri = new Uri(@"BlackTheme.xaml", UriKind.Relative);
                ResourceDictionary res = Application.LoadComponent(uri) as ResourceDictionary;
                Application.Current.Resources.Clear();
                Application.Current.Resources.MergedDictionaries.Add(res);
                this.UpdateLayout(); // явное обновление макета формы
                theme = "black";
            }

            else
            {
                var uri = new Uri(@"WhiteTheme.xaml", UriKind.Relative);
                ResourceDictionary res = Application.LoadComponent(uri) as ResourceDictionary;
                Application.Current.Resources.Clear();
                Application.Current.Resources.MergedDictionaries.Add(res);
                this.UpdateLayout(); // явное обновление макета формы
                theme = "white";
            }
        }

        private void undoClick(object sender, RoutedEventArgs e)
        {
            memento.undo();
        }

        private void redoClick(object sender, RoutedEventArgs e)
        {
            memento.redo();
        }
    }
}

  
