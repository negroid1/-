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

namespace автомастерская
{
    /// <summary>
    /// Логика взаимодействия для main.xaml
    /// </summary>
    public partial class main : Page
    {
        public main()
        {
            InitializeComponent();
            manager.official = official;
        }

        private void client_Click(object sender, RoutedEventArgs e)
        {
            manager.official.Navigate(new client());
        }

        private void staff_Click(object sender, RoutedEventArgs e)
        {
            manager.official.Navigate(new staff());
        }
        private void product_Click(object sender, RoutedEventArgs e)
        {
            manager.official.Navigate(new product());
        }
        private void service_Click(object sender, RoutedEventArgs e)
        {
            manager.official.Navigate(new service());
        }
    }
}
