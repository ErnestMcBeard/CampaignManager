using CampaignManager.Models;
using System.ComponentModel;
using Windows.UI.Xaml.Controls;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CampaignManager.ContentDialogs
{
    public sealed partial class AddItemDialog : ContentDialog, INotifyPropertyChanged
    {
        private ItemController _newItem;
        public ItemController NewItem
        {
            get { return _newItem; }
            set
            {
                if (_newItem != value)
                {
                    _newItem = value;
                    NotifyPropertyChanged(nameof(NewItem));
                }
            }
        }

        public AddItemDialog()
        {
            this.InitializeComponent();
            this.DataContext = this;
            NewItem = new ItemController();
        }

        private void Save_Click(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (!string.IsNullOrEmpty(NewItem.Name))
            {
                NewItem.Save();
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
