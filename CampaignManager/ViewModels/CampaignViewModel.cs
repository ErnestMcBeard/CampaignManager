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

        public void NavigatedTo(int campaignId)
        {
            GetCampaign(campaignId);
            GetEncounters(campaignId);
            GetPlayers(campaignId);
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

        private void GetEncounters(int campaignId)
        {
            using (var db = SQLiteHelper.CreateConnection())
            {
                var query = db.Table<Encounter>();
                foreach (var encounter in query)
                {
                    if (encounter.CampaignId == campaignId)
                    {
                        Encounters.Add((EncounterController)encounter);
                    }
                }
            }
        }

        private void GetPlayers(int campaignId)
        {
            using (var db = SQLiteHelper.CreateConnection())
            {
                var campPlayerQuery = db.Table<Campaign_Player>();
                var playerQuery = db.Table<Player>().ToList();

                foreach (var campPlayer in campPlayerQuery)
                {
                    if (campPlayer.CampaignId == campaignId)
                    {
                        PlayerController playerMatch = (PlayerController)playerQuery.Where(x => x.Id == campPlayer.PlayerId).FirstOrDefault();
                        Players.Add(playerMatch);
                    }
                }
            }
        }
    }
}
