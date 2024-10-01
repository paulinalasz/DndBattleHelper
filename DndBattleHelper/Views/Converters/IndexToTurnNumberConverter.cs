using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DndBattleHelper.Views.Converters
{
    public class IndexToTurnNumberConveter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values.Length < 2)
                return false;

            int alternationIndex = (int)values[0];
            int turnNumber = (int)values[1];

            // Return true if the tab index matches the TurnNumber
            return alternationIndex == turnNumber;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
