using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MWeatherApp.Service
{
    public partial class StringToUriConverter : IValueConverter
    {

        private static readonly Regex NonAlphabeticRegex = MyRegex();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string stringValue)
            {

                string cleanedString = NonAlphabeticRegex.Replace(stringValue, "");


                return cleanedString.ToLower();
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string stringValue)
            {

                string cleanedString = NonAlphabeticRegex.Replace(stringValue, "");


                return cleanedString.ToLower();
            }
            return value;
        }

        [GeneratedRegex("[^a-zA-Z]", RegexOptions.Compiled)]
        private static partial Regex MyRegex();
    }
}
