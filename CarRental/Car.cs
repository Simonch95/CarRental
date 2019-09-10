using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental
{
   public class Car
    {
        public int _Id { get; set; }
        public string _brand { get; set; }
        public string _model { get; set; }
        public int _year { get; set; }
        public double _price { get; set; }
        public int _mileage { get; set; }
        public string _equipment { get; set; }
        public Car(int id, string brand, string model, int year, double price, int mileage, string equipment)
        {
            _Id = id;
            _brand = brand;
            _model = model;
            _year = year;
            _price = price;
            _mileage = mileage;
            _equipment = equipment;

        }
        public Car()
        {

        }
        public override string ToString()
        {
            return _brand + " "+_model;
        }
    }
}
