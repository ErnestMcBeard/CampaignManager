using GalaSoft.MvvmLight;
using SQLite.Net.Attributes;

namespace CampaignManager.Models
{
    public class ItemController : ObservableObject
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

        private string type;
        public string Type
        {
            get { return type; }
            set { Set(() => Type, ref type, value); }
        }

        private string rarity;
        public string Rarity
        {
            get { return rarity; }
            set { Set(() => Rarity, ref rarity, value); }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { Set(() => Description, ref description, value); }
        }

        public static explicit operator ItemController(Item item)
        {
            return new ItemController()
            {
                Id = item.Id,
                Name = item.Name,
                Type = item.Type,
                Rarity = item.Rarity,
                Description = item.Description
            };
        }

    }

    public class Item
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Rarity { get; set; }
        public string Description { get; set; }

        public static implicit operator Item(ItemController itemController)
        {
            return new Item()
            {
                Id = itemController.Id,
                Name = itemController.Name,
                Type = itemController.Type,
                Rarity = itemController.Rarity,
                Description = itemController.Description
            };
        }
    }
}
