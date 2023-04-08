using BackgroundService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.DILayer
{
    public class NinjectBindings : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<IDate_TimeService>().To<Date_TimeService>().InSingletonScope();
           // Bind<IInventoryVM>().To<InventoryVM>().InSingletonScope();
            Bind<InventoryVM>().ToSelf().InTransientScope(); // Create new instance every time
            Bind<Student_ViewModel>().ToSelf().InTransientScope(); // Create new instance every time
        }
    }
}
