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
    /// Логика взаимодействия для service.xaml
    /// </summary>
    public partial class service : Page
    {

        public service()
        {
            InitializeComponent();
            DGridservice.ItemsSource = car_dealershipEntities1.GetContext().services.ToList();

    }

        private void add_service_Click(object sender, RoutedEventArgs e)
        {
            add_service taskWindow = new add_service();
            taskWindow.ResizeMode = ResizeMode.NoResize;
            taskWindow.ShowDialog();
        }
    }
}
