using CampaignManager.Helpers;
using CampaignManager.Models;
using System.ComponentModel;
using Windows.UI.Xaml.Controls;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CampaignManager.ContentDialogs
{
    public sealed partial class AddSpellDialog : ContentDialog, INotifyPropertyChanged
    {
        private SpellController newSpell;
        public SpellController NewSpell
        {
            get { return newSpell; }
            set
            {
                if (newSpell != value)
                {
                    newSpell = value;
                    NotifyPropertyChanged(nameof(NewSpell));
                }
            }
        }

        public AddSpellDialog()
        {
            this.InitializeComponent();
            this.DataContext = this;

            NewSpell = new SpellController();
        }

        private void Save_Click(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (!string.IsNullOrEmpty(NewSpell.Name))
            {
                using (var db = SQLiteHelper.CreateConnection())
                {
                    db.Insert((Spell)NewSpell);
                }
            }
            Hide();
        }

        private void Cancel_Click(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            Hide();
        }

        #region NotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
        #endregion
    }
}
