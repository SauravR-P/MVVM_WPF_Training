using BusinessModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVVM_WPF_Training
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public List<Var> inventories { get; set; }
        private InventoryVM _inventoryVM;
        public MainWindow()
        {
            InitializeComponent();
            //inventories = new();
            _inventoryVM = new InventoryVM();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //var id = Convert.ToInt32(ID.Text);
            //var name = Name.Text;
            //var description = Description.Text;
            //var stock = Convert.ToInt32(AvailableStock.Text);
            //var price = Convert.ToInt32(Prices.Text);

            //inventories.Add(new Inventory { Id = id, Name = name, Description = description, AvailableStock = stock, Price = price });
            //_inventoryVM.WriteCsv(inventories);


        }
    }
}
