using System;
using CampaignManager.ViewModels;
using Windows.UI.Xaml.Controls;

namespace CampaignManager.Views
{
    public sealed partial class HomePagePage : Page
    {
        private HomePageViewModel ViewModel
        {
            get { return DataContext as HomePageViewModel; }
        }

        public HomePagePage()
        {
            InitializeComponent();
        }
    }
}
