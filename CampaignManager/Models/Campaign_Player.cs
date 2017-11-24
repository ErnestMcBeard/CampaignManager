using CampaignManager.Helpers;
using GalaSoft.MvvmLight;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignManager.Models
{
    public class Campaign_PlayerController : ObservableObject
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

        private int playerId;
        public int PlayerId
        {
            get { return playerId; }
            set { Set(() => PlayerId, ref playerId, value); }
        }

        public void Add()
        {
            using (var db = SQLiteHelper.CreateConnection())
            {
                db.Insert((Campaign_Player)this);
            }
        }

        public void Save()
        {
            using (var db = SQLiteHelper.CreateConnection())
            {
                db.Update((Campaign_Player)this);
            }
        }

        public void Delete()
        {
            using (var db = SQLiteHelper.CreateConnection())
            {
                db.Delete((Campaign_Player)this);
            }
        }

        public static explicit operator Campaign_PlayerController(Campaign_Player campaignPlayer)
        {
            return new Campaign_PlayerController()
            {
                Id = campaignPlayer.Id,
                CampaignId = campaignPlayer.CampaignId,
                PlayerId = campaignPlayer.PlayerId
            };
        }
    }

    public class Campaign_Player
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int CampaignId { get; set; }
        public int PlayerId { get; set; }

        public static implicit operator Campaign_Player(Campaign_PlayerController campaignPlayer)
        {
            return new Campaign_Player()
            {
                Id = campaignPlayer.Id,
                CampaignId = campaignPlayer.CampaignId,
                PlayerId = campaignPlayer.PlayerId
            };
        }
    }
}
