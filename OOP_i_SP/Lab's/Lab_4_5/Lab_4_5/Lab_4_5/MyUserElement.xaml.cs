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

namespace Lab_4_5
{
    /// <summary>
    /// Логика взаимодействия для MyUserElement.xaml
    /// </summary>
    public partial class MyUserElement : UserControl
    {
        public static readonly DependencyProperty ural1Prop = DependencyProperty.Register("url1", typeof(ImageSource), typeof(MyUserElement));
        public static readonly DependencyProperty ural2Prop = DependencyProperty.Register("url2", typeof(ImageSource), typeof(MyUserElement));
        public static readonly DependencyProperty ural3Prop = DependencyProperty.Register("url3", typeof(ImageSource), typeof(MyUserElement));

        public MyUserElement()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public ImageSource url1
        {
            get
            {
                return (ImageSource)GetValue(ural1Prop);
            }

            set { 
                SetValue(ural1Prop, value);
            }
        }
        public ImageSource url2 {
            get
            {
                return (ImageSource)GetValue(ural2Prop);
            }

            set
            {
                SetValue(ural2Prop, value);
            }
        }
        public ImageSource url3 {
            get
            {
                return (ImageSource)GetValue(ural3Prop);
            }

            set
            {
                SetValue(ural2Prop, value);
            }
        }
    }
}
