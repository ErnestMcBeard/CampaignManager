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

        public void NavigatedTo(int campaignId)
        {
            Campaign = GetCampaign(campaignId);
            GetEncounters();
            ClearEncounterDetails();
            GetPlayers();            
        }

        private CampaignController GetCampaign(int id)
        {
            using (var db = SQLiteHelper.CreateConnection())
            {
                var query = db.Table<Campaign>();
                foreach (var campaign in query)
                {
                    if (campaign.Id == id)
                        return (CampaignController)campaign;
                }
                return null;
            }
        }

        private void GetEncounters()
        {
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
                Number = nextNum
            };
        }

        public void EncounterSelected()
        {
            EncounterDetailsHeader = "Selected Encounter";
            encounterState = EncounterState.Editing;
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
    }
}
