using CampaignManager.Helpers;
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

        private string description;
        public string Description
        {
            get { return description; }
            set { Set(() => Description, ref description, value); }
        }

        private byte[] image;
        public byte[] Image
        {
            get { return image; }
            set { Set(() => Image, ref image, value); }
        }

        public void Add()
        {
            using (var db = SQLiteHelper.CreateConnection())
            {
                db.Insert((Campaign)this);
            }
        }

        public void Save()
        {
            using (var db = SQLiteHelper.CreateConnection())
            {
                db.Update((Campaign)this);
            }
        }

        public void Delete()
        {
            using (var db = SQLiteHelper.CreateConnection())
            {
                db.Delete((Campaign)this);
            }
        }

        public static explicit operator CampaignController(Campaign campaign)
        {
            return new CampaignController()
            {
                Id = campaign.Id,
                Name = campaign.Name,
                Description = campaign.Description,
                Image = campaign.Image
            };
        }
    }

    public class Campaign
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }

        public static implicit operator Campaign(CampaignController campaign)
        {
            return new Campaign()
            {
                Id = campaign.Id,
                Name = campaign.Name,
                Description = campaign.Description,
                Image = campaign.Image
            };
        }
    }
}
