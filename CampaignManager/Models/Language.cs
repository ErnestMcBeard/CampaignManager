using GalaSoft.MvvmLight;
using SQLite.Net.Attributes;

namespace CampaignManager.Models
{
    public class LanguageController : ObservableObject
    {
        private int id;
        public int Id
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
    }

    public class Language
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
