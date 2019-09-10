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
    /// Interaction logic for PanelWindow.xaml
    /// </summary>
    public partial class PanelWindow : Window
    {
        #region Zmienne
        MySqlConnection connection = new MySqlConnection("server=localhost; user=root; database = Car Rental;");
        MySqlCommand command;
        MySqlDataReader reader;
        string inquirySQL = "";
        Car selectedCar = null;
        List<Car> listCars = new List<Car>();
        List<Car> rentalList = new List<Car>();
        List<string> brandCar = new List<string>();
        List<string> modelCar = new List<string>();
        Customer customer;
        #endregion
        public PanelWindow(Customer cust)
        {
            InitializeComponent();
            this.customer = cust;
            _userLBL.Content += customer._login + "!";

        }
        #region Metody
        void ClearList()
        {
            _listCarsLB.Items.Clear();
            _listCarsLB.SelectedIndex = -1;
            _equipmentTB.Text = "";
        }
        void ClearTextBox()
        {
            _equipmentTB.Text = "";
            _IdCarTB.Text = "";
            _IdCustomerTB.Text = "";
            _brandCarTB.Text = "";
            _modelCarTB.Text = "";
            _mileageTB.Text = "";
            _yearCarTB.Text = "";
            _priceCarTB.Text = "";
            selectedCar = null;
        }
        void InitializeListCar()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            try
            {
                inquirySQL = string.Format("select * from cars");
                command = new MySqlCommand(inquirySQL, connection);
                reader = command.ExecuteReader();

                ClearList();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        _listCarsLB.Items.Add(string.Format("{0}. {1} - {2}", Convert.ToString(reader["Id"]), reader["Brand"].ToString(), reader["Model"].ToString()));

                        listCars.Add(new Car(reader.GetInt32("Id"), reader["Brand"].ToString(), reader["Model"].ToString(),
                        reader.GetInt32("Year"), reader.GetDouble("Price"), reader.GetInt32("Mileage"), reader["Equipment"].ToString()));

                        if (!brandCar.Contains(reader["Brand"].ToString()))
                            brandCar.Add(reader["Brand"].ToString());
                        if (!modelCar.Contains(reader["Model"].ToString()))
                            modelCar.Add(reader["Model"].ToString());
                        _brandCarCB.ItemsSource = brandCar;
                        _modelCarCB.ItemsSource = modelCar;


                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {

                string error = string.Format("Błąd podczas pobierania danych \n {0}", ex.Message);
                MessageBox.Show(error, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                connection.Close();
            }

        }
        void SearchCar(string flag)
        {
            ClearList();


            switch (flag)
            {
                case "b":
                    {
                        foreach (Car car in listCars)
                        {
                            if (car._brand.Equals(_brandCarCB.SelectedValue.ToString()))
                                _listCarsLB.Items.Add(string.Format("{0} - {1}", car._brand, car._model));
                        }
                        break;
                    }
                case "m":
                    {
                        foreach (Car car in listCars)
                        {
                            if (car._model.Equals(_modelCarCB.SelectedValue.ToString()))
                                _listCarsLB.Items.Add(string.Format("{0} - {1}", car._brand, car._model));
                        }
                        break;
                    }
                case "p":
                    {
                        double dprice = Convert.ToDouble(_priceTB.Text);
                        foreach (Car car in listCars)
                        {
                            if (car._price >= dprice)
                            {
                                _listCarsLB.Items.Add(string.Format("{0} - {1}", car._brand, car._model));
                            }
                        }
                        break;
                    }
                case "y":
                    {
                        int tempYear = Convert.ToInt32(_yearTB.Text);
                        foreach (Car car in listCars)
                        {
                            if (car._year >= tempYear)
                            {
                                _listCarsLB.Items.Add(string.Format("{0} - {1}", car._brand, car._model));
                            }
                        }
                        break;
                    }
                case "bm":
                    {
                        foreach (Car car in listCars)
                        {
                            if (car._brand.Equals(_brandCarCB.SelectedValue.ToString()) && car._model.Equals(_modelCarCB.SelectedValue.ToString()))
                                _listCarsLB.Items.Add(string.Format("{0} - {1}", car._brand, car._model));
                        }
                        break;
                    }
                case "bp":
                    {
                        double dprice = Convert.ToDouble(_priceTB.Text);
                        foreach (Car car in listCars)
                        {
                            if (car._brand.Equals(_brandCarCB.SelectedValue.ToString()) && (car._price >= dprice))
                                _listCarsLB.Items.Add(string.Format("{0} - {1}", car._brand, car._model));
                        }
                        break;
                    }
                case "by":
                    {
                        int tempYear = Convert.ToInt32(_yearTB.Text);
                        foreach (Car car in listCars)
                        {
                            if (car._brand.Equals(_brandCarCB.SelectedValue.ToString()) && (car._year >= tempYear))
                            {
                                _listCarsLB.Items.Add(string.Format("{0} - {1}", car._brand, car._model));
                            }
                        }
                        break;
                    }
                case "my":
                    {
                        int tempYear = Convert.ToInt32(_yearTB.Text);
                        foreach (Car car in listCars)
                        {
                            if (car._model.Equals(_modelCarCB.SelectedValue.ToString()) && car._year >= tempYear)
                            {
                                _listCarsLB.Items.Add(string.Format("{0} - {1}", car._brand, car._model));
                            }
                        }
                        break;
                    }
                case "mp":
                    {
                        double dprice = Convert.ToDouble(_priceTB.Text);
                        foreach (Car car in listCars)
                        {
                            if (car._model.Equals(_modelCarCB.SelectedValue.ToString()) && (car._price >= dprice))
                                _listCarsLB.Items.Add(string.Format("{0} - {1}", car._brand, car._model));
                        }
                        break;
                    }
                case "py":
                    {
                        double dprice = Convert.ToDouble(_priceTB.Text);
                        int tempYear = Convert.ToInt32(_yearTB.Text);
                        foreach (Car car in listCars)
                        {
                            if ((car._price >= dprice) && (car._year >= tempYear))
                                _listCarsLB.Items.Add(string.Format("{0} - {1}", car._brand, car._model));
                        }
                        break;
                    }
                case "bmp":
                    {
                        double dprice = Convert.ToDouble(_priceTB.Text);
                        foreach (Car car in listCars)
                        {
                            if (car._brand.Equals(_brandCarCB.SelectedValue.ToString()) && car._model.Equals(_modelCarCB.SelectedValue.ToString())
                                && (car._price >= dprice))
                            {
                                _listCarsLB.Items.Add(string.Format("{0} - {1}", car._brand, car._model));
                            }
                        }
                        break;
                    }
                case "bmy":
                    {
                        int tempYear = Convert.ToInt32(_yearTB.Text);
                        foreach (Car car in listCars)
                        {
                            if (car._brand.Equals(_brandCarCB.SelectedValue.ToString()) && car._model.Equals(_modelCarCB.SelectedValue.ToString()) &&
                                (car._year >= tempYear))
                                _listCarsLB.Items.Add(string.Format("{0} - {1}", car._brand, car._model));
                        }
                        break;
                    }
                case "bpy":
                    {
                        double dprice = Convert.ToDouble(_priceTB.Text);
                        int tempYear = Convert.ToInt32(_yearTB.Text);
                        foreach (Car car in listCars)
                        {
                            if (car._brand.Equals(_brandCarCB.SelectedValue.ToString()) && (car._price >= dprice) && (car._year >= tempYear))
                                _listCarsLB.Items.Add(string.Format("{0} - {1}", car._brand, car._model));
                        }
                        break;
                    }

                case "bmpy":
                    {
                        double dprice = Convert.ToDouble(_priceTB.Text);
                        int tempYear = Convert.ToInt32(_yearTB.Text);
                        foreach (Car car in listCars)
                        {
                            if (car._brand.Equals(_brandCarCB.SelectedValue.ToString()) && car._model.Equals(_modelCarCB.SelectedValue.ToString())
                                && car._year >= tempYear && (car._price >= dprice))
                            {
                                _listCarsLB.Items.Add(string.Format("{0} - {1}", car._brand, car._model));
                            }
                        }
                        break;
                    }


                default:
                    break;
            }

        }
        #endregion
        #region Kontrolki
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                if (_listCarsLB.SelectedIndex == -1)
                    ClearTextBox();

                else
                {
                    string[] tab = _listCarsLB.SelectedItem.ToString().Split('.');

                    Car car = listCars.FirstOrDefault(x => Convert.ToString(x._Id).Equals(tab[0].Trim()));

                    selectedCar = car;
                    if (selectedCar != null)
                    {
                        _brandCarTB.Text = car._brand;
                        _modelCarTB.Text = car._model;
                        _IdCarTB.Text = car._Id.ToString();
                        _mileageTB.Text = car._mileage.ToString();                        
                        _yearCarTB.Text = selectedCar._year.ToString();
                        _priceCarTB.Text = selectedCar._price.ToString();
                        tab = selectedCar._equipment.Split(',');
                        int i = 0, numbersOfElement=tab.Length;
                        while (numbersOfElement> 0)
                        {

                            _equipmentTB.Text += tab[i]+"\n";
                            ++i;
                            --numbersOfElement;
                            
                        }
                        
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
        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            if (_IdCarTB.Text != "" && customer._id != 0)
            {
                foreach (Car car in listCars)
                {
                    if (car._Id == Convert.ToInt32(_IdCarTB.Text))
                    {
                        rentalList.Add(car);

                    }
                }
                _listCarsLB.Items.Remove(_listCarsLB.SelectedItem);

            }
        }
        private void OK_Click(object sender, RoutedEventArgs e)
        {
            string flag = "";
            if (_brandCarCB.SelectedValue != null)
                flag += "b";
            if (_modelCarCB.SelectedValue != null)
                flag += "m";
            if (_priceTB.Text != "")
                flag += "p";
            if (_yearTB.Text != "")
                flag += "y";
            SearchCar(flag);
        }
        #endregion

        #region MenuBar
        private void MyCars_Click(object sender, RoutedEventArgs e)
        {
            ClearList();
            int i = 1;
            foreach (Car car in rentalList)
            {
                _listCarsLB.Items.Add(string.Format("{0}.{1} - {2}", Convert.ToString(i), car._brand, car._model));
                ++i;
            }
        }       

        private void AddCar_Click(object sender, RoutedEventArgs e)
        {
           
                if (customer._id == 1)
                {
                    AdditionCarsWindow addWindow = new AdditionCarsWindow();
                    addWindow.Show();
                }
                else MessageBox.Show("Only the administrator can add a car");
            
            
                
        }
        private void ShowList_Click(object sender, RoutedEventArgs e)
        {
            InitializeListCar();
        }

        private void ChangePassword_Click(object sender, RoutedEventArgs e)
        {
            ChangePasswordWindow changePassword = new ChangePasswordWindow();
            changePassword.ShowDialog();
            
        }

        private void ChangeSurname_Click(object sender, RoutedEventArgs e)
        {
            ChangeSurnameWindow changeSurname = new ChangeSurnameWindow();
            changeSurname.Show();
           
        }
        private void Log_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show($"Goodbye {customer._name}");
            this.Close();
            MainWindow window = new MainWindow();
            window.Show();

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show($"Goodbye + {customer._name}");
            this.Close();
        }

        #endregion

       
    } 
    
}



