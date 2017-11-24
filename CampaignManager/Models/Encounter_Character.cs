using CampaignManager.Helpers;
using GalaSoft.MvvmLight;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignManager.Models
{
    public class Encounter_CharacterController : ObservableObject
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { Set(() => Id, ref id, value); }
        }

        private int encounterId;
        public int EncounterId
        {
            get { return encounterId; }
            set { Set(() => EncounterId, ref encounterId, value); }
        }

        private string characterType;
        public string CharacterType
        {
            get { return characterType; }
            set { Set(() => CharacterType, ref characterType, value); }
        }

        private int characterId;
        public int CharacterId
        {
            get { return characterId; }
            set { Set(() => CharacterId, ref characterId, value); }
        }

        public void Add()
        {
            using (var db = SQLiteHelper.CreateConnection())
            {
                db.Insert((Encounter_Character)this);
            }
        }

        public void Save()
        {
            using (var db = SQLiteHelper.CreateConnection())
            {
                db.Update((Encounter_Character)this);
            }
        }

        public void Delete()
        {
            using (var db = SQLiteHelper.CreateConnection())
            {
                db.Delete((Encounter_Character)this);
            }
        }

        public static explicit operator Encounter_CharacterController(Encounter_Character encounterCharacter)
        {
            return new Encounter_CharacterController()
            {
                Id = encounterCharacter.Id,
                EncounterId = encounterCharacter.EncounterId,
                CharacterType = encounterCharacter.CharacterType,
                CharacterId = encounterCharacter.CharacterId
            };
        }
    }

    public class Encounter_Character
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int EncounterId { get; set; }
        public string CharacterType { get; set; }
        public int CharacterId { get; set; }

        public static implicit operator Encounter_Character(Encounter_CharacterController encounterCharacter)
        {
            return new Encounter_Character()
            {
                Id = encounterCharacter.Id,
                EncounterId = encounterCharacter.EncounterId,
                CharacterType = encounterCharacter.CharacterType,
                CharacterId = encounterCharacter.CharacterId
            };
        }
    }
}


