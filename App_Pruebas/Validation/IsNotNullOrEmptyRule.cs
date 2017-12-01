namespace App_Pruebas.Validation
{
    using App_Pruebas.Validation.@base;

    /// <summary>
    /// Is not null or empty rule.
    /// </summary>
    public class IsNotNullOrEmptyRule<T> : IValidationRule<T>
    {
        /// <summary>
        /// Gets or sets the validation message.
        /// </summary>
        /// <value>The validation message.</value>
        public string ValidationMessage 
        {
            get;
            set;
        }

        /// <summary>
        /// Check the specified value.
        /// </summary>
        /// <returns>The check.</returns>
        /// <param name="value">Value.</param>
        public bool Check(T value)
        {
            if(value == null)
            {
                return false;
            }

            var str = value as string;
            return !string.IsNullOrEmpty(str);
        }
    }
}
