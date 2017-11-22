using CampaignManager.Models;
using System;
using System.Collections.Generic;
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
    public sealed partial class AddCampaignDialog : ContentDialog, INotifyPropertyChanged
    {
        private CampaignController newCampaign;
        public CampaignController NewCampaign
        {
            get { return newCampaign; }
            set
            {
                if (newCampaign != value)
                {
                    newCampaign = value;
                    NotifyPropertyChanged(nameof(NewCampaign));
                }
            }
        }

        public AddCampaignDialog()
        {
            this.InitializeComponent();
            this.DataContext = this;

            NewCampaign = new CampaignController();
        }

        private void Save_Click(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (NewCampaign != new CampaignController())
            {
                NewCampaign.Add();
            }
            Hide();
        }

        private void Cancel_Click(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            Hide();
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
        #endregion
    }
}
