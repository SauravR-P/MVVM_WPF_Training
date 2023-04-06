using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.CSV_Demo
{
    public class Inventory : INotifyPropertyChanged
    {
        private int _id, availableStock, price;
        private string name, description;
        public int Id { get { return _id; } set { _id = value;OnPropertyChange(nameof(Id));} }
        public string Name { get { return name; } set { name = value; OnPropertyChange("Name"); } }
        public string Description { get { return description; } set { description = value; OnPropertyChange("Description"); } }
        public int AvailableStock { get { return availableStock; } set { availableStock = value; OnPropertyChange("AvailableStock"); } }
        public int Price { get { return price; } set { price = value; OnPropertyChange("Price"); } }

        public Inventory() { }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }



        //1,TV,Entertainment,10,50000
    }
}
