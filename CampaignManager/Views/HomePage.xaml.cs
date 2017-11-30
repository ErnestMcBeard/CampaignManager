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

        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            ViewModel.NavigateToEncounterScreen(e.ClickedItem as CampaignController);
        }

        #region PlayerButtons
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

        private async void AddPlayerAbilityButton_Click(object sender, RoutedEventArgs e)
        {
            await new AddAbilityToPlayerDialog(ViewModel.SelectedPlayer.Id).ShowAsync();
            ViewModel.GetPlayerItems();
        }

        private void RemovePlayerAbilityButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.RemoveAbilityFromPlayer((PlayerAbilityListView.SelectedValue as AbilityController).Id);
            ViewModel.GetPlayerItems();
        }

        private void RemovePlayerActionButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.RemoveActionFromPlayer((PlayerActionListView.SelectedValue as ActionController).Id);
            ViewModel.GetPlayerItems();
        }

        private async void AddPlayerActionButton_Click(object sender, RoutedEventArgs e)
        {
            await new AddActionToPlayerDialog(ViewModel.SelectedPlayer.Id).ShowAsync();
            ViewModel.GetPlayerItems();
        }

        private void RemovePlayerSpellButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.RemoveSpellFromPlayer((PlayerSpellListView.SelectedValue as SpellController).Id);
            ViewModel.GetPlayerItems();
        }

        private async void AddPlayerSpellButton_Click(object sender, RoutedEventArgs e)
        {
            await new AddSpellToPlayerDialog(ViewModel.SelectedPlayer.Id).ShowAsync();
            ViewModel.GetPlayerItems();
        }

        private void RemovePlayerItemButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.RemoveItemFromPlayer((PlayerItemListView.SelectedValue as ItemController).Id);
            ViewModel.GetPlayerItems();
        }

        private async void AddPlayerItemButton_Click(object sender, RoutedEventArgs e)
        {
            await new AddItemToPlayerDialog(ViewModel.SelectedPlayer.Id).ShowAsync();
            ViewModel.GetPlayerItems();
        }
        #endregion

        #region MonsterButtons
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
                ViewModel.SelectedMonster?.Save();
            }
            ViewModel.GetMonsters();
        }

        private void AddMonsterButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.SelectedMonster = new MonsterController();
        }

        private void RemoveMonsterAbilityButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.RemoveAbilityFromMonster((MonsterAbilityListView.SelectedValue as AbilityController).Id);
            ViewModel.GetMonsterItems();
        }

        private async void AddMonsterAbilityButton_Click(object sender, RoutedEventArgs e)
        {
            await new AddAbilityToMonsterDialog(ViewModel.SelectedMonster.Id).ShowAsync();
            ViewModel.GetMonsterItems();
        }

        private async void AddMonsterActionButton_Click(object sender, RoutedEventArgs e)
        {
           await new AddActionToMonsterDialog(ViewModel.SelectedMonster.Id).ShowAsync();
           ViewModel.GetMonsterItems();
        }

        private void RemoveMonsterActionButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.RemoveActionFromMonster((MonsterActionListView.SelectedValue as ActionController).Id);
            ViewModel.GetMonsterItems();
        }
        #endregion

        #region ItemButtons
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
        #endregion

        #region SpellButtons
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
        #endregion

        #region AbilityButtons
        private void DeleteAbilityButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.SelectedAbility?.Delete();
            ViewModel.GetAbilities();
        }

        private void SaveAbilityButton_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.SelectedAbility?.Id == 0)
            {
                ViewModel.SelectedAbility.Add();
            }
            else
            {
                ViewModel.SelectedAbility.Save();
            }
            ViewModel.GetAbilities();
        }

        private void AddAbilityButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.SelectedAbility = new AbilityController();
        }
        #endregion

        #region ActionButtons
        private void DeleteActionButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.SelectedAction?.Delete();
            ViewModel.GetActions();
        }

        private void SaveActionButton_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.SelectedAction?.Id == 0)
            {
                ViewModel.SelectedAction.Add();
            }
            else
            {
                ViewModel.SelectedAction?.Save();
            }
            ViewModel.GetActions();
        }

        private void AddActionButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.SelectedAction = new ActionController();
        }
        #endregion
    }
}
