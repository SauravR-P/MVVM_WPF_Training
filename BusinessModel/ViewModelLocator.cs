using BusinessModel.DILayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel
{
    public class ViewModelLocator
    {
        public InventoryVM InventoryVM
        {
            get { return IocKernel.Get<InventoryVM>(); } // Loading UserControlViewModel will automatically load the binding for IStorage
        }
        public Student_ViewModel Student_ViewModel
        {
            get { return IocKernel.Get<Student_ViewModel>(); } // Loading UserControlViewModel will automatically load the binding for IStorage
        }
    }

}
