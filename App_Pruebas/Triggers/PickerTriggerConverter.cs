namespace App_Pruebas.Triggers
{
    using System;
    using System.Globalization;
    using Xamarin.Forms;

    /// <summary>
    /// Picker trigger converter.
    /// </summary>
    public class PickerTriggerConverter : IValueConverter
    {
        /// <summary>
        /// Xamarin.s the forms. IV alue converter. convert.
        /// </summary>
        /// <returns>The forms. IV alue converter. convert.</returns>
        /// <param name="value">Value.</param>
        /// <param name="targetType">Target type.</param>
        /// <param name="parameter">Parameter.</param>
        /// <param name="culture">Culture.</param>
        object IValueConverter.Convert(
            object value, 
            Type targetType, 
            object parameter, 
            CultureInfo culture)
        {
            return (value != null);
        }

        object IValueConverter.ConvertBack(
            object value, 
            Type targetType, 
            object parameter, 
            CultureInfo culture)
        {
            return null;
        }
    }
}
