using SQLite.Net.Attributes;
using SQLite;

namespace CampaignManager.Models
{
    public class Monster_Ability
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int MonsterId { get; set; }
        public int AbilityId { get; set; }
    }
}
