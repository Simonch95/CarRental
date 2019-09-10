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
    /// Interaction logic for AdditionCarsWindow.xaml
    /// </summary>
    public partial class AdditionCarsWindow : Window
    {
        public AdditionCarsWindow()
        {
            InitializeComponent();
        }
        MySqlConnection connection = new MySqlConnection("server=localhost; user=root; database= Car Rental");
        MySqlCommand command;
        string inquirySQL = "";
        void ClearTextBox()
        {
            _brandNewCarTB.Text = "";
            _modelNewCarTB.Text="";
            _yearNewCarTB.Text="";
            _priceNewCarTB.Text = "";
            _mileageNewCarTB.Text = "";
            _equipmentTB.Text = "";
        }
        private void AddCar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                     inquirySQL = string.Format("INSERT INTO cars(Brand,Model,Year,Price,Mileage,Equipment)" +
                     "values('{0}','{1}', '{2}','{3}','{4}','{5}')", _brandNewCarTB.Text, _modelNewCarTB.Text,Convert.ToInt32(_yearNewCarTB.Text),
                     Convert.ToDouble(_priceNewCarTB.Text),Convert.ToInt32(_mileageNewCarTB.Text),_equipmentTB.Text);

                command = new MySqlCommand(inquirySQL, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Added a new car", "Informacja", MessageBoxButton.OK);
                ClearTextBox();
                this.Hide();

            }
            catch (Exception ex)
            {

                string error = string.Format("Error downloading data \n{0}", ex.Message);
                MessageBox.Show(error, "Information", MessageBoxButton.OK, MessageBoxImage.Error);
            }finally
            {
                connection.Close();
            }
           
        }

        private void _clearBTN_Click(object sender, RoutedEventArgs e)
        {
            ClearTextBox();
        }

        private void _exitBTN_Click(object sender, RoutedEventArgs e)
        {
            ClearTextBox();
            this.Close();
        }
    }
}
