using GalaSoft.MvvmLight;
using SQLite.Net.Attributes;

namespace CampaignManager.Models
{
    public class CampaignController : ObservableObject
    {
        private int id;
        public int Id
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

        public static explicit operator CampaignController(Campaign campaign)
        {
            return new CampaignController()
            {
                Id = campaign.Id,
                Name = campaign.Name,
                Image = campaign.Image
            };
        }
    }

    public class Campaign
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
    }
}
