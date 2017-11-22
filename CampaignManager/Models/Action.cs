using GalaSoft.MvvmLight;

namespace CampaignManager.Models
{
    public class Action : ObservableObject
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
    }
}
