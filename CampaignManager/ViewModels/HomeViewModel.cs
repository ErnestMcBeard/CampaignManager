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

        private ObservableCollection<AbilityController> abilities = new ObservableCollection<AbilityController>();
        public ObservableCollection<AbilityController> Abilities
        {
            get { return abilities; }
            set { Set(() => Abilities, ref abilities, value); }
        }

        private ObservableCollection<ActionController> actions = new ObservableCollection<ActionController>();
        public ObservableCollection<ActionController> Actions
        {
            get { return actions; }
            set { Set(() => Actions, ref actions, value); }
        }
        #endregion

        #region SelectedItems
        private PlayerController selectedPlayer = new PlayerController();
        public PlayerController SelectedPlayer
        {
            get { return selectedPlayer; }
            set
            {
                Set(() => SelectedPlayer, ref selectedPlayer, value);
                GetPlayerItems();
            }
        }

        #region PlayerItems
        private ObservableCollection<ItemController> playerItems = new ObservableCollection<ItemController>();
        public ObservableCollection<ItemController> PlayerItems
        {
            get { return playerItems; }
            set { Set(() => PlayerItems, ref playerItems, value); }
        }

        private ObservableCollection<SpellController> playerSpells = new ObservableCollection<SpellController>();
        public ObservableCollection<SpellController> PlayerSpells
        {
            get { return playerSpells; }
            set { Set(() => PlayerSpells, ref playerSpells, value); }
        }

        private ObservableCollection<ActionController> playerActions = new ObservableCollection<ActionController>();
        public ObservableCollection<ActionController> PlayerActions
        {
            get { return playerActions; }
            set { Set(() => PlayerActions, ref playerActions, value); }
        }

        private ObservableCollection<AbilityController> playerAbilities = new ObservableCollection<AbilityController>();
        public ObservableCollection<AbilityController> PlayerAbilities
        {
            get { return playerAbilities; }
            set { Set(() => PlayerAbilities, ref playerAbilities, value); }
        }

        public void GetPlayerItems()
        {
            var playerId = SelectedPlayer.Id;
            PlayerItems?.Clear();
            PlayerSpells?.Clear();
            PlayerActions?.Clear();
            PlayerAbilities?.Clear();
            using (var db = SQLiteHelper.CreateConnection())
            {
                var itemQuery = db.Table<Player_Item>().Where(x => x.PlayerId == playerId);
                foreach (var playerItem in itemQuery)
                {
                    var item = db.Table<Item>().Where(x => x.Id == playerItem.ItemId).First();
                    PlayerItems.Add((ItemController)item);
                }
                var spellQuery = db.Table<Player_Spell>().Where(x => x.PlayerId == playerId);
                foreach (var playerSpell in spellQuery)
                {
                    var spell = db.Table<Spell>().Where(x => x.Id == playerSpell.SpellId).First();
                    PlayerSpells.Add((SpellController)spell);
                }
                var actionQuery = db.Table<Player_Action>().Where(x => x.PlayerId == playerId);
                foreach (var playerAction in actionQuery)
                {
                    var action = db.Table<Action>().Where(x => x.Id == playerAction.ActionId).First();
                    PlayerActions.Add((ActionController)action);
                }
                var abilityQuery = db.Table<Player_Ability>().Where(x => x.PlayerId == playerId);
                foreach (var playerAbility in abilityQuery)
                {
                    var ability = db.Table<Ability>().Where(x => x.Id == playerAbility.AbilityId).First();
                    PlayerAbilities.Add((AbilityController)ability);
                }
            }
        }
        #endregion

        private MonsterController selectedMonster = new MonsterController();
        public MonsterController SelectedMonster
        {
            get { return selectedMonster; }
            set { Set(() => SelectedMonster, ref selectedMonster, value); }
        }

        #region MonsterItems
        private ObservableCollection<AbilityController> monsterAbilities;
        public ObservableCollection<AbilityController> MonsterAbilities
        {
            get { return monsterAbilities; }
            set { Set(() => MonsterAbilities, ref monsterAbilities, value); }
        }

        private ObservableCollection<ActionController> monsterActions;
        public ObservableCollection<ActionController> MonsterActions
        {
            get { return monsterActions; }
            set { Set(() => MonsterActions, ref monsterActions, value); }
        }

        public void GetMonsterItems()
        {
            var monsterId = SelectedMonster.Id;
            MonsterAbilities?.Clear();
            MonsterActions?.Clear();
            using (var db = SQLiteHelper.CreateConnection())
            {
                var abilityQuery = db.Table<Monster_Ability>().Where(x => x.MonsterId == monsterId);
                foreach (var monsterAbility in abilityQuery)
                {
                    var ability = db.Table<Ability>().Where(x => x.Id == monsterAbility.AbilityId).First();
                    MonsterAbilities.Add((AbilityController)ability);
                }
                var actionQuery = db.Table<Monster_Action>().Where(x => x.ActionId == monsterId);
                foreach (var monsterAction in actionQuery)
                {
                    var action = db.Table<Action>().Where(x => x.Id == monsterAction.ActionId).First();
                    MonsterActions.Add((ActionController)action);
                }
            }
        }
        #endregion

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

        private AbilityController selectedAbility = new AbilityController();
        public AbilityController SelectedAbility
        {
            get { return selectedAbility; }
            set { Set(() => SelectedAbility, ref selectedAbility, value); }
        }

        private ActionController selectedAction = new ActionController();
        public ActionController SelectedAction
        {
            get { return selectedAction; }
            set { Set(() => SelectedAction, ref selectedAction, value); }
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
            GetAbilities();
            GetActions();
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

        public void GetAbilities()
        {
            Abilities.Clear();
            using (var db = SQLiteHelper.CreateConnection())
            {
                var abilityQuery = db.Table<Ability>();
                foreach (var ability in abilityQuery)
                {
                    Abilities.Add((AbilityController)ability);
                }
            }
        }

        public void GetActions()
        {
            Actions.Clear();
            using (var db = SQLiteHelper.CreateConnection())
            {
                var actionsQuery = db.Table<Action>();
                foreach (var action in actionsQuery)
                {
                    Actions.Add((ActionController)action);
                }
            }
        }
        #endregion

        #region RemoveRelationships
        public void RemoveAbilityFromPlayer(int abilityId)
        {
            using (var db = SQLiteHelper.CreateConnection())
            {
                var playerAbility = db.Table<Player_Ability>().Where(x => x.PlayerId == SelectedPlayer.Id && x.AbilityId == abilityId);
                db.Delete(playerAbility);
            }
        }

        public void RemoveActionFromPlayer(int actionId)
        {
            using (var db = SQLiteHelper.CreateConnection())
            {
                var playerAction = db.Table<Player_Action>().Where(x => x.PlayerId == SelectedPlayer.Id && x.ActionId == actionId);
                db.Delete(playerAction);
            }
        }

        public void RemoveSpellFromPlayer(int spellId)
        {
            using (var db = SQLiteHelper.CreateConnection())
            {
                var playerSpell = db.Table<Player_Spell>().Where(x => x.PlayerId == SelectedPlayer.Id && x.SpellId == spellId);
                db.Delete(playerSpell);
            }
        }

        public void RemoveItemFromPlayer(int itemId)
        {
            using (var db = SQLiteHelper.CreateConnection())
            {
                var playerItem = db.Table<Player_Item>().Where(x => x.PlayerId == SelectedPlayer.Id && x.ItemId == itemId);
                db.Delete(playerItem);
            }
        }

        public void RemoveAbilityFromMonster(int abilityId)
        {
            using (var db = SQLiteHelper.CreateConnection())
            {
                var monsterAbility = db.Table<Monster_Ability>().Where(x => x.MonsterId == SelectedMonster.Id && x.AbilityId == abilityId);
                db.Delete(monsterAbility);
            }
        }

        public void RemoveActionFromMonster(int actionId)
        {
            using (var db = SQLiteHelper.CreateConnection())
            {
                var monsterAction = db.Table<Monster_Action>().Where(x => x.MonsterId == SelectedMonster.Id && x.ActionId == actionId);
                db.Delete(monsterAction);
            }
        }
        #endregion
    }
}
