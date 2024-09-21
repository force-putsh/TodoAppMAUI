using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoAppMAUI.Converters
{
    public class BooleanTostringConverter:IValueConverter
    {
        public object? Convert(object? value,Type targetType,object? parameter,CultureInfo culture)
        {
            if (value is bool booleanValue)
            {
                return booleanValue ? "Green": "Black";
            }
            return "Transparent";
        }

        public object? ConvertBack(object? value,Type targetType,object? parameter,CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
