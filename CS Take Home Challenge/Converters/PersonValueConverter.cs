using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CS_Take_Home_Challenge
{
    public class PersonValueConverter : IValueConverter

    {
        #region Implementation of IValueConverter Interface
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool IsActive = (bool) value;
            return IsActive ? "AntiqueWhite" : "Gray";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
