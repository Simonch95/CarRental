using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace CarRental
{
    /// <summary>
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }
        MySqlConnection connection = new MySqlConnection("server=localhost; user=root; database= Car Rental");
        MySqlCommand command;
        string inquirySQL = "";
        void ClearTextBox()
        {
            _loginTB.Text = "";
            _passwordTB.Text = "";
            _repeatPasswordTB.Text = "";
            _nameTB.Text = "";
            _sunameTB.Text = "";

        }
        void Register(string login, string password, string name, string surname)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                // kodowanie hasła
                //using (MD5 md5hash = MD5.Create())
                //{
                //    password = GetMd5Hash(md5hash, password);
                //}
                inquirySQL = string.Format("select count(Id) from klienci where login ='{0}'", login);
                command = new MySqlCommand(inquirySQL, connection);
                int value = Convert.ToInt32(command.ExecuteScalar());
                if (value == 1)
                {

                    MessageBox.Show(string.Format($"Konto  z takim loginem {login} już istnieje"), "Informacja", MessageBoxButton.OK);
                    // Login_tb.Select();
                }

                else
                {
                    // Pierwszy sposób podawania danych do serweru 

                    //  inquirySQL = string.Format("INSERT INTO uzytkownicy(Login,Password,Active, Registration)values" +
                    //      " ('"+login+"','"+password+"','"+Convert.ToInt32(active)+"','"+registerDate+"')");

                    // Drugi sposób podawania danych do serweru

                    inquirySQL = string.Format("INSERT INTO klienci(Login,Password,Name,Surname)" +
                      "values('{0}',MD5('{1}'), '{2}','{3}')", login, password, name, surname);

                    command.CommandText = inquirySQL;
                    command.ExecuteNonQuery();
                    MessageBox.Show("Użytkownik został dodany", "Informacja", MessageBoxButton.OK);
                    ClearTextBox();
                    this.Hide();

                }

            }
            catch (Exception ex)
            {

                string error = string.Format("Error downloading data \n{0}", ex.Message);
                MessageBox.Show(error, "Information", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                connection.Close();
            }
        }
        private void _regiterBTN_Click(object sender, RoutedEventArgs e)
        {
            Register(_loginTB.Text, _passwordTB.Text, _nameTB.Text, _sunameTB.Text);
        }

        private void _clearBTN_Click(object sender, RoutedEventArgs e)
        {
            ClearTextBox();
        }

        private void _exitBTN_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
