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
        private Campaign _campaign;
        public Campaign Campaign
        {
            get { return _campaign; }
            set { Set(() => Campaign, ref _campaign, value); }
        }

        private ObservableCollection<Encounter> encounters = new ObservableCollection<Encounter>();
        public ObservableCollection<Encounter> Encounters
        {
            get { return encounters; }
            set { Set(() => Encounters, ref encounters, value); }
        }

        public CampaignViewModel()
        {
            
        }
    }
}
