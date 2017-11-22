using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignManager.Models
{
    public class Alignment
    {
        private static string[] alignments = { "LG", "NG", "CG", "LN", "N", "CN", "LE", "NE", "CE" };

        public int Index { get; set; }
        public string Value { get; set; }

        public static string GetAlignment(int index)
        {
            try
            {
                return alignments[index];
            }
            catch (IndexOutOfRangeException)
            {
                return String.Empty;
            }
        }

        public static List<Alignment> GetAlignments()
        {
            var list = new List<Alignment>();
            for(int i = 0; i < alignments.Count(); i++)
            {
                list.Add(new Alignment() { Index = i, Value = alignments[i] });
            }
            return list;
        }
    }
}
