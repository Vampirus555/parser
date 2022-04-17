using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace PoserParser
{
	public class DicToColorConverter : IValueConverter
	{
		public static Dictionary<int, string> ids = new Dictionary<int, string>();
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (int.TryParse(value.ToString(), out int id))
			{
				switch (ids[id])
				{
					case "Added":
						return new SolidColorBrush(Colors.LightGreen);
					case "Deleted":
						return new SolidColorBrush(Colors.Red);
					default:
						return new SolidColorBrush(Colors.LightGoldenrodYellow);
				}
			}
			else
				return null;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
