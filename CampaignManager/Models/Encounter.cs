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
    public class EncounterController : ObservableObject
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { Set(() => Id, ref id, value); }
        }

        private int campaignId;
        public int CampaignId
        {
            get { return campaignId; }
            set { Set(() => CampaignId, ref campaignId, value); }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { Set(() => Name, ref name, value); }
        }

        private short number;
        public short Number
        {
            get { return number; }
            set { Set(() => Number, ref number, value); }
        }

        private bool completed;
        public bool Completed
        {
            get { return completed; }
            set { Set(() => Completed, ref completed, value); }
        }

        public void Add()
        {
            using (var db = SQLiteHelper.CreateConnection())
            {
                db.Insert((Encounter)this);
            }
        }

        public void Save()
        {
            using (var db = SQLiteHelper.CreateConnection())
            {
                db.Update((Encounter)this);
            }
        }

        public void Delete()
        {
            using (var db = SQLiteHelper.CreateConnection())
            {
                db.Delete((Encounter)this);
            }
        }

        public ObservableCollection<MonsterController> GetMonsters()
        {
            using (var db = SQLiteHelper.CreateConnection())
            {
                ObservableCollection<MonsterController> results = new ObservableCollection<MonsterController>();
                var table = db.Table<Encounter_Monster>().ToList();
                var monsterIds = db.Table<Encounter_Monster>().Where(x => x.EncounterId == Id).Select(x => x.MonsterId);
                var monsterObjs = db.Table<Monster>().Where(x => monsterIds.Contains(x.Id));

                foreach (var monster in monsterObjs)
                {
                    results.Add((MonsterController)monster);
                }
                return results;
            }
        }

        public static explicit operator EncounterController(Encounter encounter)
        {
            return new EncounterController()
            {
                Id = encounter.Id,
                CampaignId = encounter.CampaignId,
                Name = encounter.Name,
                Number = encounter.Number,
                Completed = encounter.Completed
            };
        }
    }

    public class Encounter
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int CampaignId { get; set; }
        public string Name { get; set; }
        public short Number { get; set; }
        public bool Completed { get; set; }

        public static implicit operator Encounter(EncounterController encounter)
        {
            return new Encounter()
            {
                Id = encounter.Id,
                CampaignId = encounter.CampaignId,
                Name = encounter.Name,
                Number = encounter.Number,
                Completed = encounter.Completed
            };
        }
    }
}
