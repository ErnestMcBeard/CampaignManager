using System;

using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using CampaignManager.Models;

namespace CampaignManager.ViewModels
{
    public class HomePageViewModel : ViewModelBase
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

        public HomePageViewModel()
        {
            
        }
    }
}
