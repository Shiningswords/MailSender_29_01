/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:MailSender"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using CommonServiceLocator;
using MailSender.lib.Services;
using MailSender.lib.Services.Interfaces;
using MailSender.lib.Services.InMemory;
using MailSender.Infrastructure.Services.Interfaces;
using MailSender.Infrastructure.Services;

namespace MailSender.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
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
            var services = SimpleIoc.Default;

            services.Register<MainWindowViewModel>();
            services.Register<IRecipientsManager,RecipientsManager>();
            services.Register<IRecipientsStore, RecipientsStoreInMemory>();
            services.Register<ISendersStore, SendersStoreInMemory>();
            services.Register<IServersStore, ServersStoreInMemory>();
            services.Register<IMailsStore, MailsStoreInMemory>();
            services.Register<ISenderEditor, WindowSenderEditor>();
        }

        public MainWindowViewModel MainWindowModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainWindowViewModel>();
            }
        }
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}