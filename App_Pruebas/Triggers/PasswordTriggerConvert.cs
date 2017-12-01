namespace App_Pruebas.Triggers
{
    using System;
    using System.Globalization;
    using System.Text.RegularExpressions;
    using Xamarin.Forms;

    /// <summary>
    /// Password trigger convert.
    /// </summary>
    public class PasswordTriggerConvert : IValueConverter
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
            if(value == null)
            {
                return false;
            }
            //contraseña con mayusculas y minusculas y entr 8 y 20 caracteres.
            Regex val = new Regex(@"^(?=\w*\d)(?=\w*[A-Z])(?=\w*[a-z])\S{8,16}$");
            return val.IsMatch((value as string));
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
