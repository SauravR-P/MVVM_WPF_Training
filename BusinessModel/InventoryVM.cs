using DataModel.CSV_Demo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel
{
    public class InventoryVM  : INotifyPropertyChanged
    {
        Inventory_Binding Inventory_Binding = new Inventory_Binding();
        private ObservableCollection<DataModel.CSV_Demo.Inventory> _inventories;

        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<DataModel.CSV_Demo.Inventory> Inventories 
        {
            get { return _inventories; }

            set { _inventories = value;OnPropertyChange("Inventories"); }
        }


        public InventoryVM()
        {
            Inventories = Inventory_Binding.ReadCSVFile();
        }
        public void WriteCsv()
        {
            Inventory_Binding.WriteCSVFile(Inventories);
        }
        private void OnPropertyChange(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
