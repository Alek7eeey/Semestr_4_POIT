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
    /// Логика взаимодействия для UserElement1.xaml
    /// </summary>
    public partial class UserElement1 : UserControl
    {
        public static readonly DependencyProperty MyTextProperty =
            DependencyProperty.Register(
                "MyText",
                typeof(string),
                typeof(UserElement1),
                new FrameworkPropertyMetadata(
                "", // значение по умолчанию
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, // флаги свойства
                new PropertyChangedCallback(OnMyTextChanged), // метод, вызываемый при изменении свойства
                new CoerceValueCallback(CoerceMyText), // метод, вызываемый при принудительном изменении значения свойства
                true, // разрешить установку значения свойства в null
                System.Windows.Data.UpdateSourceTrigger.PropertyChanged // режим обновления привязки
                )
            );

        public string MyText
        {
            get { return (string)GetValue(MyTextProperty); }
            set { SetValue(MyTextProperty, value); }
        }

        public UserElement1()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private static void OnMyTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UserElement1 userControl = d as UserElement1;
            string? newText = e.NewValue as string;

            if (userControl != null && !string.IsNullOrEmpty(newText))
            {
                int wordLength = newText.Split(' ').Select(w => w.Length).Sum();
                userControl.CountText.Text = Convert.ToString(wordLength);
            }
            else userControl.CountText.Text = "0";
        }

        private static bool ValidateMyText(object value)
        {
            // Проверка, что значение соответствует требованиям
            string str = value as string;
            return str != null && str.Length > 0;
        }

        private static object CoerceMyText(DependencyObject d, object value)
        {
            // Коррекция значения MyText
            string str = value as string;
            if (str != null && str.Length > 10)
            {
                str = str.Substring(0, 10);
            }
            return str;
        }
    }

}
