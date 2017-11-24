using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignManager.Models
{
    public class Monster_Action
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int MonsterId { get; set; }
        public int ActionId { get; set; }
    }
}
