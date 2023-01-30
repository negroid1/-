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
    /// Логика взаимодействия для EditClientWindow.xaml
    /// </summary>
    public partial class EditClientWindow : Window
    {

        public clientes curentclient = new clientes();

        public EditClientWindow(clientes selectedClientes)
        {
            InitializeComponent();

            if (selectedClientes != null )
            {
                curentclient= selectedClientes;
            }
            DataContext = curentclient;
        }

        private void AcceptClientBtnClick(object sender, RoutedEventArgs e)
        {
            StringBuilder errrors = new StringBuilder();

            if ((string.IsNullOrWhiteSpace(curentclient.named))){
                errrors.AppendLine("Укажите имя");
            }
            if ((string.IsNullOrWhiteSpace(curentclient.sername))){
                errrors.AppendLine("Укажите фамилию");
            }

            if (errrors.Length > 0)
            {
                MessageBox.Show(errrors.ToString());
            } else if (errrors.Length == 0){ 
            
                car_dealershipEntities1.GetContext().clientes.Add(curentclient);

                try {
                    car_dealershipEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Информация сохранена");
                    DialogResult = true;

                } 
                catch (Exception ex){ 
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void OutClientBtnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
