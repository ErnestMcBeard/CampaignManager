using CampaignManager.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CampaignManager.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CampaignPage : Page
    {
        private CampaignViewModel ViewModel;

        public CampaignPage()
        {
            this.InitializeComponent();
        }

        override protected void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel = (DataContext as CampaignViewModel);
            ViewModel.NavigatedTo((int)e.Parameter);
        }

        private void AddPlayerButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EncounterList_ItemClick(object sender, ItemClickEventArgs e)
        {
            ViewModel.EncounterSelected(e.ClickedItem as Models.EncounterController);
        }

        private void EncounterList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddEncounterButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.AddEncounterClick();
        }

        private void SaveEncounterButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.SaveEncounterClick();
        }

        private void DeleteEncounterButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.DeleteEncounterClick();
        }

        private void AddMonsterButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.AddMonsterClick();
        }

        private void DeleteMonsterButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.DeleteMonsterClick();
        }
    }
}
