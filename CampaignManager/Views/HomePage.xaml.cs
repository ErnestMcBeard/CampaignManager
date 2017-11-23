using CampaignManager.ContentDialogs;
using CampaignManager.Models;
using CampaignManager.ViewModels;
using System;
using Windows.UI.Xaml;
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

        private async void AddCampaignButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            await new AddCampaignDialog().ShowAsync();
            ViewModel.GetCampaigns();
        }

        private void DeletePlayerButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.SelectedPlayer?.Delete();
            ViewModel.GetPlayers();
        }

        private void SavePlayerButton_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.SelectedPlayer?.Id == 0)
            {
                ViewModel.SelectedPlayer.Add();
                ViewModel.SelectedPlayer = new PlayerController();
            }
            else
            {
                ViewModel.SelectedPlayer?.Save();
            }
            ViewModel.GetPlayers();
        }

        private void AddPlayerButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.SelectedPlayer = new PlayerController();
        }

        private void DeleteMonsterButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.SelectedMonster?.Delete();
            ViewModel.GetMonsters();
        }

        private void SaveMonsterButton_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.SelectedMonster?.Id == 0)
            {
                ViewModel.SelectedMonster.Add();
                ViewModel.SelectedMonster = new MonsterController();
            }
            else
            {
                ViewModel.SelectedMonster.Save();
            }
            ViewModel.GetMonsters();
        }

        private void AddMonsterButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.SelectedMonster = new MonsterController();
        }

        private async void AddItemButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AddItemDialog();
            await dialog.ShowAsync();
            ViewModel.GetItems();
        }

        private void SaveItemButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.SelectedItem?.Save();
            ViewModel.GetItems();
        }

        private void DeleteItemButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.SelectedItem?.Delete();
            ViewModel.GetItems();
        }

        private async void AddSpellButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AddSpellDialog();
            await dialog.ShowAsync();
            ViewModel.GetSpells();
        }

        private void SaveSpellButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.SelectedSpell?.Save();
            ViewModel.GetSpells();
        }

        private void DeleteSpellButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.SelectedSpell?.Delete();
            ViewModel.GetSpells();
        }

        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            ViewModel.NavigateToEncounterScreen(e.ClickedItem as CampaignController);
        }
    }
}
