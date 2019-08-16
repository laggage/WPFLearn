using Autofac;
using Demo.Share;

namespace Demo.DataValidation.ViewModels
{
    public class ViewModelLocator:ViewModelBase
    {
        private static IContainer _container;
        public static IContainer Container => _container;

        public ViewModelLocator()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterType<MainViewModel>().SingleInstance();
            builder.RegisterType<BookInfoInputViewModel>().InstancePerDependency();

            _container = builder.Build();
        }

        public MainViewModel Main => Container.Resolve<MainViewModel>();
        public BookInfoInputViewModel BookInfoInput => Container.Resolve<BookInfoInputViewModel>();
    }
}
