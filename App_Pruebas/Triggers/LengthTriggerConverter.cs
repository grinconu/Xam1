namespace App_Pruebas.Triggers
{
    using System;
    using System.Globalization;
    using Xamarin.Forms;

    /// <summary>
    /// Multi trigger converter.
    /// </summary>
    public class LengthTriggerConverter : IValueConverter
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
            return ((int)value > 3);
        }

        /// <summary>
        /// Xamarin.s the forms. IV alue converter. convert back.
        /// </summary>
        /// <returns>The forms. IV alue converter. convert back.</returns>
        /// <param name="value">Value.</param>
        /// <param name="targetType">Target type.</param>
        /// <param name="parameter">Parameter.</param>
        /// <param name="culture">Culture.</param>
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