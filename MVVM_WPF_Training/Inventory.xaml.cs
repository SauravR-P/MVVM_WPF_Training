using BusinessModel;
using DataModel.CSV_Demo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace View
{
    /// <summary>
    /// Interaction logic for Inventory.xaml
    /// </summary>
    public partial class Inventory : Window
    {
        private InventoryVM inventoryVM;
        public Inventory()
        {
            InitializeComponent();
            inventoryVM = new InventoryVM();

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            
        }
    }
}
