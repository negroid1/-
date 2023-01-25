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
using System.Windows.Shapes;

namespace автомастерская
{
    /// <summary>
    /// Логика взаимодействия для add_service.xaml
    /// </summary>
    public partial class add_service : Window
    {
        private add_service _curentaddservice = new add_service();

        public add_service()
        {
            InitializeComponent();
            DataContext= _curentaddservice;
        }

        private void btn_out_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void btn_add_service_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_curentaddservice.Name))
                errors.AppendLine("Укажите название услуги");
            if (_curentaddservice.info == null)
                errors.AppendLine("Добавьте информацию об услуге");
        }
    }
}
