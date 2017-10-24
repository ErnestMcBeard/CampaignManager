using GalaSoft.MvvmLight;
using SQLite.Net.Attributes;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CampaignManager.Models
{
    public abstract class CharacterController : ObservableObject
    {
        #region Properties and Fields
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

        #region Physical/Class Attributes
        private Size size;
        public Size Size
        {
            get { return size; }
            set { Set(() => Size, ref size, value); }
        }

        private Alignment alignment;
        public Alignment Alignment
        {
            get { return Alignment; }
            set { Set(() => Alignment, ref alignment, value); }
        }

        private short armorClass;
        public short ArmorClass
        {
            get { return armorClass; }
            set { Set(() => ArmorClass, ref armorClass, value); }
        }

        private string armorType;
        public string ArmorType
        {
            get { return armorType; }
            set { Set(() => ArmorType, ref armorType, value); }
        }

        private short hitPoints;
        public short HitPoints
        {
            get { return hitPoints; }
            set { Set(() => HitPoints, ref hitPoints, value); }
        }

        private string hitDice;
        public string HitDice
        {
            get { return hitDice; }
            set { Set(() => HitDice, ref hitDice, value); }
        }

        private short speed;
        public short Speed
        {
            get { return speed; }
            set { Set(() => Speed, ref speed, value); }
        }

        private short proficiencyBonus;
        public short ProficiencyBonus
        {
            get { return proficiencyBonus; }
            set { Set(() => ProficiencyBonus, ref proficiencyBonus, value); }
        }
        #endregion

        #region Ability Modifiers
        private short strength;
        public short Strength
        {
            get { return strength; }
            set { Set(() => Strength, ref strength, value); }
        }
        public short StrengthModifier
        {
            get { return (short)((Strength - 10) / 2); }
        }

        private short dexterity;
        public short Dexterity
        {
            get { return dexterity; }
            set { Set(() => Dexterity, ref dexterity, value); }
        }
        public short DexterityModifier
        {
            get { return (short)((Dexterity - 10) / 2); }
        }

        private short constitution;
        public short Constitution
        {
            get { return constitution; }
            set { Set(() => Constitution, ref constitution, value); }
        }
        public short ConstitutionModifier
        {
            get { return (short)((Constitution - 10) / 2); }
        }

        private short inteligence;
        public short Inteligence
        {
            get { return inteligence; }
            set { Set(() => Inteligence, ref inteligence, value); }
        }
        public short InteligenceModifier
        {
            get { return (short)((Inteligence - 10) / 2); }
        }

        private short wisdom;
        public short Wisdom
        {
            get { return wisdom; }
            set { Set(() => Wisdom, ref wisdom, value); }
        }
        public short WisdomModifier
        {
            get { return (short)((Wisdom - 10) / 2); }
        }
        public short PassiveWisdom
        {
            get
            {
                var result = (short)(10 + WisdomModifier);
                if (Perception)
                    result += proficiencyBonus;
                return result;
            }
        }

        private short charisma;
        public short Charisma
        {
            get { return charisma; }
            set { Set(() => Charisma, ref charisma, value); }
        }
        public short CharismaModifier
        {
            get { return (short)((Charisma - 10) / 2); }
        }
        #endregion

        #region Skill Proficiencies
        private bool acrobatics;
        public bool Acrobatics
        {
            get { return acrobatics; }
            set { Set(() => Acrobatics, ref acrobatics, value); }
        }

        private bool animalHandling;
        public bool AnimalHandling
        {
            get { return animalHandling; }
            set { Set(() => AnimalHandling, ref animalHandling, value); }
        }

        private bool arcana;
        public bool Arcana
        {
            get { return arcana; }
            set { Set(() => Arcana, ref arcana, value); }
        }

        private bool athletics;
        public bool Athletics
        {
            get { return athletics; }
            set { Set(() => Athletics, ref athletics, value); }
        }

        private bool deception;
        public bool Deception
        {
            get { return deception; }
            set { Set(() => Deception, ref deception, value); }
        }

        private bool history;
        public bool History
        {
            get { return History; }
            set { Set(() => History, ref history, value); }
        }

        private bool insight;
        public bool Insight
        {
            get { return insight; }
            set { Set(() => Insight, ref insight, value); }
        }

        private bool intimidation;
        public bool Intimidation
        {
            get { return intimidation; }
            set { Set(() => Intimidation, ref intimidation, value); }
        }

        private bool investigation;
        public bool Investigation
        {
            get { return investigation; }
            set { Set(() => Investigation, ref investigation, value); }
        }

        private bool medicine;
        public bool Medicine
        {
            get { return medicine; }
            set { Set(() => Medicine, ref medicine, value); }
        }

        private bool nature;
        public bool Nature
        {
            get { return nature; }
            set { Set(() => Nature, ref nature, value); }
        }

        private bool perception;
        public bool Perception
        {
            get { return perception; }
            set { Set(() => perception, ref perception, value); }
        }

        private bool performance;
        public bool Performance
        {
            get { return performance; }
            set { Set(() => Performance, ref performance, value); }
        }

        private bool persuasion;
        public bool Persuasion
        {
            get { return persuasion; }
            set { Set(() => Persuasion, ref persuasion, value); }
        }

        private bool religion;
        public bool Religion
        {
            get { return religion; }
            set { Set(() => Religion, ref religion, value); }
        }

        private bool sleightOfHand;
        public bool SleightOfHand
        {
            get { return sleightOfHand; }
            set { Set(() => SleightOfHand, ref sleightOfHand, value); }
        }

        private bool stealth;
        public bool Stealth
        {
            get { return stealth; }
            set { Set(() => Stealth, ref stealth, value); }
        }

        private bool survival;
        public bool Survival
        {
            get { return survival; }
            set { Set(() => Survival, ref survival, value); }
        }
        #endregion

        private ObservableCollection<AbilityController> abilities;
        public ObservableCollection<AbilityController> Abilitites
        {
            get { return abilities; }
            set { Set(() => abilities, ref abilities, value); }
        }

        #endregion
    }

    public abstract class Character
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public Size Size { get; set; }
        public Alignment Alignment { get; set; }
        public short ArmorClass { get; set; }
        public string ArmorType { get; set; }
        public short HitPoints { get; set; }
        public string HitDice { get; set; }
        public short Speed { get; set; }
        public short ProficiencyBonus { get; set; }
        public short Strength { get; set; }
        public short Dexterity { get; set; }
        public short Constitution { get; set; }
        public short Inteligence { get; set; }
        public short Wisdom { get; set; }
        public short Charisma { get; set; }
        public bool Acrobatics { get; set; }
        public bool AnimalHandling { get; set; }
        public bool Arcana { get; set; }
        public bool Athletics { get; set; }
        public bool Deception { get; set; }
        public bool History { get; set; }
        public bool Insight { get; set; }
        public bool Intimidation { get; set; }
        public bool Investigation { get; set; }
        public bool Medicine { get; set; }
        public bool Nature { get; set; }
        public bool Perception { get; set; }
        public bool Performance { get; set; }
        public bool Persuasion { get; set; }
        public bool Religion { get; set; }
        public bool SleightOfHand { get; set; }
        public bool Stealth { get; set; }
        public bool Survival { get; set; }

        public List<AbilityController> Abilitites { get; set; }
    }
}
