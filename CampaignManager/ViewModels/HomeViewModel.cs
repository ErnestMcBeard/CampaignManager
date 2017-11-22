using CampaignManager.Helpers;
using CampaignManager.Models;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;

namespace CampaignManager.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private ObservableCollection<Campaign> campaigns = new ObservableCollection<Campaign>();
        public ObservableCollection<Campaign> Campaigns
        {
            get { return campaigns; }
            set { Set(() => Campaigns, ref campaigns, value); }
        }

        private ObservableCollection<Character> characters = new ObservableCollection<Character>();
        public ObservableCollection<Character> Characters
        {
            get { return characters; }
            set { Set(() => Characters, ref characters, value); }
        }

        private ObservableCollection<Monster> monsters = new ObservableCollection<Monster>();
        public ObservableCollection<Monster> Monsters
        {
            get { return monsters; }
            set { Set(() => monsters, ref monsters, value); }
        }

        private ObservableCollection<Item> items = new ObservableCollection<Item>();
        public ObservableCollection<Item> Items
        {
            get { return items; }
            set { Set(() => Items, ref items, value); }
        }

        private ObservableCollection<Spell> spells = new ObservableCollection<Spell>();
        public ObservableCollection<Spell> Spells
        {
            get { return spells; }
            set { Set(() => Spells, ref spells, value); }
        }

        public HomeViewModel()
        {
            Refresh();
        }

        public void Refresh()
        {
            GetItems();
            GetSpells();
        }

        public void GetItems()
        {
            using (var db = SQLiteHelper.CreateConnection())
            {
                var itemQuery = db.Table<Item>();
                foreach (var item in itemQuery)
                {
                    Items.Add(item);
                }
            }
        }

        public void GetSpells()
        {
            using (var db = SQLiteHelper.CreateConnection())
            {
                var spellQuery = db.Table<Spell>();
                foreach (var spell in spellQuery)
                {
                    Spells.Add(spell);
                }
            }
        }
    }
}
