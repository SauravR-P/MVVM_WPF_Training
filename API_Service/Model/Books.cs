﻿using System.ComponentModel;
using System.Xml.Linq;

namespace API_Service.Model
{
    public class Books : INotifyPropertyChanged
    {
        private int _id, _price, _quantity;
        private string _bookName, _author;

        public int Id
        { get { return _id; } set { _id = value; OnPropertyChange("Id"); } }
        public string Book_Name
        {
            get { return _bookName; }
            set { _bookName = value; OnPropertyChange("Book_Name"); } 
        }
        public string Author
        {
            get { return _bookName; }
            set { _bookName = value; OnPropertyChange("Author"); }
        }
        public int Price
        { get { return _price; } set { _price = value; OnPropertyChange("Price"); } }
        public int Quantity
        { get { return _quantity; } set { _quantity = value; OnPropertyChange("Quantity"); } }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
