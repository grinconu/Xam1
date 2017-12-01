namespace App_Pruebas.Behaviors
{
    using System;
    using Xamarin.Forms;

    /// <summary>
    /// Texto mayor a 10 behavior.
    /// </summary>
    public class TextoMayor10Behavior : Behavior<Entry>
    {
        /// <summary>
        /// The is valid property key.
        /// </summary>
        static readonly BindablePropertyKey IsValidPropertyKey = BindableProperty.CreateReadOnly(
            "IsValid", 
            typeof(bool), 
            typeof(TextoMayor10Behavior), 
            false);

        /// <summary>
        /// The is valid property.
        /// </summary>
        public static readonly BindableProperty IsValidProperty = IsValidPropertyKey.BindableProperty;

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:App_Pruebas.Behaviors.TextoMayor10Behaviors"/> is valid.
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
            base.OnAttachedTo(bindable);
            bindable.TextChanged += this.OnEntryTextChanged;
            bindable.BindingContextChanged += OnBindingContextChanged;
        }

        /// <summary>
        /// Ons the detaching from.
        /// </summary>
        /// <param name="bindable">Bindable.</param>
        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= this.OnEntryTextChanged;
            bindable.BindingContextChanged -= OnBindingContextChanged;
        }

        /// <summary>
        /// Ons the entry text changed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="args">Arguments.</param>
        void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            IsValid = args.NewTextValue.Length > 3;
            var campo = ((Entry)sender);//.TextColor = isValid ? Color.Default : Color.Red;
            if (IsValid)
            {
                campo.TextColor = Color.Default;
                campo.BackgroundColor = Color.Default;
            }
            else
            {
                campo.TextColor = Color.White;
                campo.BackgroundColor = Color.Red;
            }
        }

        /// <summary>
        /// Ons the binding context changed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="eventArgs">Event arguments.</param>
        private void OnBindingContextChanged(object sender, EventArgs eventArgs)
        {
            BindingContext = ((BindableObject)sender).BindingContext;
        }
    }
}
