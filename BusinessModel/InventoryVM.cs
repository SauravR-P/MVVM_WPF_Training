using DataModel.CSV_Demo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel
{
    public class InventoryVM
    {
        Inventory_Binding Inventory_Binding = new Inventory_Binding();
        public List<Inventory> inventories //Make ObservableColl
        {
            get;

            set;
        }
        public InventoryVM()
        {
            inventories = Inventory_Binding.ReadCSVFile();
        }

        public void WriteCsv(List<Inventory> inventory)
        {
            Inventory_Binding.WriteCSVFile(inventory);
        }
    }
}
