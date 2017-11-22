using CampaignManager.Helpers;
using CampaignManager.Models;
using CampaignManager.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using System.Collections.ObjectModel;

namespace CampaignManager.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        #region ListViewItems
        private ObservableCollection<CampaignController> campaigns = new ObservableCollection<CampaignController>();
        public ObservableCollection<CampaignController> Campaigns
        {
            get { return campaigns; }
            set { Set(() => Campaigns, ref campaigns, value); }
        }

        private ObservableCollection<PlayerController> players = new ObservableCollection<PlayerController>();
        public ObservableCollection<PlayerController> Players
        {
            get { return players; }
            set { Set(() => Players, ref players, value); }
        }

        private ObservableCollection<MonsterController> monsters = new ObservableCollection<MonsterController>();
        public ObservableCollection<MonsterController> Monsters
        {
            get { return monsters; }
            set { Set(() => monsters, ref monsters, value); }
        }

        private ObservableCollection<ItemController> items = new ObservableCollection<ItemController>();
        public ObservableCollection<ItemController> Items
        {
            get { return items; }
            set { Set(() => Items, ref items, value); }
        }

        private ObservableCollection<SpellController> spells = new ObservableCollection<SpellController>();
        public ObservableCollection<SpellController> Spells
        {
            get { return spells; }
            set { Set(() => Spells, ref spells, value); }
        }
        #endregion

        #region SelectedItems
        private PlayerController selectedPlayer = new PlayerController();
        public PlayerController SelectedPlayer
        {
            get { return selectedPlayer; }
            set { Set(() => SelectedPlayer, ref selectedPlayer, value); }
        }

        private MonsterController selectedMonster = new MonsterController();
        public MonsterController SelectedMonster
        {
            get { return selectedMonster; }
            set { Set(() => SelectedMonster, ref selectedMonster, value); }
        }

        private ItemController selectedItem;
        public ItemController SelectedItem
        {
            get { return selectedItem; }
            set { Set(() => SelectedItem, ref selectedItem, value); }
        }

        private SpellController selectedSpell;
        public SpellController SelectedSpell
        {
            get { return selectedSpell; }
            set { Set(() => SelectedSpell, ref selectedSpell, value); }
        }
        #endregion

        #region NewItems
        private PlayerController newPlayer;
        public PlayerController NewPlayer
        {
            get { return newPlayer; }
            set { Set(() => newPlayer, ref newPlayer, value); }
        }

        private MonsterController newMonster;
        public MonsterController NewMonster
        {
            get { return newMonster; }
            set { Set(() => newMonster, ref newMonster, value); }
        }
        #endregion

        #region ComboBoxItems
        private ObservableCollection<Alignment> alignments;
        public ObservableCollection<Alignment> Alignments
        {
            get { return alignments; }
            set { Set(() => Alignments, ref alignments, value); }
        }
        #endregion

        public HomeViewModel()
        {
            Refresh();
            NewPlayer = new PlayerController();
            NewMonster = new MonsterController();
            Alignments = new ObservableCollection<Alignment>(Alignment.GetAlignments());
        }

        public void Refresh()
        {
            GetCampaigns();
            GetPlayers();
            GetMonsters();
            GetItems();
            GetSpells();
        }

        public void NavigateToEncounterScreen(CampaignController campaign)
        {
            var navigationService = ServiceLocator.Current.GetInstance<NavigationServiceEx>();
            navigationService.Navigate(typeof(CampaignViewModel).ToString(), campaign.Id);
        }

        #region GetData
        public void GetCampaigns()
        {
            Campaigns.Clear();
            using (var db = SQLiteHelper.CreateConnection())
            {
                var campaignQuery = db.Table<Campaign>();
                foreach (var campaign in campaignQuery)
                {
                    Campaigns.Add((CampaignController)campaign);
                }
            }
        }

        public void GetPlayers()
        {
            Players.Clear();
            using (var db = SQLiteHelper.CreateConnection())
            {
                var playerQuery = db.Table<Player>();
                foreach (var player in playerQuery)
                {
                    Players.Add((PlayerController)player);
                }
            }
        }

        public void GetMonsters()
        {
            Monsters.Clear();
            using (var db = SQLiteHelper.CreateConnection())
            {
                var monsterQuery = db.Table<Monster>();
                foreach (var monster in monsterQuery)
                {
                    Monsters.Add((MonsterController)monster);
                }
            }
        }

        public void GetItems()
        {
            Items.Clear();
            using (var db = SQLiteHelper.CreateConnection())
            {
                var itemQuery = db.Table<Item>();
                foreach (var item in itemQuery)
                {
                    Items.Add((ItemController)item);
                }
            }
        }

        public void GetSpells()
        {
            Spells.Clear();
            using (var db = SQLiteHelper.CreateConnection())
            {
                var spellQuery = db.Table<Spell>();
                foreach (var spell in spellQuery)
                {
                    Spells.Add((SpellController)spell);
                }
            }
        }
        #endregion
    }
}
