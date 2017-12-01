namespace App_Pruebas.ViewModel.Base
{
    using System.Runtime.CompilerServices;
    using System.ComponentModel;
    using Xamarin.Forms;

    /// <summary>
    /// Base view model.
    /// </summary>
    public class BaseViewModel: INotifyPropertyChanged
    {
        /// <summary>
        /// Occurs when property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Ons the property change event handler.
        /// </summary>
        /// <param name="propertyName">Property name.</param>
        protected void OnPropertyChangeEventHandler([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Gets or sets the navigation.
        /// </summary>
        /// <value>The navigation.</value>
        public INavigation Navigation { get; set; }
    }
}
