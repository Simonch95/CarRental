using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental
{
  public  class Customer
    {

        public int _id { get; set; }
        public string _login { get; set; }
        public string _password { get; set; }
        public string _name { get; set; }
        public string _surname { get; set; }
        List<Car> rentalCarList = new List<Car>();
        public Customer()
        {
            
        }
        public Customer(int id, string login, string password, string name, string surname)
        {
            this._id = id;
            this._login = login;
            this._password = password;
            this._name = name;
            this._surname = surname;

        }
        public void RentalCarList(Car car)
        {
            rentalCarList.Add(car);
        }
    }
}
