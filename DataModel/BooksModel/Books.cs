using System.ComponentModel;
using System.Xml.Linq;

namespace DataModel.BooksModel
{
    public class Books : INotifyPropertyChanged
    {
        private int _bookid, _price, _quantity;
        private string _bookName, _author;

        public int BookId
        { get { return _bookid; } set { _bookid = value; OnPropertyChange("BookId"); } }
        public string Name
        {
            get { return _bookName; }
            set { _bookName = value; OnPropertyChange("Name"); } 
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
