using BackgroundService;


namespace BusinessModel.DILayer
{
    public class NinjectBindings : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<IDate_TimeService>().To<Date_TimeService>().InSingletonScope();
            Bind<InventoryVM>().ToSelf().InTransientScope(); // Create new instance every time
            Bind<BooksViewModel>().ToSelf().InTransientScope(); // Create new instance every time
            Bind<Student_ViewModel>().ToSelf().InTransientScope(); // Create new instance every time
        }
    }
}
