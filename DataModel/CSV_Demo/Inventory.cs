using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.CSV_Demo
{
    public class Inventory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AvailableStock { get; set; }
        public int Price { get; set; }
        public Inventory() { }  

        //1,TV,Entertainment,10,50000
    }
}
