

using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using MailSenderLib.Linq2SQL;
using MailSenderLib.Services;
using MailSenderLib.Services.Interfaces;
//using Microsoft.Practices.ServiceLocation;

namespace Lesson1.ViewModel
{
    public class ViewModelLocator
    {        
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}
            SimpleIoc.Default.Register(() => new MailSenderDB());
            SimpleIoc.Default.Register<IRecepientsData, RecepientsDataLinq2SQL>();


            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<MainWindowViewModel>();
        }

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
        public MainWindowViewModel MainWindowModel => ServiceLocator.Current.GetInstance<MainWindowViewModel>();
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}