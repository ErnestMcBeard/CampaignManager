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

        public CampaignViewModel()
        {
            
        }

        public void NavigatedTo(int campaignId)
        {
            
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
    }
}
