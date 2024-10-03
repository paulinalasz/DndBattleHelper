using DndBattleHelper.Helpers;
using System.Globalization;
using System.Windows.Data;

namespace DndBattleHelper.Views.Converters
{
    public class EnumToDescriptionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var test = EnumHelper.Description((Enum)value);
            return test;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
