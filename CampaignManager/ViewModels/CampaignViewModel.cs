using CampaignManager.Helpers;
using CampaignManager.Models;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignManager.ViewModels
{
    public class CampaignViewModel : ViewModelBase
    {
        private enum EncounterState { Adding, Editing, None };
        private EncounterState encounterState = EncounterState.None;

        private CampaignController _campaign;
        public CampaignController Campaign
        {
            get { return _campaign; }
            set { Set(() => Campaign, ref _campaign, value); }
        }

        private ObservableCollection<EncounterController> encounters = new ObservableCollection<EncounterController>();
        public ObservableCollection<EncounterController> Encounters
        {
            get { return encounters; }
            set { Set(() => Encounters, ref encounters, value); }
        }

        private ObservableCollection<MonsterController> encounterMonsters = new ObservableCollection<MonsterController>();
        public ObservableCollection<MonsterController> EncounterMonsters
        {
            get { return encounterMonsters; }
            set { Set(() => EncounterMonsters, ref encounterMonsters, value); }
        }

        private ObservableCollection<MonsterController> allMonsters = new ObservableCollection<MonsterController>();
        public ObservableCollection<MonsterController> AllMonsters
        {
            get { return allMonsters; }
            set { Set(() => AllMonsters, ref allMonsters, value); }
        }

        private ObservableCollection<PlayerController> players = new ObservableCollection<PlayerController>();
        public ObservableCollection<PlayerController> Players
        {
            get { return players; }
            set { Set(() => Players, ref players, value); }
        }

        private string encounterDetailsHeader;
        public string EncounterDetailsHeader
        {
            get { return encounterDetailsHeader; }
            set { Set(() => EncounterDetailsHeader, ref encounterDetailsHeader, value); }
        }
        
        private EncounterController selectedEncounter;
        public EncounterController SelectedEncounter
        {
            get { return selectedEncounter; }
            set { Set(() => SelectedEncounter, ref selectedEncounter, value); }
        }

        private MonsterController selectedEncounterMonster;
        public MonsterController SelectedEncounterMonster
        {
            get { return selectedEncounterMonster; }
            set { Set(() => SelectedEncounterMonster, ref selectedEncounterMonster, value); }
        }

        private MonsterController selectedAllMonster;
        public MonsterController SelectedAllMonster
        {
            get { return selectedAllMonster; }
            set { Set(() => SelectedAllMonster, ref selectedAllMonster, value); }
        }

        public void NavigatedTo(int campaignId)
        {
            GetCampaign(campaignId);
            GetEncounters();
            ClearEncounterDetails();
            GetAllMonsters();
            GetPlayers();
        }

        private void GetCampaign(int id)
        {
            using (var db = SQLiteHelper.CreateConnection())
            {
                var query = db.Table<Campaign>();
                foreach (var campaign in query)
                {
                    if (campaign.Id == id)
                    {
                        Campaign = (CampaignController)campaign;
                        return;
                    }
                }
            }
        }

        private void GetEncounters()
        {
            Encounters.Clear();
            Encounters = Campaign.GetEncounters();
        }

        private void GetPlayers()
        {
            //using (var db = SQLiteHelper.CreateConnection())
            //{
            //    var campPlayerQuery = db.Table<Campaign_Player>();
            //    var playerQuery = db.Table<Player>().ToList();

            //    foreach (var campPlayer in campPlayerQuery)
            //    {
            //        if (campPlayer.CampaignId == campaignId)
            //        {
            //            PlayerController playerMatch = (PlayerController)playerQuery.Where(x => x.Id == campPlayer.PlayerId).FirstOrDefault();
            //            Players.Add(playerMatch);
            //        }
            //    }
            //}
        }

        private void GetAllMonsters()
        {
            AllMonsters.Clear();
            using (var db = SQLiteHelper.CreateConnection())
            {
                var table = db.Table<Monster>();
                foreach (var monster in table)
                {
                    AllMonsters.Add((MonsterController)monster);
                }
            }
        }

        private EncounterController GetLastEncounter()
        {
            return Encounters.OrderByDescending(x => x.Number).FirstOrDefault();
        }
        
        public void AddEncounterClick()
        {
            EncounterDetailsHeader = "New Encounter";
            encounterState = EncounterState.Adding;

            short nextNum = 1;
            EncounterController lastEncounter = GetLastEncounter();

            if (lastEncounter != null)
                nextNum = (short)(lastEncounter.Number + 1);

            SelectedEncounter = new EncounterController()
            {
                //Name = "New Encounter",
                CampaignId = Campaign.Id,
                Number = nextNum
            };
        }

        public void EncounterSelected(EncounterController clicked)
        {
            EncounterDetailsHeader = "Selected Encounter";
            encounterState = EncounterState.Editing;

            EncounterMonsters.Clear();
            EncounterMonsters = clicked.GetMonsters();
        }

        public void SaveEncounterClick()
        {
            if (encounterState == EncounterState.Adding)
            {
                SelectedEncounter.Add();
            }
            else if (encounterState == EncounterState.Editing)
            {
                SelectedEncounter.Save();
            }
            else
            {
                return;
            }

            ClearEncounterDetails();
        }

        public void DeleteEncounterClick()
        {
            if (encounterState == EncounterState.Editing)
            {
                SelectedEncounter.Delete();
            }

            ClearEncounterDetails();
        }

        public void ClearEncounterDetails()
        {
            encounterState = EncounterState.None;
            EncounterDetailsHeader = String.Empty;
            GetEncounters();
            SelectedEncounter = null;
        }

        public void AddMonsterClick()
        {
            if (SelectedAllMonster != null && SelectedEncounter != null)
            {
                using (var db = SQLiteHelper.CreateConnection())
                {
                    Encounter_MonsterController item = new Encounter_MonsterController()
                    {
                        EncounterId = SelectedEncounter.Id,
                        MonsterId = SelectedAllMonster.Id
                    };
                    item.Add();
                }
                EncounterMonsters = SelectedEncounter.GetMonsters();
            }
        }

        public void DeleteMonsterClick()
        {
            if (SelectedEncounterMonster != null)
            {
                using (var db = SQLiteHelper.CreateConnection())
                {
                    var item = (Encounter_MonsterController)db.Table<Encounter_Monster>().Where(x => x.EncounterId == SelectedEncounter.Id && x.MonsterId == SelectedEncounterMonster.Id).FirstOrDefault();
                    item.Delete();
                }
            }
            if (SelectedEncounter != null)
            {
                EncounterMonsters = SelectedEncounter.GetMonsters();
            }
        }
    }
}
