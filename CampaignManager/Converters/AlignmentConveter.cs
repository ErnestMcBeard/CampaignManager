using CampaignManager.Models;
using System;
using System.Linq;
using Windows.UI.Xaml.Data;

namespace CampaignManager.Converters
{
    public class AlignmentConveter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            try
            {
                return Alignment.GetAlignment((int)value);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            try
            {
                var alignments = Alignment.GetAlignments();
                return alignments.Where(x => x.Value == (string)value).First();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
