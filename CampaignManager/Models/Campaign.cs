using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignManager.Models
{
    public class Campaign : ObservableObject
    {
        private Guid id;
        public Guid Id
        {
            get { return id; }
            set { Set(() => Id, ref id, value); }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { Set(() => Name, ref name, value); }
        }

        private byte[] image;
        public byte[] Image
        {
            get { return image; }
            set { Set(() => Image, ref image, value); }
        }
    }
}
