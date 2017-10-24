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
    }

    public class Item
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}
