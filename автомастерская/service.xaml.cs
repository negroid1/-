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
            add_service taskWindow = new add_service(null);
            taskWindow.ResizeMode = ResizeMode.NoResize;

            if (taskWindow.ShowDialog() == true) {
                DGridservice.ItemsSource = car_dealershipEntities1.GetContext().services.ToList();
            }
        }
        private void EditServiceClick(object sender, RoutedEventArgs e)
        {
            var item = DGridservice.SelectedItem;

            if (item != null)
            {
                var selectedsevice = (item as services);
                add_service taskWindow = new add_service(selectedsevice);
                taskWindow.ResizeMode = ResizeMode.NoResize;
                if (taskWindow.ShowDialog() ?? true)
                {
                    DGridservice.ItemsSource = car_dealershipEntities1.GetContext().services.ToList();
                }
            }
        }

        private void DeleteServiceClick(object sender, RoutedEventArgs e)
        {
            var ServiceForRemove = DGridservice.SelectedItems.Cast<services>().ToList();

            if( MessageBox.Show($"Вы точно хотите удалить следующие {ServiceForRemove.Count()} элементов?" , "Внимание", 
                MessageBoxButton.YesNo,MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    car_dealershipEntities1.GetContext().services.RemoveRange(ServiceForRemove);
                    car_dealershipEntities1.GetContext().SaveChanges();
                    DGridservice.ItemsSource = car_dealershipEntities1.GetContext().services.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
