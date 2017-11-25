using CampaignManager.Helpers;
using CampaignManager.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Windows.UI.Xaml.Controls;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CampaignManager.ContentDialogs
{
    public sealed partial class AddActionToMonsterDialog : ContentDialog, INotifyPropertyChanged
    {
        private ObservableCollection<ActionController> actions = new ObservableCollection<ActionController>();
        public ObservableCollection<ActionController> Actions
        {
            get { return actions; }
            set
            {
                if (actions != value)
                {
                    actions = value;
                    NotifyPropertyChanged(nameof(Actions));
                }
            }
        }

        private ActionController selectedAction;
        public ActionController SelectedAction
        {
            get { return selectedAction; }
            set
            {
                if (selectedAction != value)
                {
                    selectedAction = value;
                    NotifyPropertyChanged(nameof(SelectedAction));
                }
            }
        }

        private int monsterId;

        public AddActionToMonsterDialog(int monsterId)
        {
            this.InitializeComponent();
            this.DataContext = this;
            this.monsterId = monsterId;

            GetActions();
        }

        private void GetActions()
        {
            using (var db = SQLiteHelper.CreateConnection())
            {
                var actionQuery = db.Table<Models.Action>();
                foreach (var action in actionQuery)
                {
                    Actions.Add((ActionController)action);
                }
            }
        }

        private void Save_Click(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (SelectedAction != null)
            {
                var monsterAction = new Monster_Action()
                {
                    MonsterId = monsterId,
                    ActionId = SelectedAction.Id
                };
                using (var db = SQLiteHelper.CreateConnection())
                {
                    db.Insert(monsterAction);
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
