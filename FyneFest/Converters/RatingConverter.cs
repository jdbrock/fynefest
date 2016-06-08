using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace FyneFest
{
	public class RatingConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (!(value is Double))
				return null;

			// TODO: Clean up this horseshit.
			var valueAsDouble = (Double)value;
			var quarters = valueAsDouble / 0.25;

			var result = (((int)quarters) * 0.25);

			if ((valueAsDouble - result) > 0.125)
				result += 0.25d;

			return (Decimal)result;
		}
	}
}
