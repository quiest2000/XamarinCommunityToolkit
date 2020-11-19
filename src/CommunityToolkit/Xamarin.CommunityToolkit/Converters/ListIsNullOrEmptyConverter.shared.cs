﻿using System;
using System.Collections;
using System.Globalization;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;

namespace Xamarin.CommunityToolkit.Converters
{
	/// <summary>
	/// Converts the incoming value to a boolean indicating whether or not the value is null or empty.
	/// </summary>
	public class ListIsNullOrEmptyConverter : ValueConverterExtension, IValueConverter
	{
		/// <summary>
		/// Converts the incoming value to a boolean indicating whether or not the value is null or empty.
		/// </summary>
		/// <param name="value">The value to convert.</param>
		/// <param name="targetType">The type of the binding target property.</param>
		/// <param name="parameter">Additional parameter for the converter to handle. Not implemented.</param>
		/// <param name="culture">The culture to use in the converter.</param>
		/// <returns>A boolean indicating if the incoming value is null or empty.</returns>
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is null)
				return true;

			if (value is IEnumerable list)
				return !list.GetEnumerator().MoveNext();

			throw new ArgumentException("Value is not a valid IEnumerable or null", nameof(value));
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
			=> throw new NotImplementedException();
	}
}