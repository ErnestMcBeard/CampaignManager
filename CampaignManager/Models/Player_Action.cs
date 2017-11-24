using SQLite.Net.Attributes;

namespace CampaignManager.Models
{
    public class Player_Action
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int ActionId { get; set; }
    }
}
