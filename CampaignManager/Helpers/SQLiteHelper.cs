using CampaignManager.Models;
using SQLite.Net;
using SQLite.Net.Platform.WinRT;
using System.IO;
using Windows.Storage;

namespace CampaignManager.Helpers
{
    internal static class SQLiteHelper
    {
        private static string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, "db.sqlite");

        internal static SQLiteConnection CreateConnection()
        {
            return new SQLiteConnection(new SQLitePlatformWinRT(), path);
        }

        internal static void InitializeTables()
        {
            using (var db = CreateConnection())
            {
                db.CreateTable<Campaign>();
                db.CreateTable<Campaign_Player>();
                db.CreateTable<Player>();
                db.CreateTable<Monster>();
                db.CreateTable<Item>();
                db.CreateTable<Spell>();
                db.CreateTable<Ability>();
                db.CreateTable<Action>();
                db.CreateTable<Encounter>();
                db.CreateTable<Encounter_Monster>();
            }
        }
    }
}
