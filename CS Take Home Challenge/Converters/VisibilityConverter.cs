using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace CS_Take_Home_Challenge
{
    public class VisibilityConverter : IValueConverter

    {
        #region Implementation of IValueConverter Interface
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool haveFilePath = (bool) value;
            return haveFilePath ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
