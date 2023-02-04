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
    /// Логика взаимодействия для staff.xaml
    /// </summary>
    public partial class staff : Page
    {
        public staff()
        {
            InitializeComponent();
            DGridstaff.ItemsSource = car_dealershipEntities1.GetContext().staffes.ToList();
        }

        private void AddStaffClick(object sender, RoutedEventArgs e)
        {

        }

        private void EditStaffClick(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteStaffClick(object sender, RoutedEventArgs e)
        {
            var StaffForRemove = DGridstaff.SelectedItems.Cast<staffes>().ToList();

            if (StaffForRemove != null) { 
                car_dealershipEntities1.GetContext().staffes.RemoveRange(StaffForRemove); 
                car_dealershipEntities1.GetContext().SaveChanges();
                DGridstaff.ItemsSource = car_dealershipEntities1.GetContext().staffes.ToList();
            }
        }
    }
}
