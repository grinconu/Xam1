namespace App_Pruebas.Validation.@base
{
    using System;

    public interface IValidationRule<T>
    {
        /// <summary>
        /// Gets or sets the validation message.
        /// </summary>
        /// <value>The validation message.</value>
        string ValidationMessage
        {
            get;
            set;
        }

        /// <summary>
        /// Check the specified value.
        /// </summary>
        /// <returns>The check.</returns>
        /// <param name="value">Value.</param>
        bool Check(T value);
    }
}
