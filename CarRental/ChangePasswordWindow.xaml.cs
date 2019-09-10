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
using System.Windows.Shapes;

namespace CarRental
{
    /// <summary>
    /// Interaction logic for ChangePasswordWindow.xaml
    /// </summary>
    public partial class ChangePasswordWindow : Window
    {
        public ChangePasswordWindow()
        {
            InitializeComponent();
        }


        MySqlConnection connection = new MySqlConnection("server=localhost; user=root; database= Car Rental");
        MySqlCommand command;
        string inquirySQL = "";
        void ClearTextBox()
        {
            _loginTB.Text = "";
            _newPasswordTB.Text = "";
            _passwordTB.Text = "";
        }
        void UpdatePassword()
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                inquirySQL = string.Format("update klienci set Password=MD5('{0}') where Login='{1}'", _newPasswordTB.Text, _loginTB.Text);
                command = new MySqlCommand(inquirySQL, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Password was be changed");
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

        void CheckLogin()
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                inquirySQL = string.Format("select count(Login) from klienci where Login='{0}' ", _loginTB.Text);
                command = new MySqlCommand(inquirySQL, connection);
                int value = Convert.ToInt32(command.ExecuteNonQuery());
                if (value == 0)
                {
                    MessageBox.Show("Wrong login", "Check again", MessageBoxButton.OK, MessageBoxImage.Warning);

                }
                else
                {

                    string password = "";
                    MD5 md5hash = MD5.Create();

                    password = GetMd5Hash(md5hash, _passwordTB.Text);
                    inquirySQL = string.Format("select Password from klienci where Login ='{0}'", _loginTB.Text);

                    command.CommandText = inquirySQL;
                    string passwordFromBase = command.ExecuteScalar().ToString();
                    // command.ExecuteNonQuery();

                    if (VerifyMd5Hash(md5hash, _passwordTB.Text, passwordFromBase))
                    {
                        UpdatePassword();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect password", "Informacja", MessageBoxButton.OK);
                    }
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

        private void _okBTN_Click(object sender, RoutedEventArgs e)
        {
            CheckLogin();
            ClearTextBox();
            this.Close();
        }

        private void _clearBTN_Click(object sender, RoutedEventArgs e)
        {
            ClearTextBox();
        }

        private void _CancelBTN_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
