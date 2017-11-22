using CampaignManager.Services;
using CampaignManager.Views;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace CampaignManager.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register(() => new NavigationServiceEx());
            Register<HomeViewModel, HomePage>();
            Register<AddCharacterViewModel, AddCharacterPage>();
            Register<CampaignViewModel, CampaignPage>();
        }

        public HomeViewModel HomePageViewModel => ServiceLocator.Current.GetInstance<HomeViewModel>();
        public AddCharacterViewModel AddCharacterViewModel => ServiceLocator.Current.GetInstance<AddCharacterViewModel>();
        public CampaignViewModel CampaignPageViewModel => ServiceLocator.Current.GetInstance<CampaignViewModel>();
        public NavigationServiceEx NavigationService => ServiceLocator.Current.GetInstance<NavigationServiceEx>();

        public void Register<VM, V>() where VM : class
        {
            SimpleIoc.Default.Register<VM>();

            NavigationService.Configure(typeof(VM).FullName, typeof(V));
        }
    }
}
