using CampaignManager.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CampaignManager.Models
{
    public class PlayerController : CharacterController
    {
        private string playedBy;
        public string PlayedBy
        {
            get { return playedBy; }
            set { Set(() => PlayedBy, ref playedBy, value); }
        }

        private string race;
        public string Race
        {
            get { return race; }
            set { Set(() => Race, ref race, value); }
        }

        private string sex;
        public string Sex
        {
            get { return sex; }
            set { Set(() => Sex, ref sex, value); }
        }

        private short age;
        public short Age
        {
            get { return age; }
            set { Set(() => Age, ref age, value); }
        }

        private string height;
        public string Height
        {
            get { return height; }
            set { Set(() => Height, ref height, value); }
        }

        private string weight;
        public string Weight
        {
            get { return weight; }
            set { Set(() => Weight, ref weight, value); }
        }

        private string playerClass;
        public string PlayerClass
        {
            get { return playerClass; }
            set { Set(() => PlayerClass, ref playerClass, value); }
        }

        private string playerLevel;
        public string PlayerLevel
        {
            get { return playerLevel; }
            set { Set(() => PlayerLevel, ref playerLevel, value); }
        }

        private string background;
        public string Background
        {
            get { return background; }
            set { Set(() => Background, ref background, value); }
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
                db.Insert((Player)this);
            }
        }

        public void Save()
        {
            using (var db = SQLiteHelper.CreateConnection())
            {
                db.Update((Player)this);
            }
        }

        public void Delete()
        {
            using (var db = SQLiteHelper.CreateConnection())
            {
                db.Delete((Player)this);
            }
        }

        public static explicit operator PlayerController(Player player)
        {
            return new PlayerController()
            {
                Id = player.Id,
                Name = player.Name,
                Size = player.Size,
                Alignment = player.Alignment,
                ArmorClass = player.ArmorClass,
                ArmorType = player.ArmorType,
                HitPoints = player.HitPoints,
                HitDice = player.HitDice,
                Speed = player.Speed,
                ProficiencyBonus = player.ProficiencyBonus,
                Strength = player.Strength,
                Dexterity = player.Dexterity,
                Constitution = player.Constitution,
                Inteligence = player.Inteligence,
                Wisdom = player.Wisdom,
                Charisma = player.Charisma,
                Acrobatics = player.Acrobatics,
                AnimalHandling = player.AnimalHandling,
                Arcana = player.Arcana,
                Athletics = player.Athletics,
                Deception = player.Deception,
                History = player.History,
                Insight = player.Insight,
                Intimidation = player.Intimidation,
                Investigation = player.Investigation,
                Medicine = player.Medicine,
                Nature = player.Nature,
                Perception = player.Perception,
                Performance = player.Performance,
                Persuasion = player.Persuasion,
                Religion = player.Religion,
                SleightOfHand = player.SleightOfHand,
                Stealth = player.Stealth,
                Survival = player.Survival,

                PlayedBy = player.PlayedBy,
                Race = player.Race,
                Sex = player.Sex,
                Age = player.Age,
                Height = player.Height,
                Weight = player.Weight,
                PlayerClass = player.PlayerClass,
                PlayerLevel = player.PlayerLevel,
                Background = player.Background,
                ExperiencePoints = player.ExperiencePoints
            };
        }
    }

    public class Player : Character
    {
        public string PlayedBy { get; set; }
        public string Race { get; set; }
        public string Sex { get; set; }
        public short Age { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string PlayerClass { get; set; }
        public string PlayerLevel { get; set; }
        public string Background { get; set; }
        public int ExperiencePoints { get; set; }


        public static implicit operator Player(PlayerController player)
        {
            return new Player()
            {
                Id = player.Id,
                Name = player.Name,
                Size = player.Size,
                Alignment = player.Alignment,
                ArmorClass = player.ArmorClass,
                ArmorType = player.ArmorType,
                HitPoints = player.HitPoints,
                HitDice = player.HitDice,
                Speed = player.Speed,
                ProficiencyBonus = player.ProficiencyBonus,
                Strength = player.Strength,
                Dexterity = player.Dexterity,
                Constitution = player.Constitution,
                Inteligence = player.Inteligence,
                Wisdom = player.Wisdom,
                Charisma = player.Charisma,
                Acrobatics = player.Acrobatics,
                AnimalHandling = player.AnimalHandling,
                Arcana = player.Arcana,
                Athletics = player.Athletics,
                Deception = player.Deception,
                History = player.History,
                Insight = player.Insight,
                Intimidation = player.Intimidation,
                Investigation = player.Investigation,
                Medicine = player.Medicine,
                Nature = player.Nature,
                Perception = player.Perception,
                Performance = player.Performance,
                Persuasion = player.Persuasion,
                Religion = player.Religion,
                SleightOfHand = player.SleightOfHand,
                Stealth = player.Stealth,
                Survival = player.Survival,

                PlayedBy = player.PlayedBy,
                Race = player.Race,
                Sex = player.Sex,
                Age = player.Age,
                Height = player.Height,
                Weight = player.Weight,
                PlayerClass = player.PlayerClass,
                PlayerLevel = player.PlayerLevel,
                Background = player.Background,
                ExperiencePoints = player.ExperiencePoints

            };
        }
    }
}
