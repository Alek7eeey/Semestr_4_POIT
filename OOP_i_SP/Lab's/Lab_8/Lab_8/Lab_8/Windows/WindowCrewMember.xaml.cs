using Lab_8.Classes;
using Lab_8.Frames;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Lab_8.Windows
{
    /// <summary>
    /// Логика взаимодействия для WindowCrewMember.xaml
    /// </summary>
    public partial class WindowCrewMember : Window
    {
        CrewMembers crew;
        int thisId;
        
        public WindowCrewMember()
        {
            InitializeComponent();
            crew = new CrewMembers();
            thisId = Airport.Planes.Count+1;
        }

        private void ChangeName(object sender, TextChangedEventArgs e)
        {
            crew.name = InputName.Text; 
        }

        private void ChangedPosition(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = PositionInput.SelectedItem as ListBoxItem;

            crew.position = selectedItem.Content.ToString();
        }

        private void ChangeAge(object sender, TextChangedEventArgs e)
        {
            if (IsInputValid(InputAge.Text))
            {
                crew.age = Convert.ToInt32(InputAge.Text);
            }
            else InputAge.Text = string.Empty;
        }

        private bool IsInputValid(string input)
        {
            Regex regex = new Regex("^[0-9]+$");
            return regex.IsMatch(input);
        }

        private void ChangeExp(object sender, TextChangedEventArgs e)
        {
            if(IsInputValid(inputExp.Text))
            {
                crew.yearOfExp = Convert.ToInt32(inputExp.Text);
            }
            else inputExp.Text = string.Empty;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PageAdd.members.Add(crew);
            crew = new CrewMembers();
            InputName.Text = string.Empty;
            inputExp.Text = string.Empty;
            InputAge.Text = string.Empty;
        }
    }
}
