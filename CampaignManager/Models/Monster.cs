using CampaignManager.Helpers;

namespace CampaignManager.Models
{
    public class MonsterController : CharacterController
    {
        private string type;
        public string Type
        {
            get { return type; }
            set { Set(() => Type, ref type, value); }
        }

        private short challengeRating;
        public short ChallengeRating
        {
            get { return challengeRating; }
            set { Set(() => ChallengeRating, ref challengeRating, value); }
        }

        private int experiencePoints;
        public int ExperiencePoints
        {
            get { return experiencePoints; }
            set { Set(() => ExperiencePoints, ref experiencePoints, value); }
        }

        public void Add()
        {
            using (var db = SQLiteHelper.CreateConnection())
            {
                db.Insert((Monster)this);
            }
        }

        public void Save()
        {
            using (var db = SQLiteHelper.CreateConnection())
            {
                db.Update((Monster)this);
            }
        }

        public void Delete()
        {
            using (var db = SQLiteHelper.CreateConnection())
            {
                db.Delete((Monster)this);
            }
        }

        public static explicit operator MonsterController(Monster monster)
        {
            return new MonsterController()
            {
                Id = monster.Id,
                Name = monster.Name,
                Size = monster.Size,
                Alignment = monster.Alignment,
                ArmorClass = monster.ArmorClass,
                ArmorType = monster.ArmorType,
                HitPoints = monster.HitPoints,
                HitDice = monster.HitDice,
                Speed = monster.Speed,
                ProficiencyBonus = monster.ProficiencyBonus,
                Strength = monster.Strength,
                Dexterity = monster.Dexterity,
                Constitution = monster.Constitution,
                Inteligence = monster.Inteligence,
                Wisdom = monster.Wisdom,
                Charisma = monster.Charisma,
                Acrobatics = monster.Acrobatics,
                AnimalHandling = monster.AnimalHandling,
                Arcana = monster.Arcana,
                Athletics = monster.Athletics,
                Deception = monster.Deception,
                History = monster.History,
                Insight = monster.Insight,
                Intimidation = monster.Intimidation,
                Investigation = monster.Investigation,
                Medicine = monster.Medicine,
                Nature = monster.Nature,
                Perception = monster.Perception,
                Performance = monster.Performance,
                Persuasion = monster.Persuasion,
                Religion = monster.Religion,
                SleightOfHand = monster.SleightOfHand,
                Stealth = monster.Stealth,
                Survival = monster.Survival,

                Type = monster.Type
            };
        }
    }

    public class Monster : Character
    {
        public string Type { get; set; }
        public short ChallengeRating { get; set; }
        public int ExperiencePoints { get; set; }

        public static implicit operator Monster(MonsterController monster)
        {
            return new Monster()
            {
                Id = monster.Id,
                Name = monster.Name,
                Size = monster.Size,
                Alignment = monster.Alignment,
                ArmorClass = monster.ArmorClass,
                ArmorType = monster.ArmorType,
                HitPoints = monster.HitPoints,
                HitDice = monster.HitDice,
                Speed = monster.Speed,
                ProficiencyBonus = monster.ProficiencyBonus,
                Strength = monster.Strength,
                Dexterity = monster.Dexterity,
                Constitution = monster.Constitution,
                Inteligence = monster.Inteligence,
                Wisdom = monster.Wisdom,
                Charisma = monster.Charisma,
                Acrobatics = monster.Acrobatics,
                AnimalHandling = monster.AnimalHandling,
                Arcana = monster.Arcana,
                Athletics = monster.Athletics,
                Deception = monster.Deception,
                History = monster.History,
                Insight = monster.Insight,
                Intimidation = monster.Intimidation,
                Investigation = monster.Investigation,
                Medicine = monster.Medicine,
                Nature = monster.Nature,
                Perception = monster.Perception,
                Performance = monster.Performance,
                Persuasion = monster.Persuasion,
                Religion = monster.Religion,
                SleightOfHand = monster.SleightOfHand,
                Stealth = monster.Stealth,
                Survival = monster.Survival,

                Type = monster.Type,
                ChallengeRating = monster.ChallengeRating,
                ExperiencePoints = monster.ExperiencePoints
            };
        }
    }
}
