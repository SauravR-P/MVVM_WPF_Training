﻿using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.CSV_Demo
{
    public class Inventory_Binding
    {
        public static string path = "C:\\Users\\SAURAMES\\Downloads\\UsingWPF\\Inventory.csv";


        //string[] lines = System.IO.File.ReadAllLines("path");
        public List<Inventory> ReadCSVFile()
        {
            try
            {
                using (var reader = new StreamReader(path, Encoding.Default))
                using (var csv = new CsvReader(reader))
                {
                    csv.Configuration.RegisterClassMap<Inventory_Mapping>();
                    var records = csv.GetRecords<Inventory>().ToList();
                    //inventories.AddRange(records);
                    return records;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        public void WriteCSVFile( List<Inventory> inventories)
        {
            using (StreamWriter sw = new StreamWriter(path, false, new UTF8Encoding(true)))
            using (CsvWriter cw = new CsvWriter(sw))
            {
                cw.WriteHeader<Inventory>();
                cw.NextRecord();
                foreach (Inventory inv in inventories)
                {
                    cw.WriteRecord<Inventory>(inv);
                    cw.NextRecord();
                    
                }

            }
        }
    }
}

