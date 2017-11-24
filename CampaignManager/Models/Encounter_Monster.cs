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
    public class Encounter_MonsterController : ObservableObject
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

        private int monsterId;
        public int MonsterId
        {
            get { return monsterId; }
            set { Set(() => MonsterId, ref monsterId, value); }
        }

        public void Add()
        {
            using (var db = SQLiteHelper.CreateConnection())
            {
                db.Insert((Encounter_Monster)this);
            }
        }

        public void Save()
        {
            using (var db = SQLiteHelper.CreateConnection())
            {
                db.Update((Encounter_Monster)this);
            }
        }

        public void Delete()
        {
            using (var db = SQLiteHelper.CreateConnection())
            {
                db.Delete((Encounter_Monster)this);
            }
        }

        public static explicit operator Encounter_MonsterController(Encounter_Monster encounterCharacter)
        {
            return new Encounter_MonsterController()
            {
                Id = encounterCharacter.Id,
                EncounterId = encounterCharacter.EncounterId,
                MonsterId = encounterCharacter.MonsterId
            };
        }
    }

    public class Encounter_Monster
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int EncounterId { get; set; }
        public int MonsterId { get; set; }

        public static implicit operator Encounter_Monster(Encounter_MonsterController encounterCharacter)
        {
            return new Encounter_Monster()
            {
                Id = encounterCharacter.Id,
                EncounterId = encounterCharacter.EncounterId,
                MonsterId = encounterCharacter.MonsterId
            };
        }
    }
}


