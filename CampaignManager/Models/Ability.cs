using CampaignManager.Helpers;
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
        public string Description
        {
            get { return description; }
            set { Set(() => Description, ref description, value); }
        }

        public void Save()
        {
            using (var db = SQLiteHelper.CreateConnection())
            {
                db.Update((Ability)this);
            }
        }

        public void Add()
        {
            using (var db = SQLiteHelper.CreateConnection())
            {
                db.Insert((Ability)this);
            }
        }

        public void Delete()
        {
            using (var db = SQLiteHelper.CreateConnection())
            {
                db.Delete((Ability)this);
            }
        }

        public static explicit operator AbilityController(Ability ability)
        {
            return new AbilityController()
            {
                Id = ability.Id,
                Name = ability.Name,
                Effect = ability.Effect,
                Description = ability.Description
            };
        }
    }

    public class Ability
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Effect { get; set; }
        public string Description { get; set; }

        public static implicit operator Ability(AbilityController ability)
        {
            return new Ability()
            {
                Id = ability.Id,
                Name = ability.Name,
                Effect = ability.Effect,
                Description = ability.Description
            };
        }
    }
}
