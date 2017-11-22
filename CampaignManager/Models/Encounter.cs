﻿using CampaignManager.Helpers;
using GalaSoft.MvvmLight;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
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

        private string name;
        public string Name
        {
            get { return name; }
            set { Set(() => Name, ref name, value); }
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

        public static explicit operator EncounterController(Encounter encounter)
        {
            return new EncounterController()
            {
                Id = encounter.Id,
                Name = encounter.Name,
                Completed = encounter.Completed
            };
        }
    }

    public class Encounter
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Completed { get; set; }

        public static implicit operator Encounter(EncounterController encounter)
        {
            return new Encounter()
            {
                Id = encounter.Id,
                Name = encounter.Name,
                Completed = encounter.Completed
            };
        }
    }
}