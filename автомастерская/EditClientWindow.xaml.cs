using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using автомастерская.Properties;

namespace автомастерская
{
    /// <summary>
    /// Логика взаимодействия для EditClientWindow.xaml
    /// </summary>
    public partial class EditClientWindow : Window
    {

        public Client curentclient = new Client();

        public EditClientWindow(Client selectedClientes)
        {
            InitializeComponent();

            if (selectedClientes != null)
            {
                curentclient = selectedClientes;
            }
            else {
                BitmapImage bit = new BitmapImage(new Uri("/Resources/Person1.png", UriKind.Relative));
                Avatar.Source = bit;

                DataContext = curentclient;
                var allmales = car_dealershipEntities1.GetContext().Male.ToList();

                ComboMale.ItemsSource = allmales;
            }
            
        }

        private void AcceptClientBtnClick(object sender, RoutedEventArgs e)
        {
            StringBuilder errrors = new StringBuilder();

            if ((string.IsNullOrWhiteSpace(curentclient.ClientName))){
                errrors.AppendLine("Укажите имя");
            }
            if ((string.IsNullOrWhiteSpace(curentclient.ClientSername)))
            {
                errrors.AppendLine("Укажите Фамилию");
            }
            if (curentclient.ClientMale == null)
            {
                errrors.AppendLine("Укажите пол");
            }
            if (curentclient.ClientDateOfBirthday == null)
            {
                errrors.AppendLine("Укажите дату рождения");
            }
            if ((curentclient.ClientMail.Contains("@mail") == false && curentclient.ClientMail.Contains("@gmail")) || (curentclient.ClientMail.Contains(".ru") == false && curentclient.ClientMail.Contains(".com") == false)) {
                errrors.AppendLine("Неверно указан адрес электронной почты");
            }

            if (errrors.Length > 0)
            {
                MessageBox.Show(errrors.ToString());
            }  
            if (curentclient.ClientId == 0){
                
                curentclient.ClientDateOfBirthday = ClientData.SelectedDate;
                car_dealershipEntities1.GetContext().Client.Add(curentclient);

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

        private void BtnEditImageClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Image Files (*.BMP;*.JPG;*.Gif;*.PNG)| *.BMP;*.JPG;*.Gif;*.PNG| All files (*.*)|*.*";

            if (ofd.ShowDialog() == true)
            {
                try {
                    BitmapImage bit = new BitmapImage(new Uri(ofd.FileName));
                    Avatar.Source = bit;
                }    
                catch {
                    MessageBox.Show("Не возможно открыть выбранный файл!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ComboBoxMaleSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBoxTelSelectionChanged(object sender, RoutedEventArgs e)
        {
            String NewTextContent = "";
            String TextBoxContent = TelBox.Text;
            var symbols = new Regex(@"[+()0-9\s]");

            string newTextContent = NewTextContent;
            foreach (char letter in TextBoxContent) {

                if (symbols.IsMatch(letter.ToString())) {
                    newTextContent += letter;
                }
            }

            TelBox.Text = newTextContent;
        }
    }
}
