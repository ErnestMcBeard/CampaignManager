using CampaignManager.Helpers;
using CampaignManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CampaignManager.ContentDialogs
{
    public sealed partial class AddAbilityToPlayerDialog : ContentDialog, INotifyPropertyChanged
    {
        private ObservableCollection<AbilityController> abilities = new ObservableCollection<AbilityController>();
        public ObservableCollection<AbilityController> Abilities
        {
            get { return abilities; }
            set
            {
                if (abilities != value)
                {
                    abilities = value;
                    NotifyPropertyChanged(nameof(Abilities));
                }
            }
        }

        private AbilityController selectedAbility;
        public AbilityController SelectedAbility
        {
            get { return selectedAbility; }
            set
            {
                if (selectedAbility != value)
                {
                    selectedAbility = value;
                    NotifyPropertyChanged(nameof(SelectedAbility));
                }
            }
        }

        private int playerId;

        public AddAbilityToPlayerDialog(int playerId)
        {
            this.InitializeComponent();
            this.DataContext = this;
            this.playerId = playerId;

            GetAbilities();
        }

        private void GetAbilities()
        {
            using (var db = SQLiteHelper.CreateConnection())
            {
                var abilityQuery = db.Table<Ability>();
                foreach (var ability in abilityQuery)
                {
                    Abilities.Add((AbilityController)ability);
                }
            }
        }

        private void Save_Click(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (SelectedAbility != null)
            {
                var playerAbility = new Player_Ability()
                {
                    PlayerId = playerId,
                    AbilityId = SelectedAbility.Id
                };
                using (var db = SQLiteHelper.CreateConnection())
                {
                    db.Insert(playerAbility);
                }
            }
            Hide();
        }

        private void Cancel_Click(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            Hide();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}
