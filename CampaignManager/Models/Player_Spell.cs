using SQLite.Net.Attributes;

namespace CampaignManager.Models
{
    public class Player_Spell
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int SpellId { get; set; }
    }
}
