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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab_7
{
    /// <summary>
    /// Логика взаимодействия для UserElement2.xaml
    /// </summary>
    public partial class UserElement2 : UserControl
    {
        public static readonly DependencyProperty SliderValueProperty =
            DependencyProperty.Register("SliderValue", typeof(int), typeof(UserElement2), 
                new FrameworkPropertyMetadata(0, 
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, 
                    new PropertyChangedCallback(OnSliderValueChanged), 
                    new CoerceValueCallback(CorrectValue)),
                    new ValidateValueCallback(ValidateSliderValue));

        public UserElement2()
        {
            InitializeComponent();
            DataContext = this;
        }

        public int SliderValue
        {
            get { 
                return (int)GetValue(SliderValueProperty); 
            }
            set { 
                SetValue(SliderValueProperty, value); 
            }
        }

        private static void OnSliderValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            
        }

        private static object CorrectValue(DependencyObject d, object baseValue)
        {
            int currentValue = (int)baseValue;
            if (currentValue > 100)  // если больше 100, возвращаем 100
                return 100;
            if (currentValue < 0)
                return 0;

            return currentValue; // иначе возвращаем текущее значение
        }

        private static bool ValidateSliderValue(object value)
        {
            int currentValue = (int)value;
            if (currentValue > 0 && currentValue < 100) // если текущее значение от нуля и выше
                return false;
            return true;
        }
    }

}
