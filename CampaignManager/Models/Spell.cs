using GalaSoft.MvvmLight;
using SQLite.Net.Attributes;

namespace CampaignManager.Models
{
    public class SpellController : ObservableObject
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

        private short level;
        public short Level
        {
            get { return level; }
            set { Set(() => Level, ref level, value); }
        }

        private string type;
        public string Type
        {
            get { return type; }
            set { Set(() => Type, ref type, value); }
        }

        private string castingTime;
        public string CastingTime
        {
            get { return castingTime; }
            set { Set(() => CastingTime, ref castingTime, value); }
        }

        private string range;
        public string Range
        {
            get { return range; }
            set { Set(() => Range, ref range, value); }
        }

        private string components;
        public string Components
        {
            get { return components; }
            set { Set(() => Components, ref components, value); }
        }

        private string duration;
        public string Duration
        {
            get { return duration; }
            set { Set(() => Duration, ref duration, value); }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { Set(() => Description, ref description, value); }
        }

        public static explicit operator SpellController(Spell spell)
        {
            return new SpellController()
            {
                Id = spell.Id,
                Name = spell.Name,
                Level = spell.Level,
                Type = spell.Type,
                CastingTime = spell.CastingTime,
                Range = spell.Range,
                Components = spell.Components,
                Duration = spell.Duration,
                Description = spell.Description
            };
        }
    }

    public class Spell
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public short Level { get; set; }
        public string Type { get; set; }
        public string CastingTime { get; set; }
        public string Range { get; set; }
        public string Components { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }

        public static implicit operator Spell(SpellController spell)
        {
            return new Spell()
            {
                Id = spell.Id,
                Name = spell.Name,
                Level = spell.Level,
                Type = spell.Type,
                CastingTime = spell.CastingTime,
                Range = spell.Range,
                Components = spell.Components,
                Duration = spell.Duration,
                Description = spell.Description
            };
        }
    }
}
