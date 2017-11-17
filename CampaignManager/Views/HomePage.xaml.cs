using CampaignManager.ViewModels;
using GalaSoft.MvvmLight.Views;
using Windows.UI.Xaml.Controls;

namespace CampaignManager.Views
{
    public sealed partial class HomePage : Page
    {
        private HomeViewModel ViewModel
        {
            get { return DataContext as HomeViewModel; }
        }

        public HomePage()
        {
            InitializeComponent();
        }

        private void AddCampaignButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            
        }

        private void AddCharacterButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

        }

        private void AddMonsterButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

        }

        private void AddItemButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

        }

        private void AddSpellButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

        }
    }
}
