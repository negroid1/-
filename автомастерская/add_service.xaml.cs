using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        private services curentservice = new services();

        public add_service(services selecectedservice )
        {
            InitializeComponent();

            if (selecectedservice != null)
            {
                curentservice = selecectedservice;
            }
            DataContext = curentservice;
        }

        private void btn_out_Click(object sender, RoutedEventArgs e)
        {
           DialogResult = false;
        }

        private void btn_add_service_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(curentservice.named))
                errors.AppendLine("Укажите название услуги");
            if (curentservice.info == null)
                errors.AppendLine("Добавьте информацию об услуге");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
      
            if (errors.Length == 0)
            {
                car_dealershipEntities1.GetContext().services.Add(curentservice);
                try
                {
                    car_dealershipEntities1.GetContext().SaveChanges(); 
                    MessageBox.Show("Информация сохранена");
                    DialogResult = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
         }

    }
}
