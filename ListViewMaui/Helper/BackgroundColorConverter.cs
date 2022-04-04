using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListViewMaui
{
    public class BackgroundColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var button = parameter as Button;

            if ((bool?)value == null && button.Text == "Busy")
                return Colors.Red;
            else if ((bool?)value == true && button.Text == "Available")
                return Colors.YellowGreen;
            else if ((bool?)value == false && button.Text == "Away")
                return Colors.Orange;
            else
                return Colors.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
