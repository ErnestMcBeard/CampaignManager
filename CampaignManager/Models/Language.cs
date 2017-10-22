using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignManager.Models
{
    public class Language : ObservableObject
    {
        private Guid id;
        public Guid Id
        {
            get { return id; }
            set { Set(() => Id, ref id, value); }
        }

        private int name;
        public int Name
        {
            get { return name; }
            set { Set(() => Name, ref name, value); }
        }
    }
}
