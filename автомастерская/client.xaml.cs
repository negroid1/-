using System;
using System.Collections;
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
            DGridclient.ItemsSource = car_dealershipEntities1.GetContext().Client.ToList();


        }

        private void AddClientClick(object sender, RoutedEventArgs e)
        {
            EditClientWindow taskWindow = new EditClientWindow(null);
            taskWindow.ResizeMode = ResizeMode.NoResize;

            if (taskWindow.ShowDialog() == true) {
                DGridclient.ItemsSource = car_dealershipEntities1.GetContext().Client.ToList();
            }
        }

        private void DeleteClientClick(object sender, RoutedEventArgs e)
        {
            var ClientsForRemove = DGridclient.SelectedItems.Cast<Client>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующих клиентов {ClientsForRemove.Count()}", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    car_dealershipEntities1.GetContext().Client.RemoveRange(ClientsForRemove);
                    car_dealershipEntities1.GetContext().SaveChanges();
                    DGridclient.ItemsSource = car_dealershipEntities1.GetContext().Client.ToList();

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

                var SelectedClients = (items as Client);
                EditClientWindow taskWindow = new EditClientWindow(SelectedClients);
                taskWindow.ResizeMode = ResizeMode.NoResize;

                if (taskWindow.ShowDialog() == true)
                {
                    DGridclient.ItemsSource = car_dealershipEntities1.GetContext().Client.ToList();
                }

            }
        }

        private void TextBoxClientTextChanged(object sender, TextChangedEventArgs e)
        {
            var curentclient = car_dealershipEntities1.GetContext().Client.ToList();

            if (TextBoxSearchClient.Text == "")
                DGridclient.ItemsSource = car_dealershipEntities1.GetContext().Client.ToList();
            else
            {
                DGridclient.ItemsSource = null;

                DGridclient.ItemsSource = curentclient.Where(p => p.FullName.ToLower().Contains(TextBoxSearchClient.Text.ToLower())).ToList();

            }
        }

        private void ManCheckCheked(object sender, RoutedEventArgs e)
        {
            WomanCheck.IsChecked = false;
            UpdateClients();


        }

        private void WomanCheckCheked(object sender, RoutedEventArgs e)
        {
            ManCheck.IsChecked = false;
            UpdateClients();
        }

        private void TelCheckCheked(object sender, RoutedEventArgs e)
        {
            UpdateClients();
        }

        private void MailCheckCheked(object sender, RoutedEventArgs e)
        {
            UpdateClients();
        }

        private void UpdateClients()
        {
            var curentclients = car_dealershipEntities1.GetContext().Client.ToList();

            if (ManCheck.IsChecked == true)
            {
                curentclients = curentclients.Where(p => p.ClientMale == 1).ToList();
            }
            if (WomanCheck.IsChecked == true)
            {
                curentclients = curentclients.Where(p => p.ClientMale == 2).ToList();
            }
            if (TelCheck.IsChecked == true)
            {
                curentclients = curentclients.Where(p => p.ClientTel != null).ToList();
            }
            if (MailCheck.IsChecked == true)
            {
                curentclients = curentclients.Where(p => p.ClientMail != null).ToList();
            }
            if (TextBoxSearchClient.Text == "")
                DGridclient.ItemsSource = curentclients;
            else
            {
                DGridclient.ItemsSource = null;

                DGridclient.ItemsSource = curentclients.Where(p => p.FullName.ToLower().Contains(TextBoxSearchClient.Text.ToLower())).ToList();

            }
        }
    }
}
