using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CS_Take_Home_Challenge
{
    // a class for converting between data in the model and the UI
    public class PersonValueConverter : IValueConverter

    {
        // parameters:
        // -    value: IsActive property of Person
        // returns: foreground colour for that person on the UI
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool IsActive = (bool) value;
            return IsActive ? "Black" : "Gray";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
