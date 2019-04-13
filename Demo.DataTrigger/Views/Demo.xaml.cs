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

namespace Demo.DataTrigger.Views
{
    /// <summary>
    /// Interaction logic for Demo.xaml
    /// </summary>
    public partial class Demo : Page
    {
        public Demo()
        {
            InitializeComponent();
            DataContext = this;
        }

        public string ThumbnailPath 
        {
            get => (string)GetValue(MyPropertyProperty);
            set => SetValue(MyPropertyProperty, value);
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyPropertyProperty =
            DependencyProperty.Register(nameof(ThumbnailPath), typeof(string), typeof(Demo),
            new FrameworkPropertyMetadata(null));

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ThumbnailPath = @"E:\\Media\\Images\\Src\\s.png";
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            ThumbnailPath = null;
        }
    }
}
