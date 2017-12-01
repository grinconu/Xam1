namespace App_Pruebas.Behaviors
{
    using System;
    using Xamarin.Forms;

    /// <summary>
    /// Year value behaviour.
    /// </summary>
    public class YearValueBehavior: Behavior<Entry>
    {
        /// <summary>
        /// The is valid property key.
        /// </summary>
        static readonly BindablePropertyKey IsValidPropertyKey = BindableProperty.CreateReadOnly("IsValid", typeof(bool), typeof(YearValueBehavior), false);

        /// <summary>
        /// The is valid property.
        /// </summary>
        public static readonly BindableProperty IsValidProperty = IsValidPropertyKey.BindableProperty;

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:App_Pruebas.Behaviors.YearValueBehaviour"/> is valid.
        /// </summary>
        /// <value><c>true</c> if is valid; otherwise, <c>false</c>.</value>
        public bool IsValid
        {
            get { return (bool)base.GetValue(IsValidProperty); }
            private set { base.SetValue(IsValidPropertyKey, value); }
        }

        /// <summary>
        /// Ons the attached to.
        /// </summary>
        /// <param name="bindable">Bindable.</param>
        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += HandleTextChanged;
        }

        /// <summary>
        /// Handles the text changed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrEmpty(e.NewTextValue))
            {
                if (e.NewTextValue.Length == 4)
                {
                    int year = Convert.ToInt32(e.NewTextValue);
                    this.IsValid = year > 1900 && year <= DateTime.Now.Year;
                }
                else
                    this.IsValid = false;
            }
            else
                this.IsValid = true;

            ((Entry)sender).TextColor = IsValid ? Color.DarkGray : Color.Red;
        }

        /// <summary>
        /// Ons the detaching from.
        /// </summary>
        /// <param name="bindable">Bindable.</param>
        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= HandleTextChanged;
        }
    }
}