using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace FyneFest
{
    public class SessionToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Xamarin.Forms.Color.FromRgb(0xED, 0x63, 0x1C);

            //if (!(value is Int32))
            //    return null;

            //switch ((Int32)value)
            //{
            //    case 1: return Xamarin.Forms.Color.FromRgb(0xf1, 0xc4, 0x0f);
            //    case 2: return Xamarin.Forms.Color.FromRgb(0x29, 0x80, 0xb9);
            //    case 3: return Xamarin.Forms.Color.FromRgb(0xc0, 0x39, 0x2b);
            //    case 4: return Xamarin.Forms.Color.FromRgb(0x29, 0xb6, 0x64);
            //    default: throw new NotSupportedException();
            //}
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
