using BackgroundService;
using Commands;
using CsvHelper;
using DataModel.CSV_Demo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BusinessModel
{
    public class InventoryVM : INotifyPropertyChanged
    {
        private IDate_TimeService _datetimeservice;

        public static string path = "C:\\Users\\SAURAMES\\source\\repos\\MVVM_WPF_Training\\Inventory.csv";
        private ICommand _clickcommand_Del, _clickcommand_Update, _clickcommand_Add, _clickcommand_Save;
        DataModel.CSV_Demo.Inventory _inventory;
        private ObservableCollection<DataModel.CSV_Demo.Inventory> _inventoryVMs;
        public ObservableCollection<DataModel.CSV_Demo.Inventory> InventoryVMs { get { return _inventoryVMs; } set { _inventoryVMs = value; OnPropertyChange("InventoryVMs"); } }
        public event PropertyChangedEventHandler? PropertyChanged;
        private DateTime currDate;
        public DateTime CurrDate
        {
            get { return currDate; }
            set { currDate = value; OnPropertyChange("CurrDate"); }
        }

        public InventoryVM(IDate_TimeService datetimeservice)
        {
            _datetimeservice = datetimeservice;
            CurrDate = datetimeservice.GetDate();
            _inventory = new();
            InventoryVMs = _inventory.ReadCSVFile();

        }
        public void Remove_Index(int index)
        {
            try
            {
                InventoryVMs.RemoveAt(index);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message + "Delete Failed");
            }

        }
        public void Add_Item(DataModel.CSV_Demo.Inventory inventory)
        {
            try
            {
                var existingValue = InventoryVMs.FirstOrDefault(x => x.Id == inventory.Id);
                if (existingValue == null)
                {
                    InventoryVMs.Add(inventory);
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message + "Add Failed");
            }
        }
        public void Update_Item(DataModel.CSV_Demo.Inventory inventory)
        {

            try
            {
                InventoryVMs.RemoveAt(inventory.Id);
                var existingValue = InventoryVMs.FirstOrDefault(x => x.Id == inventory.Id);
                if (existingValue != null)
                {
                   
                    existingValue.Id = inventory.Id;
                    existingValue.Name = inventory.Name;
                    existingValue.Description = inventory.Description;
                    existingValue.Price = inventory.Price;
                    existingValue.AvailableStock = inventory.AvailableStock;
                    InventoryVMs.Add(existingValue);
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message + "Update Failed");
            }
        }
        public void WriteCSVFile()
        {
            using (StreamWriter sw = new StreamWriter(path, false, new UTF8Encoding(true)))
            using (CsvWriter cw = new CsvWriter(sw))
            {
                cw.WriteHeader<Inventory>();
                cw.NextRecord();
                foreach (Inventory inv in InventoryVMs)
                {
                    cw.WriteRecord<Inventory>(inv);
                    cw.NextRecord();

                }

            }
        }
        private void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private bool CanClick()
        {
            return true;
        }
        public ICommand ClickCommand_Delete
        {
            get
            {
                if (_clickcommand_Del == null)
                {
                    _clickcommand_Del = new RelayCommand(
                        param => Remove_Index((int)param),
                        param => CanClick());
                }
                return _clickcommand_Del;
            }
        }
        public ICommand ClickCommand_Add
        {
            get
            {
                if (_clickcommand_Add == null)
                {
                    _clickcommand_Add = new RelayCommand(
                        param => Add_Item((Inventory)param),
                        param => CanClick());
                }
                return _clickcommand_Add;
            }
        }
        public ICommand ClickCommand_Update
        {
            get
            {
                if (_clickcommand_Update == null)
                {
                    _clickcommand_Update = new RelayCommand(
                        param => Update_Item((Inventory)param),
                        param => CanClick());
                }
                return _clickcommand_Update;
            }
        }
        public ICommand ClickCommand_SaveChanges
        {
            get
            {
                if (_clickcommand_Save == null)
                {
                    if (_clickcommand_Save == null)
                        _clickcommand_Save= new RelayCommand(
                        param => WriteCSVFile(),
                        param => CanClick());
                }
                return _clickcommand_Save;
            }
        }



    }
}
