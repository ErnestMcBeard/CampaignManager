using GalaSoft.MvvmLight;
using SQLite.Net.Attributes;

namespace CampaignManager.Models
{
    public class AbilityController : ObservableObject
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

        private string effect;
        public string Effect
        {
            get { return effect; }
            set { Set(() => Effect, ref effect, value); }
        }

        private string description;
        public string Descritption
        {
            get { return description; }
            set { Set(() => Descritption, ref description, value); }
        }
    }

    public class Ability
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Effect { get; set; }
        public string Description { get; set; }
    }
}
