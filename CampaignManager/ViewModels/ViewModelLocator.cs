using System;

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
            Register<AddCampaignViewModel, AddCampaignPage>();
            Register<AddMonsterViewModel, AddMonsterPage>();
            Register<AddItemViewModel, AddItemPage>();
            Register<AddSpellViewModel, AddSpellViewModel>();
        }

        public HomeViewModel HomePageViewModel => ServiceLocator.Current.GetInstance<HomeViewModel>();
        public AddCampaignViewModel AddCampaignViewModel => ServiceLocator.Current.GetInstance<AddCampaignViewModel>();
        public AddCharacterViewModel AddCharacterViewModel => ServiceLocator.Current.GetInstance<AddCharacterViewModel>();
        public AddMonsterViewModel AddMonsterViewModel => ServiceLocator.Current.GetInstance<AddMonsterViewModel>();
        public AddItemViewModel AddItemViewModel => ServiceLocator.Current.GetInstance<AddItemViewModel>();
        public AddSpellViewModel AddSpellViewModel => ServiceLocator.Current.GetInstance<AddSpellViewModel>();

        public NavigationServiceEx NavigationService => ServiceLocator.Current.GetInstance<NavigationServiceEx>();

        public void Register<VM, V>() where VM : class
        {
            SimpleIoc.Default.Register<VM>();

            NavigationService.Configure(typeof(VM).FullName, typeof(V));
        }
    }
}
