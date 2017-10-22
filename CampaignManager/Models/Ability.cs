﻿using GalaSoft.MvvmLight;
using System;

namespace CampaignManager.Models
{
    public class Ability : ObservableObject
    {
        private Guid id;
        public Guid Id
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

        private string effect;
        public string Effect
        {
            get { return effect; }
            set { Set(() => Effect, ref effect, value); }
        }

        private string description;
        public string Descritption
        {
            get { return description; }
            set { Set(() => Descritption, ref description, value); }
        }
    }
}
