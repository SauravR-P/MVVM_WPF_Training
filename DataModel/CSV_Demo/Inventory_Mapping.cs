using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.CSV_Demo
{ 
    public class Inventory_Mapping : ClassMap<Inventory>
{
    public Inventory_Mapping()
    {
        Map(x => x.Id).Name("Id");
        Map(x => x.Name).Name("Name");
        Map(x => x.Description).Name("Description");
        Map(x => x.AvailableStock).Name("AvailableStock");
        Map(x => x.Price).Name("Price");

    }
}
}
