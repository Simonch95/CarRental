using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
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

namespace CarRental
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MySqlConnection connection = new MySqlConnection("server=localhost; user=root; database = Car Rental;");
        MySqlCommand command;
        string inquirySQL = "";
        public MainWindow()
        {
            InitializeComponent();
        }
        void Login()
        {
            inquirySQL = string.Format("select Name from klienci where Login ='{0}' ", _loginTb.Text);
            command.CommandText = inquirySQL;
            string name = command.ExecuteScalar().ToString();
            inquirySQL = string.Format("select Id from klienci where Login ='{0}' ", _loginTb.Text);
            command.CommandText = inquirySQL;
            int Id = Convert.ToInt32(command.ExecuteScalar());
            inquirySQL = string.Format("select Surname from klienci where Login ='{0}' ", _loginTb.Text);
            command.CommandText = inquirySQL;
            string surname = command.ExecuteScalar().ToString();
            Customer cust = new Customer(Id, _loginTb.Text, _passwordTb.Text, name, surname);
            PanelWindow mainPanel = new PanelWindow(cust);
            mainPanel.ShowDialog();

        }
        // Verify a hash against a string.
        bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
        void ClearTextBox()
        {
            _loginTb.Text = "";
            _passwordTb.Text = "";
        }

        private void _loginBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                inquirySQL = string.Format("select count(Id) from klienci where Login='{0}'",
                    _loginTb.Text);

                command = new MySqlCommand(inquirySQL, connection);
                int value = Convert.ToInt32(command.ExecuteScalar());

                if (value == 1)
                {
                    string password = "";
                    MD5 md5hash = MD5.Create();
                    password = GetMd5Hash(md5hash, _passwordTb.Text);

                    inquirySQL = string.Format("select Password from klienci where Login ='{0}' ", _loginTb.Text);
                    command.CommandText = inquirySQL;
                    string basePassword = command.ExecuteScalar().ToString();

                    if (VerifyMd5Hash(md5hash, _passwordTb.Text, basePassword))
                    {
                        Login();
                        ClearTextBox();
                         this.Close();
                    }
                    else
                        MessageBox.Show("Incorrect password");
                }
                else
                    MessageBox.Show("Incorrect login ", "Please check your data", MessageBoxButton.OK, MessageBoxImage.Error);



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

        private void _registerBtn_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registration = new RegistrationWindow();
            ClearTextBox();
            registration.Show();
        }

        private void _closeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

