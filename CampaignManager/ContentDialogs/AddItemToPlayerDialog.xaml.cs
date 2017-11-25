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
    public sealed partial class AddItemToPlayerDialog : ContentDialog, INotifyPropertyChanged
    {
        private int playerId;

        private ObservableCollection<ItemController> items = new ObservableCollection<ItemController>();
        public ObservableCollection<ItemController> Items
        {
            get { return items; }
            set
            {
                if (items != value)
                {
                    items = value;
                    NotifyPropertyChanged(nameof(Items));
                }
            }
        }

        private ItemController selectedItem;
        public ItemController SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (selectedItem != value)
                {
                    selectedItem = value;
                    NotifyPropertyChanged(nameof(SelectedItem));
                }
            }
        }

        public AddItemToPlayerDialog(int playerId)
        {
            this.InitializeComponent();
            this.DataContext = this;
            this.playerId = playerId;

            GetItems();
        }

        public void GetItems()
        {
            using (var db = SQLiteHelper.CreateConnection())
            {
                var itemQuery = db.Table<Item>();
                foreach (var item in itemQuery)
                {
                    Items.Add((ItemController)item);
                }
            }
        }

        private void Save_Click(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (SelectedItem != null)
            {
                var playerItem = new Player_Item()
                {
                    PlayerId = playerId,
                    ItemId = SelectedItem.Id
                };
                using (var db = SQLiteHelper.CreateConnection())
                {
                    db.Insert(playerItem);
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
