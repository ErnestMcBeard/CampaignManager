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
    public sealed partial class AddSpellToPlayerDialog : ContentDialog, INotifyPropertyChanged
    {
        private ObservableCollection<SpellController> spells = new ObservableCollection<SpellController>();
        public ObservableCollection<SpellController> Spells
        {
            get { return spells; }
            set
            {
                if (spells != value)
                {
                    spells = value;
                    NotifyPropertyChanged(nameof(Spells));
                }
            }
        }

        private SpellController selectedSpell;
        public SpellController SelectedSpell
        {
            get { return selectedSpell; }
            set
            {
                if (selectedSpell != value)
                {
                    selectedSpell = value;
                    NotifyPropertyChanged(nameof(SelectedSpell));
                }
            }
        }

        private int playerId;

        public AddSpellToPlayerDialog(int playerId)
        {
            this.InitializeComponent();
            this.DataContext = this;
            this.playerId = playerId;

            GetSpells();
        }

        private void GetSpells()
        {
            using (var db = SQLiteHelper.CreateConnection())
            {
                var spellQuery = db.Table<Spell>();
                foreach (var spell in spellQuery)
                {
                    Spells.Add((SpellController)spell);
                }
            }
        }

        private void Save_Click(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (SelectedSpell != null)
            {
                var playerSpell = new Player_Spell()
                {
                    PlayerId = playerId,
                    SpellId = SelectedSpell.Id
                };
                using (var db = SQLiteHelper.CreateConnection())
                {
                    db.Insert(playerSpell);
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
