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
    /// Логика взаимодействия для client.xaml
    /// </summary>
    public partial class client : Page
    {
        public client()
        {
            InitializeComponent();
            DGridclient.ItemsSource = car_dealershipEntities1.GetContext().clientes.ToList();
        }

        private void AddClientClick(object sender, RoutedEventArgs e)
        {
            EditClientWindow taskWindow = new EditClientWindow(null);
            taskWindow.ResizeMode = ResizeMode.NoResize;

            if (taskWindow.ShowDialog() == true) {
                DGridclient.ItemsSource = car_dealershipEntities1.GetContext().clientes.ToList();
            }
        }

        private void DeleteClientClick(object sender, RoutedEventArgs e)
        {
            var ClientsForRemove = DGridclient.SelectedItems.Cast<clientes>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующих клиентов {ClientsForRemove.Count()}", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) 
            {
                try
                {
                    car_dealershipEntities1.GetContext().clientes.RemoveRange(ClientsForRemove);
                    car_dealershipEntities1.GetContext().SaveChanges();
                    DGridclient.ItemsSource = car_dealershipEntities1.GetContext().clientes.ToList();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            
            }
        }

        private void EditClientClick(object sender, RoutedEventArgs e)
        {
            var items = DGridclient.SelectedItem;

            if (items != null) {

                var selectedClients = (items as clientes);
                EditClientWindow taskWindow = new EditClientWindow(selectedClients);
                taskWindow.ResizeMode = ResizeMode.NoResize;

                if (taskWindow.ShowDialog() == true)
                {
                    DGridclient.ItemsSource = car_dealershipEntities1.GetContext().clientes.ToList();
                }

            }
        }
    }
}
