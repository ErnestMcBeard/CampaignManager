using CampaignManager.Helpers;
using GalaSoft.MvvmLight;
using SQLite.Net.Attributes;

namespace CampaignManager.Models
{
    public class ActionController : ObservableObject
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

        private short damage;
        public short Damage
        {
            get { return damage; }
            set { Set(() => Damage, ref damage, value); }
        }

        private string damageDice;
        public string DamageDice
        {
            get { return damageDice; }
            set { Set(() => DamageDice, ref damageDice, value); }
        }

        private string damageType;
        public string DamageType
        {
            get { return damageType; }
            set { Set(() => DamageType, ref damageType, value); }
        }

        public void Add()
        {
            using (var db = SQLiteHelper.CreateConnection())
            {
                db.Insert((Action)this);
            }
        }

        public void Save()
        {
            using (var db = SQLiteHelper.CreateConnection())
            {
                db.Update((Action)this);
            }
        }

        public void Delete()
        {
            using (var db = SQLiteHelper.CreateConnection())
            {
                db.Delete((Action)this);
            }
        }

        public static explicit operator ActionController(Action action)
        {
            return new ActionController()
            {
                Id = action.Id,
                Name = action.Name,
                Description = action.Description,
                Damage = action.Damage,
                DamageDice = action.DamageDice,
                DamageType = action.DamageType
            };
        }
    }

    public class Action
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public short Damage { get; set; }
        public string DamageDice { get; set; }
        public string DamageType { get; set; }

        public static implicit operator Action(ActionController action)
        {
            return new Action()
            {
                Id = action.Id,
                Name = action.Name,
                Description = action.Description,
                Damage = action.Damage,
                DamageDice = action.DamageDice,
                DamageType = action.DamageType
            };
        }
    }
}
